using System;
using System.Media;
using System.Windows.Forms;
using System.IO;

using System.Runtime.InteropServices;



namespace Cyotek.SourceSafeSvnMigration
{

  // Icon from Pretty Office Icon Set Part 6 (http://www.customicondesign.com/free-icon/pretty-office-icon-set-part-6/)

  public partial class MainForm : BaseForm
  {
    #region  Private Member Declarations

    private bool _busy;
    private VssMigration _migration;
    private string _settingsFileName;

    #endregion  Private Member Declarations

    #region  Public Constructors

    public MainForm()
    {
      InitializeComponent();
    }

    #endregion  Public Constructors

    #region  Protected Overridden Methods

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      if (_busy)
      {
        // don't allow shutdown if the migration is in progress
        SystemSounds.Beep.Play();
		e.Cancel = true;
	  }
	  else
	  {
		  save_app_settings();
	  }

      base.OnFormClosing(e);
    }

    protected override void OnShown(EventArgs e)
    {
		base.OnShown(e);

		//disable theming for progress bar otherwise it's not displaying progress properly (1 bar behind)
		SetWindowTheme(progressBar.Handle, "", "");

		statusLabel.Text = string.Empty;

		_migration = new VssMigration();
		load_app_settings();

		if (_migration.AutoMigrate)
			migrateButton.PerformClick();
    }

    #endregion  Protected Overridden Methods

     [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
    private extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName,
                                            string pszSubIdList);
   #region  Event Handlers

    void _migration_Log(object sender, LogEventArgs e)
    {
      if (!string.IsNullOrEmpty(e.Message))
        this.Log(e.Message);

      if (e.Exception != null)
        this.Log(e.Exception.Message);

      Application.DoEvents(); // HACK: Totally unresponsive otherwise
    }

    void _migration_ProgressChanged(object sender, ProgressEventArgs e)
    {
      progressBar.Value = (int)(0.5 + e.PercentComplete);

      if (!string.IsNullOrWhiteSpace(e.Status))
        statusLabel.Text = e.Status;

      Application.DoEvents(); // ensure UI correctly redraws as everything is running on the same thread
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (AboutDialog dialog = new AboutDialog())
        dialog.ShowDialog(this);
    }

    private void advancedSettingsButton_Click(object sender, EventArgs e)
    {
      using (PropertiesDialog dialog = new PropertiesDialog(_migration))
      {
        dialog.ShowDialog(this);
        this.RefreshMigrationSettings();
      }
    }

    private void browseVssButton_Click(object sender, EventArgs e)
    {
      using (LoginDialog dialog = new LoginDialog(_migration.VssConnectionSettings))
      {
        if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        {
          vssTextBox.Text = dialog.ConnectionSettings.Database;
        }
      }
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void migrateButton_Click(object sender, EventArgs e)
    {
      this.RunAction(true);
    }

    private void openSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.OpenSettingsFile(string.Empty);
    }

    private void previewButton_Click(object sender, EventArgs e)
    {
      this.RunAction(false);
    }

