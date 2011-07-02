using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml.Serialization;
using SharpSvn;
using SourceSafeTypeLib;

namespace Cyotek.SourceSafeSvnMigration
{
  [Serializable]
  public class VssMigration
  {
  #region  Private Member Declarations  

    private bool _checkedOutFilesDetected;

  #endregion  Private Member Declarations  

  #region  Public Constructors  

    public VssMigration()
    {
      this.RetryCount = 3;
      this.VssConnectionSettings = new VssConnectionSettings();
      this.SvnConnectionSettings = new SvnConnectionSettings();
      this.IncludeSubFolders = true;
      this.UpdateRevisionProperties = true;
      this.RemoveVssBindings = true;
      this.SourceSafeProjects = new List<string>();
    }

  #endregion  Public Constructors  

  #region  Events  

    public event EventHandler<LogEventArgs> Log;

    public event EventHandler<ProgressEventArgs> ProgressChanged;

  #endregion  Events  

  #region  Public Class Methods  

    public static VssMigration LoadFromCommandLine()
    {
      CommandLineParser args;
      VssMigration settings;

      args = new CommandLineParser();

      if (args.ContainsKey(""))
        settings = VssMigration.OpenSettingsFile(args.AsString(""));
      else
        settings = new VssMigration();

      if (args.ContainsKey("vssdb"))
        settings.VssConnectionSettings.Database = args.AsString("vssdb");

      if (args.ContainsKey("vssuser"))
        settings.VssConnectionSettings.UserName = args.AsString("vssuser");

      if (args.ContainsKey("vsspassword"))
        settings.VssConnectionSettings.Database = args.AsString("vsspassword");

      if (args.ContainsKey("svnrepo"))
        settings.SvnConnectionSettings.RepositoryUri = args.AsString("svnrepo");

      if (args.ContainsKey("svnuser"))
        settings.SvnConnectionSettings.UserName = args.AsString("svnuser");

      if (args.ContainsKey("svnpassword"))
        settings.SvnConnectionSettings.Password = args.AsString("svnpassword");

      if (args.ContainsKey("svnfolder"))
        settings.SvnConnectionSettings.LocalFolderName = args.AsString("svnfolder");

      if (args.ContainsKey("svnproject"))
        settings.RootSubversionProject = args.AsString("svnproject");

      if (args.ContainsKey("vssproject"))
        settings.SourceSafeProjects = new List<string>(args.AsStringList("vssproject"));

      if (args.ContainsKey("subfolders"))
        settings.IncludeSubFolders = args.AsBoolean("subfolders");

      if (args.ContainsKey("revprops"))
        settings.UpdateRevisionProperties = args.AsBoolean("revprops");

      if (args.ContainsKey("removebindings"))
        settings.RemoveVssBindings = args.AsBoolean("removebindings");

      if (args.ContainsKey("createrepo"))
        settings.RecreateRepository = args.AsBoolean("createrepo");

      if (args.ContainsKey("temppath"))
        settings.TempPath = args.AsString("temppath");

      return settings;
    }

    public static VssMigration OpenSettingsFile(string fileName)
    {
      VssMigration settings;
      XmlSerializer serializer;

      serializer = new XmlSerializer(typeof(VssMigration));

      using (FileStream file = File.OpenRead(fileName))
        settings = (VssMigration)serializer.Deserialize(file);

      return settings;
    }

  #endregion  Public Class Methods  

  #region  Public Methods  

    public void Migrate()
    {
      this.IsPreview = false;
      this.ValidateSettings();
      this.Initialize();
      this.InitializeVssDatabase();
      this.CreateImportList();
      this.CreateChangesets();
      this.InitializeRepository();
      this.CreatePaths();
      this.CommitChangesets();
      this.CleanUp(true);

    }

    public void Preview()
    {
      this.IsPreview = true;
      this.ValidateSettings();
      this.Initialize();
      this.InitializeVssDatabase();
      this.CreateImportList();
      this.CreateChangesets();
      this.CleanUp(true);
    }

