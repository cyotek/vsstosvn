namespace Cyotek.SourceSafeSvnMigration
{
  partial class SelectVssProjectsDialog
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
			System.Windows.Forms.Label label1;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectVssProjectsDialog));
			this.projectsTreeView = new System.Windows.Forms.TreeView();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(9, 88);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(48, 13);
			label1.TabIndex = 0;
			label1.Text = "&Projects:";
			// 
			// projectsTreeView
			// 
			this.projectsTreeView.CheckBoxes = true;
			this.projectsTreeView.ImageIndex = 0;
			this.projectsTreeView.ImageList = this.imageList;
			this.projectsTreeView.Location = new System.Drawing.Point(12, 104);
			this.projectsTreeView.Name = "projectsTreeView";
			this.projectsTreeView.SelectedImageIndex = 0;
			this.projectsTreeView.Size = new System.Drawing.Size(346, 231);
			this.projectsTreeView.TabIndex = 1;
			this.projectsTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.projectsTreeView_BeforeExpand);
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Fuchsia;
			this.imageList.Images.SetKeyName(0, "folder");
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.Location = new System.Drawing.Point(202, 341);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 2;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(283, 341);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 3;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(346, 79);
			this.label2.TabIndex = 4;
			this.label2.Text = "Select one or more projects to convert to SVN.\r\n\r\nCheck only the root of the proj" +
    "ect - every checkbox is interpreted as individual project to be imported.";
			// 
			// SelectVssProjectsDialog
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(370, 376);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.projectsTreeView);
			this.Controls.Add(label1);
			this.Name = "SelectVssProjectsDialog";
			this.Text = "Select Projects";
			this.ResumeLayout(false);
			this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TreeView projectsTreeView;
    private System.Windows.Forms.ImageList imageList;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
	private System.Windows.Forms.Label label2;
  }
}