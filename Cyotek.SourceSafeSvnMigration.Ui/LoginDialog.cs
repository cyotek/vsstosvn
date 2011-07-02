using System;
using System.Windows.Forms;
using SourceSafeTypeLib;
using System.Drawing;

namespace Cyotek.SourceSafeSvnMigration
{
  public partial class LoginDialog : BaseDialog
  {
    #region  Public Constructors

    public LoginDialog()
    {
      InitializeComponent();
    }

    public LoginDialog(VssConnectionSettings connectionSettings)
      : this()
    {
      if (connectionSettings == null)
        throw new ArgumentNullException("connectionSettings");

      this.ConnectionSettings = connectionSettings;
      databaseNameTextBox.Text = connectionSettings.UserName;
      userNameTextBox.Text = connectionSettings.UserName;
      passwordTextBox.Text = connectionSettings.Password;
    }

    public VssConnectionSettings ConnectionSettings { get; set; }

    #endregion  Public Constructors

    #region  Protected Overridden Methods

    #endregion  Protected Overridden Methods

    #region  Event Handlers

    private void browseDatabaseButton_Click(object sender, EventArgs e)
    {
      openFileDialog.FileName = databaseNameTextBox.Text;
      if (openFileDialog.ShowDialog(this) == DialogResult.OK)
        databaseNameTextBox.Text = openFileDialog.FileName;
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void okButton_Click(object sender, EventArgs e)
    {
      this.ConnectionSettings.Database = databaseNameTextBox.Text;
      this.ConnectionSettings.UserName = userNameTextBox.Text;
      this.ConnectionSettings.Password = passwordTextBox.Text;

      DialogResult = DialogResult.OK;
    }

    #endregion  Event Handlers

    private void testButton_Click(object sender, EventArgs e)
    {
      Exception ex;

      if (VssUtilities.TestConnection(databaseNameTextBox.Text, userNameTextBox.Text, passwordTextBox.Text, out ex))
        MessageBox.Show("Connection succeeded.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
      else
        MessageBox.Show(string.Format("Connection failed. {0}", ex.Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }
  }
}
