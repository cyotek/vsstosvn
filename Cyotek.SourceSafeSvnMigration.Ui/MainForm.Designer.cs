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
      System.Windows.Forms.Label label3;
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
      this.removeVssBindingsCheckBox = new System.Windows.Forms.CheckBox();
      this.updateRevisionPropertiesCheckBox = new System.Windows.Forms.CheckBox();
      this.svnRepositoryPathButton = new System.Windows.Forms.Button();
      this.svnRepositoryPathTextBox = new System.Windows.Forms.TextBox();
      this.svnProjectTextBox = new System.Windows.Forms.TextBox();
      this.svnRepositoryTextBox = new System.Windows.Forms.TextBox();
      this.vssGroupBox = new Cyotek.Windows.Forms.GroupBox();
      this.vssProjectsListBox = new System.Windows.Forms.ListBox();
      this.includeSubFoldersCheckBox = new System.Windows.Forms.CheckBox();
      this.vssTextBox = new System.Windows.Forms.TextBox();
      this.vssProjectsBrowseButton = new System.Windows.Forms.Button();
      this.browseVssButton = new System.Windows.Forms.Button();
      this.advancedSettingsButton = new System.Windows.Forms.Button();
      this.previewButton = new System.Windows.Forms.Button();
      this.statusLabel = new System.Windows.Forms.Label();
      label3 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      label1 = new System.Windows.Forms.Label();
      vssLabel = new System.Windows.Forms.Label();
      vssProjectsLabel = new System.Windows.Forms.Label();
      this.menuStrip.SuspendLayout();
      this.svnGroupBox.SuspendLayout();
      this.vssGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(38, 112);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(85, 13);
      label3.TabIndex = 4;
      label3.Text = "Repository Pa&th:";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(38, 64);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(68, 13);
      label2.TabIndex = 2;
      label2.Text = "Root pr&oject:";
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
      vssProjectsLabel.Size = new System.Drawing.Size(48, 13);
      vssProjectsLabel.TabIndex = 3;
      vssProjectsLabel.Text = "&Projects:";
      // 
      // logTextBox
      // 
      this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.logTextBox.Location = new System.Drawing.Point(12, 394);
      this.logTextBox.Multiline = true;
      this.logTextBox.Name = "logTextBox";
      this.logTextBox.ReadOnly = true;
      this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.logTextBox.Size = new System.Drawing.Size(684, 128);
      this.logTextBox.TabIndex = 3;
      this.logTextBox.WordWrap = false;
      // 
      // migrateButton
      // 
      this.migrateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.migrateButton.Location = new System.Drawing.Point(621, 528);
      this.migrateButton.Name = "migrateButton";
      this.migrateButton.Size = new System.Drawing.Size(75, 23);
      this.migrateButton.TabIndex = 7;
      this.migrateButton.Text = "&Migrate";
      this.migrateButton.UseVisualStyleBackColor = true;
      this.migrateButton.Click += new System.EventHandler(this.migrateButton_Click);
      // 
      // progressBar
      // 
      this.progressBar.Location = new System.Drawing.Point(12, 528);
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(202, 23);
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
      this.menuStrip.Size = new System.Drawing.Size(708, 24);
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
      this.svnGroupBox.Controls.Add(this.removeVssBindingsCheckBox);
      this.svnGroupBox.Controls.Add(this.updateRevisionPropertiesCheckBox);
      this.svnGroupBox.Controls.Add(this.svnRepositoryPathButton);
      this.svnGroupBox.Controls.Add(this.svnRepositoryPathTextBox);
      this.svnGroupBox.Controls.Add(label3);
      this.svnGroupBox.Controls.Add(this.svnProjectTextBox);
      this.svnGroupBox.Controls.Add(label2);
      this.svnGroupBox.Controls.Add(this.svnRepositoryTextBox);
      this.svnGroupBox.Controls.Add(label1);
      this.svnGroupBox.Image = ((System.Drawing.Image)(resources.GetObject("svnGroupBox.Image")));
      this.svnGroupBox.Location = new System.Drawing.Point(12, 205);
      this.svnGroupBox.Name = "svnGroupBox";
      this.svnGroupBox.Size = new System.Drawing.Size(684, 183);
      this.svnGroupBox.TabIndex = 2;
      this.svnGroupBox.TabStop = false;
      this.svnGroupBox.Text = "SVN Settings";
      // 
      // removeVssBindingsCheckBox
      // 
      this.removeVssBindingsCheckBox.AutoSize = true;
      this.removeVssBindingsCheckBox.Checked = true;
      this.removeVssBindingsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.removeVssBindingsCheckBox.Location = new System.Drawing.Point(196, 154);
      this.removeVssBindingsCheckBox.Name = "removeVssBindingsCheckBox";
      this.removeVssBindingsCheckBox.Size = new System.Drawing.Size(205, 17);
      this.removeVssBindingsCheckBox.TabIndex = 8;
      this.removeVssBindingsCheckBox.Text = "&Remove SourceSafe project bindings ";
      this.removeVssBindingsCheckBox.UseVisualStyleBackColor = true;
      this.removeVssBindingsCheckBox.CheckedChanged += new System.EventHandler(this.removeVssBindingsCheckBox_CheckedChanged);
      // 
      // updateRevisionPropertiesCheckBox
      // 
      this.updateRevisionPropertiesCheckBox.AutoSize = true;
      this.updateRevisionPropertiesCheckBox.Checked = true;
      this.updateRevisionPropertiesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.updateRevisionPropertiesCheckBox.Location = new System.Drawing.Point(41, 154);
      this.updateRevisionPropertiesCheckBox.Name = "updateRevisionPropertiesCheckBox";
      this.updateRevisionPropertiesCheckBox.Size = new System.Drawing.Size(149, 17);
      this.updateRevisionPropertiesCheckBox.TabIndex = 7;
      this.updateRevisionPropertiesCheckBox.Text = "&Update revision properties";
      this.updateRevisionPropertiesCheckBox.UseVisualStyleBackColor = true;
      this.updateRevisionPropertiesCheckBox.CheckedChanged += new System.EventHandler(this.updateRevisionPropertiesCheckBox_CheckedChanged);
      // 
      // svnRepositoryPathButton
      // 
      this.svnRepositoryPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.svnRepositoryPathButton.Location = new System.Drawing.Point(603, 126);
      this.svnRepositoryPathButton.Name = "svnRepositoryPathButton";
      this.svnRepositoryPathButton.Size = new System.Drawing.Size(75, 23);
      this.svnRepositoryPathButton.TabIndex = 6;
      this.svnRepositoryPathButton.Text = "Bro&wse...";
      this.svnRepositoryPathButton.UseVisualStyleBackColor = true;
      this.svnRepositoryPathButton.Click += new System.EventHandler(this.svnRepositoryPathButton_Click);
      // 
      // svnRepositoryPathTextBox
      // 
      this.svnRepositoryPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.svnRepositoryPathTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.svnRepositoryPathTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
      this.svnRepositoryPathTextBox.Location = new System.Drawing.Point(41, 128);
      this.svnRepositoryPathTextBox.Name = "svnRepositoryPathTextBox";
      this.svnRepositoryPathTextBox.Size = new System.Drawing.Size(556, 20);
      this.svnRepositoryPathTextBox.TabIndex = 5;
      this.svnRepositoryPathTextBox.TextChanged += new System.EventHandler(this.svnRepositoryPathTextBox_TextChanged);
      // 
      // svnProjectTextBox
      // 
      this.svnProjectTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.svnProjectTextBox.Location = new System.Drawing.Point(41, 80);
      this.svnProjectTextBox.Name = "svnProjectTextBox";
      this.svnProjectTextBox.Size = new System.Drawing.Size(556, 20);
      this.svnProjectTextBox.TabIndex = 3;
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
      this.svnRepositoryTextBox.Size = new System.Drawing.Size(556, 20);
      this.svnRepositoryTextBox.TabIndex = 1;
      this.svnRepositoryTextBox.TextChanged += new System.EventHandler(this.svnRepositoryTextBox_TextChanged);
      // 
      // vssGroupBox
      // 
      this.vssGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.vssGroupBox.Controls.Add(this.vssProjectsListBox);
      this.vssGroupBox.Controls.Add(vssLabel);
      this.vssGroupBox.Controls.Add(this.includeSubFoldersCheckBox);
      this.vssGroupBox.Controls.Add(this.vssTextBox);
      this.vssGroupBox.Controls.Add(this.vssProjectsBrowseButton);
      this.vssGroupBox.Controls.Add(this.browseVssButton);
      this.vssGroupBox.Controls.Add(vssProjectsLabel);
      this.vssGroupBox.Image = ((System.Drawing.Image)(resources.GetObject("vssGroupBox.Image")));
      this.vssGroupBox.Location = new System.Drawing.Point(12, 27);
      this.vssGroupBox.Name = "vssGroupBox";
      this.vssGroupBox.Size = new System.Drawing.Size(684, 172);
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
      this.vssProjectsListBox.Size = new System.Drawing.Size(556, 63);
      this.vssProjectsListBox.TabIndex = 4;
      // 
      // includeSubFoldersCheckBox
      // 
      this.includeSubFoldersCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.includeSubFoldersCheckBox.AutoSize = true;
      this.includeSubFoldersCheckBox.Location = new System.Drawing.Point(41, 149);
      this.includeSubFoldersCheckBox.Name = "includeSubFoldersCheckBox";
      this.includeSubFoldersCheckBox.Size = new System.Drawing.Size(115, 17);
      this.includeSubFoldersCheckBox.TabIndex = 6;
      this.includeSubFoldersCheckBox.Text = "&Include sub folders";
      this.includeSubFoldersCheckBox.UseVisualStyleBackColor = true;
      this.includeSubFoldersCheckBox.CheckedChanged += new System.EventHandler(this.includeSubFoldersCheckBox_CheckedChanged);
      // 
      // vssTextBox
      // 
      this.vssTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.vssTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.vssTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
      this.vssTextBox.Location = new System.Drawing.Point(41, 32);
      this.vssTextBox.Name = "vssTextBox";
      this.vssTextBox.Size = new System.Drawing.Size(556, 20);
      this.vssTextBox.TabIndex = 1;
      this.vssTextBox.TextChanged += new System.EventHandler(this.vssTextBox_TextChanged);
      // 
      // vssProjectsBrowseButton
      // 
      this.vssProjectsBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.vssProjectsBrowseButton.Location = new System.Drawing.Point(603, 120);
      this.vssProjectsBrowseButton.Name = "vssProjectsBrowseButton";
      this.vssProjectsBrowseButton.Size = new System.Drawing.Size(75, 23);
      this.vssProjectsBrowseButton.TabIndex = 5;
      this.vssProjectsBrowseButton.Text = "&Select...";
      this.vssProjectsBrowseButton.UseVisualStyleBackColor = true;
      this.vssProjectsBrowseButton.Click += new System.EventHandler(this.vssProjectsBrowseButton_Click);
      // 
      // browseVssButton
      // 
      this.browseVssButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.browseVssButton.Location = new System.Drawing.Point(603, 30);
      this.browseVssButton.Name = "browseVssButton";
      this.browseVssButton.Size = new System.Drawing.Size(75, 23);
      this.browseVssButton.TabIndex = 2;
      this.browseVssButton.Text = "&Browse...";
      this.browseVssButton.UseVisualStyleBackColor = true;
      this.browseVssButton.Click += new System.EventHandler(this.browseVssButton_Click);
      // 
      // advancedSettingsButton
      // 
      this.advancedSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.advancedSettingsButton.Location = new System.Drawing.Point(459, 528);
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
      this.previewButton.Location = new System.Drawing.Point(540, 528);
      this.previewButton.Name = "previewButton";
      this.previewButton.Size = new System.Drawing.Size(75, 23);
      this.previewButton.TabIndex = 6;
      this.previewButton.Text = "Previe&w";
      this.previewButton.UseVisualStyleBackColor = true;
      this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
      // 
      // statusLabel
      // 
      this.statusLabel.AutoSize = true;
      this.statusLabel.Location = new System.Drawing.Point(220, 533);
      this.statusLabel.Name = "statusLabel";
      this.statusLabel.Size = new System.Drawing.Size(0, 13);
      this.statusLabel.TabIndex = 8;
      // 
      // MainForm
      // 
      this.AcceptButton = this.migrateButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(708, 563);
      this.Controls.Add(this.statusLabel);
      this.Controls.Add(this.previewButton);
      this.Controls.Add(this.advancedSettingsButton);
      this.Controls.Add(this.progressBar);
      this.Controls.Add(this.migrateButton);
      this.Controls.Add(this.logTextBox);
      this.Controls.Add(this.svnGroupBox);
      this.Controls.Add(this.vssGroupBox);
      this.Controls.Add(this.menuStrip);
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
    private System.Windows.Forms.CheckBox includeSubFoldersCheckBox;
    private Windows.Forms.GroupBox vssGroupBox;
    private Windows.Forms.GroupBox svnGroupBox;
    private System.Windows.Forms.Button svnRepositoryPathButton;
    private System.Windows.Forms.TextBox svnRepositoryPathTextBox;
    private System.Windows.Forms.TextBox svnProjectTextBox;
    private System.Windows.Forms.TextBox svnRepositoryTextBox;
    private System.Windows.Forms.CheckBox removeVssBindingsCheckBox;
    private System.Windows.Forms.CheckBox updateRevisionPropertiesCheckBox;
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
  }
}