    public void SaveSettings(string fileName)
    {
      XmlSerializer serializer;

      serializer = new XmlSerializer(typeof(VssMigration));

      using (FileStream file = File.Create(fileName))
        serializer.Serialize(file, this);
    }

  #endregion  Public Methods  

  #region  Public Properties  

    [XmlIgnore]
    [Browsable(false)]
    public bool AutoMigrate { get; set; }

    [XmlIgnore]
    public DateTime CompletedTimestamp { get; protected set; }

    [XmlIgnore]
    [Browsable(false)]
    public List<string> FailedFiles { get; protected set; }

    public bool IncludeSubFolders { get; set; }

    [Description("Deletes the repository if it already exists then creates a new empty repository")]
    public bool RecreateRepository { get; set; }

    public bool RemoveVssBindings { get; set; }

    public int RetryCount { get; set; }

    public string RootSubversionProject { get; set; }

    public List<string> SourceSafeProjects { get; set; }

    [XmlIgnore]
    public DateTime StartedTimestamp { get; protected set; }

    public SvnConnectionSettings SvnConnectionSettings { get; set; }

    public string TempPath { get; set; }

    [XmlIgnore]
    public int TotalFileRevisionsProcessed { get; protected set; }

    [XmlIgnore]
    public int TotalFilesProcessed { get; protected set; }

    public bool UpdateRevisionProperties { get; set; }

    public VssConnectionSettings VssConnectionSettings { get; set; }

  #endregion  Public Properties  

  #region  Private Methods  

    private void AddFileVersions(IVSSItem vssFile, IVSSVersions vssVersions)
    {
      IEnumerator enumerator;
      List<IVSSVersion> versions;
      bool isAdd;

      enumerator = vssVersions.GetEnumerator();
      versions = new List<IVSSVersion>();
      isAdd = true;

      while (enumerator.MoveNext())
      {
        IVSSVersion version;

        version = (IVSSVersion)enumerator.Current;
        if (string.IsNullOrEmpty(version.Label) && string.IsNullOrEmpty(version.LabelComment))
          versions.Add(version);
      }

      versions.Reverse();

      foreach (IVSSVersion version in versions)
      {
        this.AddFileVersionToChangeset(vssFile, version, isAdd);
        isAdd = false;
      }
    }

    private void AddFileVersionToChangeset(IVSSItem vssFile, IVSSVersion vssVersion, bool isAdd)
    {
      string filePath;
      VSSItem versionItem;
      string comment;
      Changeset thisChangeset;

      this.TotalFileRevisionsProcessed++;

      // define the working copy filename
      if (!this.IsPreview)
        filePath = VssUtilities.GetLocalPath(this.SvnFullRepositoryPath, vssFile);
      else
        filePath = string.Empty;

      //get version item to get the version of the file
      versionItem = vssFile.get_Version(vssVersion.VersionNumber);
      comment = versionItem.VSSVersion.Comment;

      if (Changesets.ContainsKey(vssVersion.Date))
      {
        // using an existing change set
        thisChangeset = Changesets[vssVersion.Date];

        // different comment, so create a new change set anyway
        if (thisChangeset.Comment != comment)
        {
          bool done = false;

          //there are two different changes at the same time
          //I'm not sure how this happended, but it did.
          //make the date/time of this changeset after any existing changeset
          thisChangeset = new Changeset()
          {
            Comment = comment,
            DateTime = vssVersion.Date,
            Username = vssVersion.Username
          };

          //make sure not to try and add this entry if an entry with the time already exists
          while (!done)
          {
            if (Changesets.ContainsKey(thisChangeset.DateTime))
              thisChangeset.DateTime = thisChangeset.DateTime.AddSeconds(1);
            else
              done = true;
          }

          this.Changesets.Add(thisChangeset.DateTime, thisChangeset);
        }
      }
      else
      {
        // create a new change set
        thisChangeset = new Changeset()
        {
          Comment = comment,
          DateTime = vssVersion.Date,
          Username = vssVersion.Username
        };
        this.Changesets.Add(thisChangeset.DateTime, thisChangeset);
      }

      // add the file to the change set
      thisChangeset.Files.Add(new ChangesetFileInfo()
      {
        FilePath = filePath,
        IsAdd = isAdd,
        VssFile = vssFile,
        VssVersion = vssVersion
      });
    }

