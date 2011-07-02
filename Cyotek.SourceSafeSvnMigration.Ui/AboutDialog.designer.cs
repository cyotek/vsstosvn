namespace Cyotek.SourceSafeSvnMigration
{
  partial class AboutDialog
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
      this.closeButton = new System.Windows.Forms.Button();
      this.nameLabel = new System.Windows.Forms.Label();
      this.versionLabel = new System.Windows.Forms.Label();
      this.copyrightLabel = new System.Windows.Forms.Label();
      this.footerGroupBox = new Cyotek.Windows.Forms.GroupBox();
      this.webLinkLabel = new System.Windows.Forms.LinkLabel();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.label1 = new System.Windows.Forms.Label();
      this.componentsListView = new System.Windows.Forms.ListView();
      this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.versionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.companyColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.footerGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // closeButton
      // 
      this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.closeButton.Location = new System.Drawing.Point(473, 59);
      this.closeButton.Name = "closeButton";
      this.closeButton.Size = new System.Drawing.Size(75, 23);
      this.closeButton.TabIndex = 0;
      this.closeButton.Text = "Close";
      this.closeButton.UseVisualStyleBackColor = true;
      this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
      // 
      // nameLabel
      // 
      this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.nameLabel.AutoSize = true;
      this.nameLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.nameLabel.Location = new System.Drawing.Point(9, 9);
      this.nameLabel.Name = "nameLabel";
      this.nameLabel.Size = new System.Drawing.Size(38, 13);
      this.nameLabel.TabIndex = 1;
      this.nameLabel.Text = "Name";
      // 
      // versionLabel
      // 
      this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.versionLabel.AutoSize = true;
      this.versionLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.versionLabel.Location = new System.Drawing.Point(9, 22);
      this.versionLabel.Name = "versionLabel";
      this.versionLabel.Size = new System.Drawing.Size(46, 13);
      this.versionLabel.TabIndex = 2;
      this.versionLabel.Text = "Version";
      // 
      // copyrightLabel
      // 
      this.copyrightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.copyrightLabel.Location = new System.Drawing.Point(12, 44);
      this.copyrightLabel.Name = "copyrightLabel";
      this.copyrightLabel.Size = new System.Drawing.Size(331, 32);
      this.copyrightLabel.TabIndex = 3;
      this.copyrightLabel.Text = "copyright";
      // 
      // footerGroupBox
      // 
      this.footerGroupBox.BackColor = System.Drawing.SystemColors.Control;
      this.footerGroupBox.Controls.Add(this.closeButton);
      this.footerGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.footerGroupBox.Location = new System.Drawing.Point(0, 308);
      this.footerGroupBox.Name = "footerGroupBox";
      this.footerGroupBox.Size = new System.Drawing.Size(560, 94);
      this.footerGroupBox.TabIndex = 0;
      this.footerGroupBox.TabStop = false;
      // 
      // webLinkLabel
      // 
      this.webLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.webLinkLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
      this.webLinkLabel.Location = new System.Drawing.Point(12, 285);
      this.webLinkLabel.Name = "webLinkLabel";
      this.webLinkLabel.Size = new System.Drawing.Size(95, 14);
      this.webLinkLabel.TabIndex = 4;
      this.webLinkLabel.TabStop = true;
      this.webLinkLabel.Tag = "www.cyotek.com";
      this.webLinkLabel.Text = "www.cyotek.com";
      this.toolTip.SetToolTip(this.webLinkLabel, "Click here to visit Cyotek");
      this.webLinkLabel.Click += new System.EventHandler(this.webLinkLabel_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 85);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(69, 13);
      this.label1.TabIndex = 5;
      this.label1.Text = "&Components:";
      // 
      // componentsListView
      // 
      this.componentsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.componentsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.versionColumnHeader,
            this.companyColumnHeader});
      this.componentsListView.FullRowSelect = true;
      this.componentsListView.Location = new System.Drawing.Point(12, 101);
      this.componentsListView.Name = "componentsListView";
      this.componentsListView.ShowItemToolTips = true;
      this.componentsListView.Size = new System.Drawing.Size(536, 178);
      this.componentsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.componentsListView.TabIndex = 6;
      this.componentsListView.UseCompatibleStateImageBehavior = false;
      this.componentsListView.View = System.Windows.Forms.View.Details;
      // 
      // nameColumnHeader
      // 
      this.nameColumnHeader.Text = "Name";
      this.nameColumnHeader.Width = 240;
      // 
      // versionColumnHeader
      // 
      this.versionColumnHeader.Text = "Version";
      this.versionColumnHeader.Width = 100;
      // 
      // companyColumnHeader
      // 
      this.companyColumnHeader.Text = "Company";
      this.companyColumnHeader.Width = 140;
      // 
      // AboutDialog
      // 
      this.AcceptButton = this.closeButton;
      this.BackColor = System.Drawing.SystemColors.Window;
      this.CancelButton = this.closeButton;
      this.ClientSize = new System.Drawing.Size(560, 402);
      this.Controls.Add(this.componentsListView);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.webLinkLabel);
      this.Controls.Add(this.footerGroupBox);
      this.Controls.Add(this.copyrightLabel);
      this.Controls.Add(this.versionLabel);
      this.Controls.Add(this.nameLabel);
      this.Name = "AboutDialog";
      this.Text = "About";
      this.footerGroupBox.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button closeButton;
    private System.Windows.Forms.Label nameLabel;
    private System.Windows.Forms.Label versionLabel;
    private System.Windows.Forms.Label copyrightLabel;
    private Cyotek.Windows.Forms.GroupBox footerGroupBox;
    private System.Windows.Forms.LinkLabel webLinkLabel;
    private System.Windows.Forms.ToolTip toolTip;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ListView componentsListView;
    private System.Windows.Forms.ColumnHeader nameColumnHeader;
    private System.Windows.Forms.ColumnHeader versionColumnHeader;
    private System.Windows.Forms.ColumnHeader companyColumnHeader;
  }
}
