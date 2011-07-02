namespace Cyotek.SourceSafeSvnMigration
{
  partial class LoginDialog
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
      System.Windows.Forms.Label databaseNameLabel;
      System.Windows.Forms.Label userNameLabel;
      System.Windows.Forms.Label passwordLabel;
      this.databaseNameTextBox = new System.Windows.Forms.TextBox();
      this.browseDatabaseButton = new System.Windows.Forms.Button();
      this.userNameTextBox = new System.Windows.Forms.TextBox();
      this.passwordTextBox = new System.Windows.Forms.TextBox();
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.testButton = new System.Windows.Forms.Button();
      databaseNameLabel = new System.Windows.Forms.Label();
      userNameLabel = new System.Windows.Forms.Label();
      passwordLabel = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // databaseNameLabel
      // 
      databaseNameLabel.AutoSize = true;
      databaseNameLabel.Location = new System.Drawing.Point(9, 9);
      databaseNameLabel.Name = "databaseNameLabel";
      databaseNameLabel.Size = new System.Drawing.Size(56, 13);
      databaseNameLabel.TabIndex = 0;
      databaseNameLabel.Text = "&Database:";
      // 
      // databaseNameTextBox
      // 
      this.databaseNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.databaseNameTextBox.Location = new System.Drawing.Point(12, 25);
      this.databaseNameTextBox.Name = "databaseNameTextBox";
      this.databaseNameTextBox.Size = new System.Drawing.Size(305, 20);
      this.databaseNameTextBox.TabIndex = 1;
      // 
      // browseDatabaseButton
      // 
      this.browseDatabaseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.browseDatabaseButton.Location = new System.Drawing.Point(323, 23);
      this.browseDatabaseButton.Name = "browseDatabaseButton";
      this.browseDatabaseButton.Size = new System.Drawing.Size(75, 23);
      this.browseDatabaseButton.TabIndex = 2;
      this.browseDatabaseButton.Text = "&Browse...";
      this.browseDatabaseButton.UseVisualStyleBackColor = true;
      this.browseDatabaseButton.Click += new System.EventHandler(this.browseDatabaseButton_Click);
      // 
      // userNameLabel
      // 
      userNameLabel.AutoSize = true;
      userNameLabel.Location = new System.Drawing.Point(12, 57);
      userNameLabel.Name = "userNameLabel";
      userNameLabel.Size = new System.Drawing.Size(61, 13);
      userNameLabel.TabIndex = 3;
      userNameLabel.Text = "&User name:";
      // 
      // userNameTextBox
      // 
      this.userNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.userNameTextBox.Location = new System.Drawing.Point(12, 73);
      this.userNameTextBox.Name = "userNameTextBox";
      this.userNameTextBox.Size = new System.Drawing.Size(305, 20);
      this.userNameTextBox.TabIndex = 4;
      // 
      // passwordLabel
      // 
      passwordLabel.AutoSize = true;
      passwordLabel.Location = new System.Drawing.Point(9, 105);
      passwordLabel.Name = "passwordLabel";
      passwordLabel.Size = new System.Drawing.Size(56, 13);
      passwordLabel.TabIndex = 5;
      passwordLabel.Text = "&Password:";
      // 
      // passwordTextBox
      // 
      this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.passwordTextBox.Location = new System.Drawing.Point(12, 121);
      this.passwordTextBox.Name = "passwordTextBox";
      this.passwordTextBox.PasswordChar = '*';
      this.passwordTextBox.Size = new System.Drawing.Size(305, 20);
      this.passwordTextBox.TabIndex = 6;
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.Location = new System.Drawing.Point(242, 160);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 7;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.okButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(323, 160);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 8;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
      // 
      // openFileDialog
      // 
      this.openFileDialog.DefaultExt = "ini";
      this.openFileDialog.Filter = "SourceSafe Databases (*.ini)|*.ini";
      this.openFileDialog.Title = "Browse SourceSafe Database";
      // 
      // testButton
      // 
      this.testButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.testButton.Location = new System.Drawing.Point(12, 160);
      this.testButton.Name = "testButton";
      this.testButton.Size = new System.Drawing.Size(97, 23);
      this.testButton.TabIndex = 9;
      this.testButton.Text = "&Test Connection";
      this.testButton.UseVisualStyleBackColor = true;
      this.testButton.Click += new System.EventHandler(this.testButton_Click);
      // 
      // LoginDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(410, 195);
      this.Controls.Add(this.testButton);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.passwordTextBox);
      this.Controls.Add(passwordLabel);
      this.Controls.Add(this.userNameTextBox);
      this.Controls.Add(userNameLabel);
      this.Controls.Add(this.browseDatabaseButton);
      this.Controls.Add(this.databaseNameTextBox);
      this.Controls.Add(databaseNameLabel);
      this.Name = "LoginDialog";
      this.Text = "SourceSafe Login";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox databaseNameTextBox;
    private System.Windows.Forms.Button browseDatabaseButton;
    private System.Windows.Forms.TextBox userNameTextBox;
    private System.Windows.Forms.TextBox passwordTextBox;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.Button testButton;
  }
}