    private void CleanUp(bool final)
    {
      if (this.VssDatabase != null)
        this.VssDatabase.Close();

      this.VssProjects = null;
      this.VssFiles = null;
      this.Changesets = null;

      if (final)
      {
        this.CompletedTimestamp = DateTime.Now;

        this.LogMessage("\nStart time: {0}", this.StartedTimestamp);
        this.LogMessage("End time: {0}", this.CompletedTimestamp);
        this.LogMessage("Elapsed time: {0}", this.CompletedTimestamp - this.StartedTimestamp);
        this.LogMessage("Files Migrated: {0}", this.TotalFilesProcessed);
        this.LogMessage("File Revisions Migrated: {0}", this.TotalFileRevisionsProcessed);
      }
    }

    private void CommitChangeset(SvnClient svnClient, Changeset changeset)
    {
      SvnCommitResult commitResult;
      List<string> filePaths;

      // get the appropriate file versions out of VSS
      filePaths = this.GetChangesetFiles(svnClient, changeset);

      // commit the files to SVN
      if (filePaths.Count != 0)
        commitResult = this.CommitChangesetFiles(svnClient, changeset, filePaths);
      else
        commitResult = null;

      if (commitResult != null)
      {
        this.LogMessage("Committed revision {0}: {1}", commitResult.Revision, changeset.Comment);

        if (this.UpdateRevisionProperties)
          this.SetRevisionProperties(commitResult, changeset);
      }

      // clean up files
      foreach (ChangesetFileInfo fileInfo in changeset.Files)
      {
        if (File.Exists(fileInfo.FilePath))
          File.Delete(fileInfo.FilePath);
      }
    }

    private SvnCommitResult CommitChangesetFiles(SvnClient svnClient, Changeset changeset, List<string> filePaths)
    {
      SvnCommitResult commitResult;
      SvnCommitArgs commitArgs;
      int failCount;
      bool complete;

      commitArgs = new SvnCommitArgs { LogMessage = changeset.Comment };
      failCount = 0;
      complete = false;
      commitResult = null;

      while (!complete)
      {
        try
        {
          svnClient.Commit(filePaths, commitArgs, out commitResult);
          complete = true;
        }
        catch (Exception ex)
        {
          this.LogException(ex);

          failCount++;
          if (failCount > this.RetryCount)
            complete = true; // abort
          else
            Thread.Sleep(1000);
        }
      }

      return commitResult;
    }

    private void CommitChangesets()
    {
      this.OnProgressChanged(new ProgressEventArgs("Committing Changesets..."));

      using (SvnClient client = SvnUtilities.CreateClient(this.SvnConnectionSettings))
      {
        foreach (Changeset changeset in Changesets.Values)
        {
          // commit the changeset
          this.CommitChangeset(client, changeset);

          // send a progress message 
          this.OnProgressChanged(new ProgressEventArgs((int)(double)(this.Changesets.Values.IndexOf(changeset) * 100) / this.Changesets.Count));
        }
      }
    }

    private void CreateChangesets()
    {
      this.OnProgressChanged(new ProgressEventArgs("Creating change sets..."));

      this.Changesets = new SortedList<DateTime, Changeset>();

      foreach (IVSSItem vssFile in this.VssFiles)
      {
        this.TotalFilesProcessed++;
        this.LogMessage(vssFile.Spec);

        // process the file versions
        this.AddFileVersions(vssFile, vssFile.get_Versions(0));

        // send a progress message
        this.OnProgressChanged(new ProgressEventArgs((int)(double)(this.TotalFilesProcessed * 100) / this.VssFiles.Count));
      }

      // merge the changesets
      this.MergeChangesets();
    }

