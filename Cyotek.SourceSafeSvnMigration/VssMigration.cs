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
	  private bool _pinned_items_detected;

  #endregion  Private Member Declarations  

  #region  Public Constructors  

    public VssMigration()
    {
		this.RetryCount = 2;
		this.RevisionTimeWindow = 5;
		this.NoSubfolderForSingleProj = true;
		this.VssConnectionSettings = new VssConnectionSettings();
		this.SvnConnectionSettings = new SvnConnectionSettings();
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

      if (args.ContainsKey("svnproject"))
        settings.RootSubversionProject = args.AsString("svnproject");

      if (args.ContainsKey("vssproject"))
        settings.SourceSafeProjects = new List<string>(args.AsStringList("vssproject"));

      if (args.ContainsKey("nosub"))
		  settings.NoSubfolderForSingleProj = args.AsBoolean("nosub");

      if (args.ContainsKey("temppath"))
        settings.TempPath = args.AsString("temppath");

      return settings;
    }

    public static VssMigration OpenSettingsFile(string fileName)
    {
      VssMigration settings;
      XmlSerializer serializer;

	// If Exception happens here in DEBUG, it's OK. Apparently it's normal behaviour for this!
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
      
      this.OnProgressChanged(new ProgressEventArgs(100));
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

	public string CreateSVNfolder() //throws exception
	{
		string str_uri = this.SvnConnectionSettings.RepositoryUri;
		if (!str_uri.EndsWith("/"))
			str_uri += "/";
		Uri uri = new Uri(str_uri + this.RootSubversionProject);

		using (SvnClient client = SvnUtilities.CreateClient(this.SvnConnectionSettings))
		{
			client.RemoteCreateDirectory(uri, 
				new SvnCreateDirectoryArgs() {
					CreateParents = true, 
					LogMessage = "Created Project Folder"});
			return uri.ToString();
		}
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

	[Description("When only single project selected, put all its contents directly under SVN RootSubversionProject")]
	public bool NoSubfolderForSingleProj { get; set; }

 	[Description("Number of times to retry commit of each failed revision")]
	public int RetryCount { get; set; }

	[Description("Number of seconds between 2 file Checkins by the same user with the same comment to consider as part of the same revision")]
	public int RevisionTimeWindow { get; set; }

    public string RootSubversionProject { get; set; }

    public List<string> SourceSafeProjects { get; set; }

    [XmlIgnore]
    public DateTime StartedTimestamp { get; protected set; }

    public SvnConnectionSettings SvnConnectionSettings { get; set; }

    public string TempPath { get; set; }

    [XmlIgnore]
    public int TotalFilesProcessed { get; protected set; }

    public VssConnectionSettings VssConnectionSettings { get; set; }

  #endregion  Public Properties  

  #region  Private Methods  

    private void AddFileVersions(IVSSItem vssFile, Int32 f_count, IVSSVersions vssVersions)
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

			if (string.IsNullOrEmpty(version.Label)
				&& string.IsNullOrEmpty(version.LabelComment)
				&& (!string.IsNullOrEmpty(version.Action) && !version.Action.Contains("Branched")))
			{
				versions.Add(version);
			}
		}

		versions.Reverse();

		foreach (IVSSVersion version in versions)
		{
			this.AddFileVersionToChangeset(vssFile, f_count, version, isAdd);
			isAdd = false;
		}
	}

    private void AddFileVersionToChangeset(IVSSItem vssFile, Int32 f_count, IVSSVersion vssVersion, bool isAdd)
    {
      string filePath;
      VSSItem versionItem;
      string comment;
      Changeset thisChangeset;

      // define the working copy filename
      if (!this.IsPreview)
        filePath = Path.Combine(this.SvnFullRepositoryPath, this.VssRelativeFilePaths[f_count]);
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
          //I'm not sure how this happened, but it did.
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

		if (final)
		{
			Int32 revisions_processed = this.Changesets.Count;

			this.CompletedTimestamp = DateTime.Now;

			this.LogMessage("\nStart time: {0}", this.StartedTimestamp);
			this.LogMessage("End time: {0}", this.CompletedTimestamp);
			this.LogMessage("Elapsed time: {0}", this.CompletedTimestamp - this.StartedTimestamp);
			this.LogMessage("Files Migrated: {0}", this.TotalFilesProcessed);
			this.LogMessage("File Revisions Migrated: {0}", revisions_processed);

			if (_checkedOutFilesDetected)
				this.LogMessage("\nWARNING: One or more files are checked out and may not be the latest version.");

			if (_pinned_items_detected)
				this.LogMessage("\nWARNING: One or more files are pinned. You need to manually update them to correct version");
		}
 
		this.VssProjects = null;
		this.VssFiles = null;
		this.VssRelativeFilePaths = null;
		this.VssRelativeProjPaths = null;
		this.Changesets = null;
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
        //if (this.UpdateRevisionProperties) <--- always update to original date and user, doesn't make sense otherwise
        this.SetRevisionProperties(svnClient, commitResult, changeset);

		this.LogMessage("Committed revision {0}, User: {1}, Comment: {2}", commitResult.Revision, changeset.Username, changeset.Comment);
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
		if (failCount > 0)
		{
			this.LogMessage("Retrying commit again, attempt {0} of {1}...", failCount + 1, this.RetryCount);
		}
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
 		  Int32 i = this.Changesets.Values.IndexOf(changeset);
		  double progress = (double)((i + 1) * 100) / (double)(this.Changesets.Count);
          this.OnProgressChanged(new ProgressEventArgs(
			  string.Format("Commited {0} of {1}", i+1, this.Changesets.Count), progress));
        }
      }
    }

    private void CreateChangesets()
    {
      this.OnProgressChanged(new ProgressEventArgs("Creating change sets..."));

      this.Changesets = new SortedList<DateTime, Changeset>();

	  Int32 f_count = 0;
      foreach (IVSSItem vssFile in this.VssFiles)
      {
        this.TotalFilesProcessed++;
        this.LogMessage(vssFile.Spec);

        // process the file versions
		this.AddFileVersions(vssFile, f_count, vssFile.get_Versions(0));

        // send a progress message
        this.OnProgressChanged(new ProgressEventArgs((double)(this.TotalFilesProcessed * 100) / (double)this.VssFiles.Count));

		f_count++;
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
 		foreach (string str_rel_path in this.VssRelativeProjPaths)
        {
          if (!string.IsNullOrEmpty(str_rel_path))
          {
			  string path = Path.Combine(this.SvnFullRepositoryPath, str_rel_path);
			  if (!Directory.Exists(path))
				paths.Add(path);
          }
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
          //if (this.RemoveVssBindings) <--- always remove VSS bindings from solution
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
      this.CleanUp(false);
    }

    private void InitializeRepository()
    {
      if (this.IsPreview)
        throw new InvalidOperationException("Not supported in preview mode.");

      using (SvnClient client = SvnUtilities.CreateClient(this.SvnConnectionSettings))
      {
        {
            this.OnProgressChanged(new ProgressEventArgs("Checking out working copy..."));
            try
            {
                client.CheckOut(this.SvnFullRepositoryUri, this.SvnFullRepositoryPath);
            }
            catch (Exception ex)
            {
               this.LogMessage("Couldn't checkout project!\n\n" + ex.ToString());
            }
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
		// DV: Merge file checkins done within some time window into a single revision
		//     if done by the same user and with the same comment (even if empty)
		// The algorithm merges 2 consecutive checkins and assigns them the newer date, then
		// it looks at the next consecutive checkin and so on.
		// 
		// This can potentially merge lots of files into a single revision if there were no comments (usually)
		// and all files are checked in within seconds apart (as defined by the interval).
		// 
		// But really this shouldn't be a big problem
		// 
		// 

		Int32 initial_count = Changesets.Count;

		this.LogMessage("Total Revision count: {0}. Merging identical within {1} seconds window...", initial_count, RevisionTimeWindow);

		for (Int32 i=0; i<Changesets.Count; i++)
		{
			Changeset set_i = Changesets.Values[i];
			DateTime dt_upper = set_i.DateTime.AddSeconds(RevisionTimeWindow);
			for (Int32 j = i + 1; j < Changesets.Count; j++)
			{
				Changeset set_j = Changesets.Values[j];
				if (dt_upper >= set_j.DateTime
					&& set_i.Username == set_j.Username
					&& set_i.Comment == set_j.Comment)
				{
					set_j.Files.AddRange(set_i.Files);
					Changesets[set_j.DateTime] = set_j;
					Changesets.RemoveAt(i);
					i--; // so that we can re-compare the same set with the next revision on the list
					break;
				}
			}
		}

		Int32 new_count = Changesets.Count;
		if (new_count != initial_count)
		{
			this.LogMessage("New revision count is {0}.", new_count);
		}
		else
		{
			this.LogMessage("Nothing to merge.");
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

    protected List<string> VssRelativeProjPaths { get; set; }
    protected List<string> VssRelativeFilePaths { get; set; }

  #endregion  Protected Properties  

  #region  Protected Methods  

    protected virtual void AddProjectToImportList(IVSSItem projectItem, Int32 path_len_to_chop)
    {
		if (projectItem == null)
			throw new ArgumentNullException("projectItem");

		if (!projectItem.IsProject())
			throw new ArgumentException("Not a Visual SourceSafe project");

		if (!this.VssProjects.Contains(projectItem))
		{
			this.LogMessage(projectItem.Spec);
			this.VssProjects.Add(projectItem);
			string str_rel_path = VssUtilities.GetLocalPath("", projectItem, path_len_to_chop);
			this.VssRelativeProjPaths.Add(str_rel_path);
		}

		foreach (IVSSItem childItem in projectItem.Items)
		{
			if (!childItem.IsProject())
			{
				// add the file, if it is not excluded
				if (!this.ShouldExludeFileName(childItem.Name))
				{
					this.VssFiles.Add(childItem);
					string str_rel_path = VssUtilities.GetLocalPath("", childItem, path_len_to_chop);
					this.VssRelativeFilePaths.Add(str_rel_path);
				}

				// display a warning if a file is checked out
				if (childItem.IsFileCheckedOut())
				{
					this.LogMessage("WARNING: '{0}' is checked out.", childItem.Spec);
					_checkedOutFilesDetected = true;
				}
				
				// display a warning if a file is pinned
				if (childItem.IsPinned)
				{
					this.LogMessage("WARNING: '{0}' is pinned.", childItem.Spec);
					_pinned_items_detected = true;
				}
			}

			// add child projects
			if (childItem.IsProject())
				this.AddProjectToImportList(childItem, path_len_to_chop);
		}
	}

    protected virtual void CreateImportList()
    {
      this.VssProjects = new List<IVSSItem>();
      this.VssFiles = new List<IVSSItem>();
	  this.VssRelativeProjPaths = new List<string>();
	  this.VssRelativeFilePaths = new List<string>();

      this.OnProgressChanged(new ProgressEventArgs("Building import list..."));

      foreach (string projectName in this.SourceSafeProjects)
      {
        IVSSItem projectItem;

        projectItem = this.VssDatabase.get_VSSItem(projectName);

		Int32 num_chop_off = 0;
		if (this.SourceSafeProjects.Count == 1 && this.NoSubfolderForSingleProj)
		{
			num_chop_off = projectItem.Spec.Length;
		}
		else
		{
			num_chop_off = projectItem.Spec.LastIndexOf('/');
		}
        this.AddProjectToImportList(projectItem, num_chop_off);
      }

      if (this.VssProjects.Count == 0)
        throw new InvalidOperationException("Nothing to import");

      this.LogMessage("{0} projects and {1} files scanned for importing.", this.VssProjects.Count, this.VssFiles.Count);
    }

    protected virtual void OnLog(LogEventArgs e)
    {
      if (this.Log != null)
        this.Log(this, e);
    }

    protected virtual void OnProgressChanged(ProgressEventArgs e)
    {
      if (e.PercentComplete == 0.0 && !string.IsNullOrEmpty(e.Status))
        this.LogMessage(e.Status);

      if (this.ProgressChanged != null)
        this.ProgressChanged(this, e);
    }

    protected virtual void SetRevisionProperties(SvnClient svnClient, SvnCommitResult commitResult, Changeset changeset)
    {
		Boolean success = false;
		String str_exception_msg;
		str_exception_msg = "";
		try
		{
			success = true;
			success &= svnClient.SetRevisionProperty(this.SvnFullRepositoryUri, commitResult.Revision, "svn:author", changeset.Username);
			DateTime utc_time = changeset.DateTime.ToUniversalTime();
			success &= svnClient.SetRevisionProperty(this.SvnFullRepositoryUri, commitResult.Revision, "svn:date", utc_time.ToString("O"));
		}
		catch (SharpSvn.SvnException ex)
		{
			success = false;
			str_exception_msg = ex.ToString();
		}
	
		if (!success)
		{
			this.LogMessage("Couldn't set author and date for revision! Did you remember to set pre-revprop-change hook?\n\n" + str_exception_msg, commitResult.Revision);
			throw new InvalidOperationException("Failed to set Revision Property");
		}
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

	// Validate VSS projects against potential duplicate names in SVN
		if (this.SourceSafeProjects.Count > 1){
			for (Int32 i = 1; i < SourceSafeProjects.Count; i++)
			{
				string str_proj_name_i = SourceSafeProjects[i].Substring(SourceSafeProjects[i].LastIndexOf('/')+1);
				for (Int32 j = 0; j < i; j++)
				{
					string str_proj_name_j = SourceSafeProjects[j].Substring(SourceSafeProjects[j].LastIndexOf('/')+1);
					if (str_proj_name_i.Equals(str_proj_name_j, StringComparison.OrdinalIgnoreCase))
					{
						throw new InvalidOperationException(string.Format("Two or more VSS projects with the same name \"{0}\" are chosen", str_proj_name_i));
					}
				}
			}
		}

      if (this.SvnConnectionSettings.RepositoryUri == null)
        throw new InvalidOperationException("Subversion repository not specified");
    }

  #endregion  Protected Methods  
  }
}