    private void saveSettingsAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.SaveSettingFile(string.Empty);
    }

    private void saveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.SaveSettingFile(_settingsFileName);
    }

    private void svnProjectTextBox_TextChanged(object sender, EventArgs e)
    {
      _migration.RootSubversionProject = svnProjectTextBox.Text;
    }

    private void svnRepositoryTextBox_TextChanged(object sender, EventArgs e)
    {
      _migration.SvnConnectionSettings.RepositoryUri = svnRepositoryTextBox.Text;
    }

    private void vssProjectsBrowseButton_Click(object sender, EventArgs e)
    {
      if (VssUtilities.TestConnection(_migration.VssConnectionSettings))
      {
        using (SelectVssProjectsDialog dialog = new SelectVssProjectsDialog(_migration))
        {
          if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
          {
            this.RefreshMigrationSettings();
          }
        }
      }
      else
        MessageBox.Show("No connection to Visual SourceSafe available.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    private void vssTextBox_TextChanged(object sender, EventArgs e)
    {
      _migration.VssConnectionSettings.Database = vssTextBox.Text;
    }

    #endregion  Event Handlers

    #region  Private Methods

    private void BindEvents()
    {
      _migration.Log += _migration_Log;
      _migration.ProgressChanged += _migration_ProgressChanged;
    }

    private void Log(string text)
    {
      logTextBox.AppendText(text.Replace("\n", Environment.NewLine) + Environment.NewLine);
    }

    private void Log(string format, object[] args)
    {
      this.Log(string.Format(format, args));
    }

    private void LogException(Exception ex)
    {
      Log(ex.Message);
    }

    private void OpenSettingsFile(string fileName)
    {
      if (string.IsNullOrEmpty(fileName))
      {
        openSettingsFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
        if (openSettingsFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
          fileName = openSettingsFileDialog.FileName;
      }
 
      if (!string.IsNullOrEmpty(fileName))
      {
        try
        {
          _migration = VssMigration.OpenSettingsFile(fileName);
          _settingsFileName = fileName;
          this.BindEvents();
          this.RefreshMigrationSettings();
        }
        catch (Exception ex)
        {
          MessageBox.Show(string.Format("Failed to open settings file. {0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void RefreshMigrationSettings()
    {
      vssTextBox.Text = _migration.VssConnectionSettings.Database;

      vssProjectsListBox.Items.Clear();
      foreach (string projectName in _migration.SourceSafeProjects)
        vssProjectsListBox.Items.Add(projectName);
	  checkBoxNewName.Checked = _migration.NoSubfolderForSingleProj;
	  svnRepositoryTextBox.Text = _migration.SvnConnectionSettings.RepositoryUri != null ? _migration.SvnConnectionSettings.RepositoryUri.ToString() : string.Empty;
      svnProjectTextBox.Text = _migration.RootSubversionProject;
    }

    private void RunAction(bool isFullMigration)
    {
      try
      {
        menuStrip.Enabled = false;
        vssGroupBox.Enabled = false;
        svnGroupBox.Enabled = false;
        advancedSettingsButton.Enabled = false;
        migrateButton.Enabled = false;
        previewButton.Enabled = false;
        logTextBox.Clear();
		statusLabel.Text = string.Empty;
		progressBar.Value = 0;
        progressBar.Show();
        this.UseWaitCursor = true;
        Cursor.Current = Cursors.WaitCursor;
        _busy = true;
        Application.DoEvents(); // ensure UI correctly redraws as everything is running on the same thread

        if (isFullMigration)
        {
          _migration.Migrate();
          MessageBox.Show("Successfully migrated SourceSafe database.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
          _migration.Preview();
      }
      catch (Exception ex)
      {
        this.LogException(ex);
        MessageBox.Show(string.Format("Failed to migrate SourceSafe database. {0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally
      {
        statusLabel.Text = string.Empty;
        _busy = false;
        Cursor.Current = Cursors.Default;
        this.UseWaitCursor = false;
        progressBar.Hide();
        previewButton.Enabled = true;
        migrateButton.Enabled = true;
        advancedSettingsButton.Enabled = true;
        svnGroupBox.Enabled = true;
        vssGroupBox.Enabled = true;
        menuStrip.Enabled = true;
      }
    }

    private void SaveSettingFile(string fileName)
    {
      if (string.IsNullOrEmpty(fileName))
      {
        saveSettingsFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
        saveSettingsFileDialog.FileName = _settingsFileName;
        if (saveSettingsFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
          fileName = saveSettingsFileDialog.FileName;
      }

      if (!string.IsNullOrEmpty(fileName))
      {
        try
        {
          _migration.SaveSettings(fileName);

          _settingsFileName = fileName;
        }
        catch (Exception ex)
        {
          MessageBox.Show(string.Format("Failed to save settings file. {0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    #endregion  Private Methods

 	void load_app_settings()
	{
		string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VssToSvnSettings.xml");
		if (File.Exists(filename))
		{
			OpenSettingsFile(filename);
		}
	}

	void save_app_settings()
	{
		SaveSettingFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VssToSvnSettings.xml"));
	}

 	private void checkBoxNewName_CheckedChanged(object sender, EventArgs e)
	{
		_migration.NoSubfolderForSingleProj = checkBoxNewName.Checked;
	}

	private void buttonCreateSVNFolder_Click(object sender, EventArgs e)
	{
		if (_migration.SvnConnectionSettings.RepositoryUri != null && _migration.RootSubversionProject!=null)
		{
			string str_uri = _migration.SvnConnectionSettings.RepositoryUri;
			if (!str_uri.EndsWith("/"))
				str_uri += "/";
			Uri uri = new Uri(str_uri + _migration.RootSubversionProject);
			DialogResult res = MessageBox.Show(string.Format("Create SVN folder \"{0}\" ?", uri), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (res != DialogResult.Yes)
			{
				return;
			}
		}
		else
		{
			MessageBox.Show(string.Format("Please provide server name and project name first!"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			return;
		}
		Cursor.Current = Cursors.WaitCursor;
		try
		{
			string str_uri = _migration.CreateSVNfolder();
			MessageBox.Show(string.Format("Successfully created {0}", str_uri), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		catch (System.Exception ex)
		{
			MessageBox.Show(string.Format("Failed to create project folder!\n\n{0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		Cursor.Current = Cursors.Default;
	}
  }
}