    private void CreatePaths()
    {
      List<string> paths;

      paths = new List<string>();

      using (SvnClient client = SvnUtilities.CreateClient(this.SvnConnectionSettings))
      {
        this.OnProgressChanged(new ProgressEventArgs("Creating new directories..."));
        foreach (IVSSItem project in this.VssProjects)
        {
          string path;

          path = VssUtilities.GetLocalPath(this.SvnFullRepositoryPath, project);
          if (!Directory.Exists(path))
            paths.Add(path);
        }

        client.CreateDirectories(paths, new SvnCreateDirectoryArgs() { CreateParents = true });
        client.Commit(this.SvnFullRepositoryPath, new SvnCommitArgs() { LogMessage = "Initial directory creation." });
      }
    }

    private List<string> GetChangesetFiles(SvnClient svnClient, Changeset changeset)
    {
      List<string> filePaths;

      filePaths = new List<string>();

      foreach (ChangesetFileInfo fileInfo in changeset.Files)
      {
        VSSItem versionItem;
        string filePath;

        //get version item to get the version of the file
        versionItem = fileInfo.VssFile.get_Version(fileInfo.VssVersion.VersionNumber);

        //get the version of the file in question and saves it to the path
        filePath = fileInfo.FilePath;

        try
        {
          versionItem.Get(ref filePath, (int)(VSSFlags.VSSFLAG_USERRONO | VSSFlags.VSSFLAG_TIMEMOD));
        }
        catch (COMException ex)
        {
          // skip if the file couldn't obtained - one of my databases seems to be corrupt and I can't access some files
          if (!FailedFiles.Contains(fileInfo.FilePath))
            FailedFiles.Add(fileInfo.FilePath);

          this.OnLog(new LogEventArgs(ex, string.Format("Could not get version {0} of {1}", fileInfo.VssVersion.VersionNumber, fileInfo.VssFile.Spec)));
        }

        if (File.Exists(fileInfo.FilePath))
        {
          // remove VSS bindings
          if (this.RemoveVssBindings)
            VssBindingRemover.RemoveBindings(fileInfo.FilePath);

          //add the file to SVN if it's not there yet
          if (fileInfo.IsAdd || FailedFiles.Contains(fileInfo.FilePath))
          {
            try
            {
              svnClient.Add(fileInfo.FilePath);
              this.FailedFiles.Remove(fileInfo.FilePath); // remove from the final failed files collection
            }
            catch (SvnEntryException ex)
            {
              this.LogException(ex);
            }
          }

          filePaths.Add(fileInfo.FilePath);
        }
      }

      return filePaths;
    }

    private void Initialize()
    {
      this.StartedTimestamp = DateTime.Now;

      if (!this.IsPreview)
      {
        string uri;

        if (string.IsNullOrEmpty(this.TempPath))
          this.TempPath = Path.Combine(Path.GetTempPath(), "_migrate");

        uri = this.SvnConnectionSettings.RepositoryUri;
        if (!uri.EndsWith("/"))
          uri += "/";
        this.SvnRepositoryUri = new Uri(uri);
        this.SvnFullRepositoryUri = new Uri(uri + this.RootSubversionProject);

        if (!string.IsNullOrEmpty(this.RootSubversionProject))
          this.SvnFullRepositoryPath = Path.Combine(this.TempPath, this.RootSubversionProject);
        else
          this.SvnFullRepositoryPath = this.TempPath;

        if (Directory.Exists(this.TempPath))
        {
          this.LogMessage("Deleting temporary directory...");
          foreach (string fileName in Directory.GetFiles(this.TempPath, "*.*", SearchOption.AllDirectories))
          {
            string path;

            path = Path.GetDirectoryName(fileName);
            File.SetAttributes(fileName, FileAttributes.Normal);
            File.Delete(fileName);
            if (Directory.GetDirectories(path).Length == 0 && Directory.GetFiles(path).Length == 0)
              Directory.Delete(path);
          }
          Directory.Delete(this.TempPath, true);
        }

        Directory.CreateDirectory(this.TempPath);
      }

      this.FailedFiles = new List<string>();
      this.TotalFilesProcessed = 0;
      this.TotalFileRevisionsProcessed = 0;
      this.CleanUp(false);
    }

