namespace Cyotek.SourceSafeSvnMigration
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label vssLabel;
			System.Windows.Forms.Label vssProjectsLabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.logTextBox = new System.Windows.Forms.TextBox();
			this.migrateButton = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveSettingsAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openSettingsFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveSettingsFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.svnFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.svnGroupBox = new Cyotek.Windows.Forms.GroupBox();
			this.labelHookNote = new System.Windows.Forms.Label();
			this.labelHookNote2 = new System.Windows.Forms.Label();
			this.buttonCreateSVNFolder = new System.Windows.Forms.Button();
			this.svnProjectTextBox = new System.Windows.Forms.TextBox();
			this.svnRepositoryTextBox = new System.Windows.Forms.TextBox();
			this.vssGroupBox = new Cyotek.Windows.Forms.GroupBox();
			this.vssProjectsListBox = new System.Windows.Forms.ListBox();
			this.vssTextBox = new System.Windows.Forms.TextBox();
			this.vssProjectsBrowseButton = new System.Windows.Forms.Button();
			this.browseVssButton = new System.Windows.Forms.Button();
			this.checkBoxNewName = new System.Windows.Forms.CheckBox();
			this.advancedSettingsButton = new System.Windows.Forms.Button();
			this.previewButton = new System.Windows.Forms.Button();
			this.statusLabel = new System.Windows.Forms.Label();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			vssLabel = new System.Windows.Forms.Label();
			vssProjectsLabel = new System.Windows.Forms.Label();
			this.menuStrip.SuspendLayout();
			this.svnGroupBox.SuspendLayout();
			this.vssGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(38, 64);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(267, 13);
			label2.TabIndex = 2;
			label2.Text = "Root pr&oject (This folder must already exist under SVN):";
			this.toolTip.SetToolTip(label2, "This folder must already exist. Either create it in SVN\r\nmanagement console or cl" +
        "ick on Create button");
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(38, 16);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(121, 13);
			label1.TabIndex = 0;
			label1.Text = "Subversion &Respository:";
			// 
			// vssLabel
			// 
			vssLabel.AutoSize = true;
			vssLabel.Location = new System.Drawing.Point(38, 16);
			vssLabel.Name = "vssLabel";
			vssLabel.Size = new System.Drawing.Size(115, 13);
			vssLabel.TabIndex = 0;
			vssLabel.Text = "SourceSafe &Database:";
			// 
			// vssProjectsLabel
			// 
			vssProjectsLabel.AutoSize = true;
			vssProjectsLabel.Location = new System.Drawing.Point(38, 64);
			vssProjectsLabel.Name = "vssProjectsLabel";
			vssProjectsLabel.Size = new System.Drawing.Size(234, 13);
			vssProjectsLabel.TabIndex = 3;
			vssProjectsLabel.Text = "&Projects (subfolders will be added automatically):";
			// 
			// logTextBox
			// 
			this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.logTextBox.Location = new System.Drawing.Point(12, 330);
			this.logTextBox.Multiline = true;
			this.logTextBox.Name = "logTextBox";
			this.logTextBox.ReadOnly = true;
			this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.logTextBox.Size = new System.Drawing.Size(535, 191);
			this.logTextBox.TabIndex = 3;
			this.logTextBox.WordWrap = false;
			// 
			// migrateButton
			// 
			this.migrateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.migrateButton.Location = new System.Drawing.Point(472, 548);
			this.migrateButton.Name = "migrateButton";
			this.migrateButton.Size = new System.Drawing.Size(75, 23);
			this.migrateButton.TabIndex = 7;
			this.migrateButton.Text = "&Migrate";
			this.migrateButton.UseVisualStyleBackColor = true;
			this.migrateButton.Click += new System.EventHandler(this.migrateButton_Click);
			// 
			// progressBar
			// 
			this.progressBar.ForeColor = System.Drawing.Color.MediumBlue;
			this.progressBar.Location = new System.Drawing.Point(13, 527);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(535, 15);
			this.progressBar.TabIndex = 4;
			this.progressBar.Visible = false;
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(559, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSettingsToolStripMenuItem,
            this.saveSettingsToolStripMenuItem,
            this.saveSettingsAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// openSettingsToolStripMenuItem
			// 
			this.openSettingsToolStripMenuItem.Name = "openSettingsToolStripMenuItem";
			this.openSettingsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openSettingsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.openSettingsToolStripMenuItem.Text = "&Open Settings...";
			this.openSettingsToolStripMenuItem.Click += new System.EventHandler(this.openSettingsToolStripMenuItem_Click);
			// 
			// saveSettingsToolStripMenuItem
			// 
			this.saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
			this.saveSettingsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveSettingsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.saveSettingsToolStripMenuItem.Text = "&Save Settings...";
			this.saveSettingsToolStripMenuItem.Click += new System.EventHandler(this.saveSettingsToolStripMenuItem_Click);
			// 
			// saveSettingsAsToolStripMenuItem
			// 
			this.saveSettingsAsToolStripMenuItem.Name = "saveSettingsAsToolStripMenuItem";
			this.saveSettingsAsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.saveSettingsAsToolStripMenuItem.Text = "Save Settings &As...";
			this.saveSettingsAsToolStripMenuItem.Click += new System.EventHandler(this.saveSettingsAsToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(197, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.aboutToolStripMenuItem.Text = "&About...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// openSettingsFileDialog
			// 
			this.openSettingsFileDialog.DefaultExt = "xml";
			this.openSettingsFileDialog.Filter = "Settings Files (*.xml)|*.xml|All Files (*.*)|*.*";
			// 
			// saveSettingsFileDialog
			// 
			this.saveSettingsFileDialog.DefaultExt = "xml";
			this.saveSettingsFileDialog.Filter = "Settings Files (*.xml)|*.xml|All Files (*.*)|*.*";
			// 
			// svnGroupBox
			// 
			this.svnGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.svnGroupBox.Controls.Add(this.labelHookNote);
			this.svnGroupBox.Controls.Add(this.labelHookNote2);
			this.svnGroupBox.Controls.Add(this.buttonCreateSVNFolder);
			this.svnGroupBox.Controls.Add(this.svnProjectTextBox);
			this.svnGroupBox.Controls.Add(label2);
			this.svnGroupBox.Controls.Add(this.svnRepositoryTextBox);
			this.svnGroupBox.Controls.Add(label1);
			this.svnGroupBox.Image = ((System.Drawing.Image)(resources.GetObject("svnGroupBox.Image")));
			this.svnGroupBox.Location = new System.Drawing.Point(12, 201);
			this.svnGroupBox.Name = "svnGroupBox";
			this.svnGroupBox.Size = new System.Drawing.Size(535, 123);
			this.svnGroupBox.TabIndex = 2;
			this.svnGroupBox.TabStop = false;
			this.svnGroupBox.Text = "SVN Settings";
			// 
			// labelHookNote
			// 
			this.labelHookNote.AutoSize = true;
			this.labelHookNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelHookNote.Location = new System.Drawing.Point(41, 107);
			this.labelHookNote.Name = "labelHookNote";
			this.labelHookNote.Size = new System.Drawing.Size(45, 13);
			this.labelHookNote.TabIndex = 6;
			this.labelHookNote.Text = "NOTE:";
			this.toolTip.SetToolTip(this.labelHookNote, resources.GetString("labelHookNote.ToolTip"));
			// 
			// labelHookNote2
			// 
			this.labelHookNote2.AutoSize = true;
			this.labelHookNote2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelHookNote2.Location = new System.Drawing.Point(87, 107);
			this.labelHookNote2.Name = "labelHookNote2";
			this.labelHookNote2.Size = new System.Drawing.Size(436, 13);
			this.labelHookNote2.TabIndex = 5;
			this.labelHookNote2.Text = "Make sure to have pre-revprop-change hook enabled on the server. (hover over for " +
    "details)";
			this.toolTip.SetToolTip(this.labelHookNote2, resources.GetString("labelHookNote2.ToolTip"));
			// 
			// buttonCreateSVNFolder
			// 
			this.buttonCreateSVNFolder.Location = new System.Drawing.Point(443, 80);
			this.buttonCreateSVNFolder.Name = "buttonCreateSVNFolder";
			this.buttonCreateSVNFolder.Size = new System.Drawing.Size(75, 20);
			this.buttonCreateSVNFolder.TabIndex = 4;
			this.buttonCreateSVNFolder.Text = "Create";
			this.toolTip.SetToolTip(this.buttonCreateSVNFolder, "Click to create this folder if doesn\'t already exist under SVN");
			this.buttonCreateSVNFolder.UseVisualStyleBackColor = true;
			this.buttonCreateSVNFolder.Click += new System.EventHandler(this.buttonCreateSVNFolder_Click);
			// 
			// svnProjectTextBox
			// 
			this.svnProjectTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.svnProjectTextBox.Location = new System.Drawing.Point(41, 80);
			this.svnProjectTextBox.Name = "svnProjectTextBox";
			this.svnProjectTextBox.Size = new System.Drawing.Size(391, 20);
			this.svnProjectTextBox.TabIndex = 3;
			this.toolTip.SetToolTip(this.svnProjectTextBox, "This folder must already exist. Either create it in SVN\r\nmanagement console or cl" +
        "ick on Create button");
			this.svnProjectTextBox.TextChanged += new System.EventHandler(this.svnProjectTextBox_TextChanged);
			// 
			// svnRepositoryTextBox
			// 
			this.svnRepositoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.svnRepositoryTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.svnRepositoryTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
			this.svnRepositoryTextBox.Location = new System.Drawing.Point(41, 32);
			this.svnRepositoryTextBox.Name = "svnRepositoryTextBox";
			this.svnRepositoryTextBox.Size = new System.Drawing.Size(477, 20);
			this.svnRepositoryTextBox.TabIndex = 1;
			this.toolTip.SetToolTip(this.svnRepositoryTextBox, "Example: https://myserver.com:8000/svn/repository\r\n");
			this.svnRepositoryTextBox.TextChanged += new System.EventHandler(this.svnRepositoryTextBox_TextChanged);
			// 
			// vssGroupBox
			// 
			this.vssGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.vssGroupBox.Controls.Add(this.vssProjectsListBox);
			this.vssGroupBox.Controls.Add(vssLabel);
			this.vssGroupBox.Controls.Add(this.vssTextBox);
			this.vssGroupBox.Controls.Add(this.vssProjectsBrowseButton);
			this.vssGroupBox.Controls.Add(this.browseVssButton);
			this.vssGroupBox.Controls.Add(vssProjectsLabel);
			this.vssGroupBox.Controls.Add(this.checkBoxNewName);
			this.vssGroupBox.Image = ((System.Drawing.Image)(resources.GetObject("vssGroupBox.Image")));
			this.vssGroupBox.Location = new System.Drawing.Point(12, 27);
			this.vssGroupBox.Name = "vssGroupBox";
			this.vssGroupBox.Size = new System.Drawing.Size(535, 168);
			this.vssGroupBox.TabIndex = 1;
			this.vssGroupBox.TabStop = false;
			this.vssGroupBox.Text = "SourceSafe Settings";
			// 
			// vssProjectsListBox
			// 
			this.vssProjectsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.vssProjectsListBox.FormattingEnabled = true;
			this.vssProjectsListBox.IntegralHeight = false;
			this.vssProjectsListBox.Location = new System.Drawing.Point(41, 80);
			this.vssProjectsListBox.Name = "vssProjectsListBox";
			this.vssProjectsListBox.Size = new System.Drawing.Size(367, 57);
			this.vssProjectsListBox.TabIndex = 4;
			// 
			// vssTextBox
			// 
			this.vssTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.vssTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.vssTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
			this.vssTextBox.Location = new System.Drawing.Point(41, 32);
			this.vssTextBox.Name = "vssTextBox";
			this.vssTextBox.Size = new System.Drawing.Size(367, 20);
			this.vssTextBox.TabIndex = 1;
			this.vssTextBox.TextChanged += new System.EventHandler(this.vssTextBox_TextChanged);
			// 
			// vssProjectsBrowseButton
			// 
			this.vssProjectsBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.vssProjectsBrowseButton.Location = new System.Drawing.Point(414, 80);
			this.vssProjectsBrowseButton.Name = "vssProjectsBrowseButton";
			this.vssProjectsBrowseButton.Size = new System.Drawing.Size(75, 23);
			this.vssProjectsBrowseButton.TabIndex = 5;
			this.vssProjectsBrowseButton.Text = "&Select...";
			this.toolTip.SetToolTip(this.vssProjectsBrowseButton, "Pick VSS project(s) to convert");
			this.vssProjectsBrowseButton.UseVisualStyleBackColor = true;
			this.vssProjectsBrowseButton.Click += new System.EventHandler(this.vssProjectsBrowseButton_Click);
			// 
			// browseVssButton
			// 
			this.browseVssButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browseVssButton.Location = new System.Drawing.Point(414, 29);
			this.browseVssButton.Name = "browseVssButton";
			this.browseVssButton.Size = new System.Drawing.Size(75, 23);
			this.browseVssButton.TabIndex = 2;
			this.browseVssButton.Text = "&Browse...";
			this.browseVssButton.UseVisualStyleBackColor = true;
			this.browseVssButton.Click += new System.EventHandler(this.browseVssButton_Click);
			// 
			// checkBoxNewName
			// 
			this.checkBoxNewName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxNewName.AutoSize = true;
			this.checkBoxNewName.Location = new System.Drawing.Point(41, 143);
			this.checkBoxNewName.Name = "checkBoxNewName";
			this.checkBoxNewName.Size = new System.Drawing.Size(469, 17);
			this.checkBoxNewName.TabIndex = 6;
			this.checkBoxNewName.Text = "For single VSS project put its contents derectly under SVN root project name (i.e" +
    ". no subfolder)";
			this.toolTip.SetToolTip(this.checkBoxNewName, resources.GetString("checkBoxNewName.ToolTip"));
			this.checkBoxNewName.UseVisualStyleBackColor = true;
			this.checkBoxNewName.CheckedChanged += new System.EventHandler(this.checkBoxNewName_CheckedChanged);
			// 
			// advancedSettingsButton
			// 
			this.advancedSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.advancedSettingsButton.Location = new System.Drawing.Point(310, 548);
			this.advancedSettingsButton.Name = "advancedSettingsButton";
			this.advancedSettingsButton.Size = new System.Drawing.Size(75, 23);
			this.advancedSettingsButton.TabIndex = 5;
			this.advancedSettingsButton.Text = "Ad&vanced...";
			this.advancedSettingsButton.UseVisualStyleBackColor = true;
			this.advancedSettingsButton.Click += new System.EventHandler(this.advancedSettingsButton_Click);
			// 
			// previewButton
			// 
			this.previewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.previewButton.Location = new System.Drawing.Point(391, 548);
			this.previewButton.Name = "previewButton";
			this.previewButton.Size = new System.Drawing.Size(75, 23);
			this.previewButton.TabIndex = 6;
			this.previewButton.Text = "Previe&w";
			this.previewButton.UseVisualStyleBackColor = true;
			this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
			// 
			// statusLabel
			// 
			this.statusLabel.Location = new System.Drawing.Point(10, 548);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(272, 23);
			this.statusLabel.TabIndex = 8;
			this.statusLabel.Text = "Status Messages....";
			this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolTip
			// 
			this.toolTip.AutomaticDelay = 100;
			this.toolTip.AutoPopDelay = 15000;
			this.toolTip.InitialDelay = 100;
			this.toolTip.ReshowDelay = 20;
			// 
			// MainForm
			// 
			this.AcceptButton = this.migrateButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(559, 579);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.previewButton);
			this.Controls.Add(this.advancedSettingsButton);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.migrateButton);
			this.Controls.Add(this.svnGroupBox);
			this.Controls.Add(this.vssGroupBox);
			this.Controls.Add(this.menuStrip);
			this.Controls.Add(this.logTextBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "SourceSafe to Subversion Migration Tool";
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.svnGroupBox.ResumeLayout(false);
			this.svnGroupBox.PerformLayout();
			this.vssGroupBox.ResumeLayout(false);
			this.vssGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox vssTextBox;
    private System.Windows.Forms.Button browseVssButton;
    private System.Windows.Forms.ListBox vssProjectsListBox;
	private System.Windows.Forms.Button vssProjectsBrowseButton;
    private Windows.Forms.GroupBox vssGroupBox;
    private Windows.Forms.GroupBox svnGroupBox;
    private System.Windows.Forms.TextBox svnProjectTextBox;
	private System.Windows.Forms.TextBox svnRepositoryTextBox;
    private System.Windows.Forms.TextBox logTextBox;
    private System.Windows.Forms.Button migrateButton;
    private System.Windows.Forms.ProgressBar progressBar;
    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openSettingsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveSettingsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveSettingsAsToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.OpenFileDialog openSettingsFileDialog;
    private System.Windows.Forms.SaveFileDialog saveSettingsFileDialog;
    private System.Windows.Forms.FolderBrowserDialog svnFolderBrowserDialog;
    private System.Windows.Forms.Button advancedSettingsButton;
    private System.Windows.Forms.Button previewButton;
	private System.Windows.Forms.Label statusLabel;
	private System.Windows.Forms.CheckBox checkBoxNewName;
	private System.Windows.Forms.Button buttonCreateSVNFolder;
	private System.Windows.Forms.Label labelHookNote2;
	private System.Windows.Forms.Label labelHookNote;
	private System.Windows.Forms.ToolTip toolTip;
  }
}