    private void InitializeRepository()
    {
      if (this.IsPreview)
        throw new InvalidOperationException("Not supported in preview mode.");

      using (SvnClient client = SvnUtilities.CreateClient(this.SvnConnectionSettings))
      {
        if (this.RecreateRepository)
        {
          // HACK: I put this in mainly for testing purposes as I was getting fed up of manually deleting and creating the test repository each run!
          this.OnProgressChanged(new ProgressEventArgs("Creating new repository..."));
          using (SvnRepositoryClient repository = new SvnRepositoryClient())
          {
            repository.DeleteRepository(this.SvnConnectionSettings.LocalFolderName);
            repository.CreateRepository(this.SvnConnectionSettings.LocalFolderName);
          }
          Directory.CreateDirectory(Path.Combine(this.TempPath, "branches"));
          Directory.CreateDirectory(Path.Combine(this.TempPath, "tags"));
          Directory.CreateDirectory(Path.Combine(this.TempPath, "trunk"));
          client.Import(this.TempPath, this.SvnRepositoryUri, new SvnImportArgs { LogMessage = "Initial import" });
          client.CheckOut(this.SvnRepositoryUri, this.TempPath);
        }
        else
        {
          this.OnProgressChanged(new ProgressEventArgs("Checking out working copy..."));
          client.CheckOut(this.SvnFullRepositoryUri, this.SvnFullRepositoryPath);
        }
      }
    }

    private void InitializeVssDatabase()
    {
      this.VssDatabase = VssUtilities.OpenDatabase(this.VssConnectionSettings);
    }

    private void LogException(Exception ex)
    {
      this.OnLog(new LogEventArgs(ex));
    }

    private void LogMessage(string message)
    {
      this.OnLog(new LogEventArgs(message));
    }

    private void LogMessage(string format, params object[] args)
    {
      this.LogMessage(string.Format(format, args));
    }

    // After running the program with my changes I had instances of consecutive revisions 
    // with the same check-in message that are just seconds apart.  
    // I used this function to combine those into one revision
    private void MergeChangesets()
    {
      SortedList<DateTime, Changeset> mergedChangesets;
      int index = 0;
      int j;
      bool done = false;
      Changeset currentChangeset;

      // update callers
      this.OnProgressChanged(new ProgressEventArgs("Merging Revisions..."));

      mergedChangesets = new SortedList<DateTime, Changeset>();

      while (index < this.Changesets.Count)
      {
        currentChangeset = this.Changesets.Values[index];
        j = 1;
        done = false;
        while (!done)
        {
          if (index + j >= Changesets.Count)
          {
            index = index + j;
            break;
          }
          Changeset nextChangeset = Changesets.Values[index + j];
          if (!string.IsNullOrEmpty(currentChangeset.Comment) && currentChangeset.Comment == nextChangeset.Comment)
          {
            this.LogMessage("Merged revisions {0} & {1}", index, index + j);
            currentChangeset.Files.AddRange(nextChangeset.Files);
            j++;
          }
          else
          {
            mergedChangesets.Add(currentChangeset.DateTime, currentChangeset);
            index = index + j;
            done = true;
          }
        }

      }
    }

  #endregion  Private Methods  

  #region  Protected Properties  

    protected SortedList<DateTime, Changeset> Changesets { get; set; }

    protected bool IsPreview { get; set; }

    protected string SvnFullRepositoryPath { get; set; }

    protected Uri SvnFullRepositoryUri { get; set; }

    protected Uri SvnRepositoryUri { get; set; }

    protected IVSSDatabase VssDatabase { get; set; }

    protected List<IVSSItem> VssFiles { get; set; }

    protected List<IVSSItem> VssProjects { get; set; }

  #endregion  Protected Properties  

  #region  Protected Methods  

    protected virtual void AddProjectToImportList(IVSSItem projectItem)
    {
      if (projectItem == null)
        throw new ArgumentNullException("projectItem");

      if (!projectItem.IsProject())
        throw new ArgumentException("Not a Visual SourceSafe project");

      if (!this.VssProjects.Contains(projectItem))
      {
        this.LogMessage(projectItem.Spec);
        this.VssProjects.Add(projectItem);
      }

      foreach (IVSSItem childItem in projectItem.Items)
      {
        if (!childItem.IsProject())
        {
          // add the file, if it is not excluded
          if (!this.ShouldExludeFileName(childItem.Name))
            this.VssFiles.Add(childItem);

          // display a warning if a file is checked out
          if (childItem.IsFileCheckedOut())
          {
            this.LogMessage("WARNING: '{0}' is checked out.", childItem.Spec);
            _checkedOutFilesDetected = true;
          }
        }

        // add child projects
        if (this.IncludeSubFolders && childItem.IsProject())
          this.AddProjectToImportList(childItem);
      }
    }

    protected virtual void CreateImportList()
    {
      this.VssProjects = new List<IVSSItem>();
      this.VssFiles = new List<IVSSItem>();

      this.OnProgressChanged(new ProgressEventArgs("Building import list..."));

      foreach (string projectName in this.SourceSafeProjects)
      {
        IVSSItem projectItem;

        projectItem = this.VssDatabase.get_VSSItem(projectName);

        this.AddProjectToImportList(projectItem);
      }

      if (this.VssProjects.Count == 0)
        throw new InvalidOperationException("Nothing to import");

      this.LogMessage("{0} projects and {1} files scanned for importing.", this.VssProjects.Count, this.VssFiles.Count);

      if (_checkedOutFilesDetected)
        this.LogMessage("WARNING: One or more files are checked out and may not be the latest version.");
    }

    protected virtual void OnLog(LogEventArgs e)
    {
      if (this.Log != null)
        this.Log(this, e);
    }

    protected virtual void OnProgressChanged(ProgressEventArgs e)
    {
      if (e.PercentComplete == 0 && !string.IsNullOrEmpty(e.Status))
        this.LogMessage(e.Status);

      if (this.ProgressChanged != null)
        this.ProgressChanged(this, e);
    }

    protected virtual void SetRevisionProperties(SvnCommitResult commitResult, Changeset changeset)
    {
      string propertiesFolder;
      string propertiesFile;
      SvnRevProps proper;

      propertiesFolder = ((int)Math.Floor(commitResult.Revision / 1000.0)).ToString();
      propertiesFile = Path.Combine(this.SvnConnectionSettings.LocalFolderName, @"db\revprops", propertiesFolder, commitResult.Revision.ToString());
      proper = new SvnRevProps(propertiesFile);
      proper.SetAuthor(changeset.Username);
      proper.SetDate(changeset.DateTime);
      proper.Save();
    }

    protected bool ShouldExludeFileName(string fileName)
    {
      return (Path.GetExtension(fileName).ToLower().Contains("scc"));
    }

    protected virtual void ValidateSettings()
    {
      if (this.VssConnectionSettings == null)
        throw new InvalidOperationException("SourceSafeConnectionSettings not specified");

      if (this.SvnConnectionSettings == null)
        throw new InvalidOperationException("SubversionConnectionSettings not specified");

      if (this.SourceSafeProjects.Count == 0)
        throw new InvalidOperationException("Nothing to import");

      if (this.SvnConnectionSettings.RepositoryUri == null)
        throw new InvalidOperationException("Subversion repository not specified");

      if (!string.IsNullOrEmpty(this.SvnConnectionSettings.LocalFolderName) && !Directory.Exists(this.SvnConnectionSettings.LocalFolderName))
        throw new DirectoryNotFoundException();

      if (this.RecreateRepository && string.IsNullOrEmpty(this.SvnConnectionSettings.LocalFolderName))
        throw new InvalidOperationException("Cannot create or delete repository when local folder not specified");

      if (this.UpdateRevisionProperties && string.IsNullOrEmpty(this.SvnConnectionSettings.LocalFolderName))
        throw new InvalidOperationException("Cannot update revision properties when local folder not specified");
    }

  #endregion  Protected Methods  
  }
}
