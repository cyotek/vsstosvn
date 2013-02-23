using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Cyotek.SourceSafeSvnMigration
{
  public partial class AboutDialog : BaseDialog
  {
  #region  Public Constructors  

    public AboutDialog()
    {
      InitializeComponent();
    }

  #endregion  Public Constructors  

  #region  Protected Overridden Methods  

    protected override void OnFontChanged(EventArgs e)
    {
      base.OnFontChanged(e);

      if (componentsListView != null)
        componentsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
    }

    protected override void OnLoad(EventArgs e)
    {
      Assembly assembly;
      string title;
      FileVersionInfo info;

      base.OnLoad(e);

      assembly = Assembly.GetEntryAssembly();
      title = Application.ProductName;
      info = FileVersionInfo.GetVersionInfo(assembly.Location);

      this.Text = string.Format("About {0}", title);
      nameLabel.Text = title;
      versionLabel.Text = string.Format("Version {0}", info.ProductVersion);
      copyrightLabel.Text = info.LegalCopyright;
	  copyrightLabel2.Text = "Copyright 2013, Damir Valiulin";
      webLinkLabel.Text = "http://cyotek.com/";
      webLinkLabel.Tag = webLinkLabel.Text;

      foreach (Assembly component in AppDomain.CurrentDomain.GetAssemblies())
      {
        if (!component.GlobalAssemblyCache)
        {
          try
          {
            ListViewItem item;
            FileVersionInfo versionInfo;

            item = new ListViewItem();
            versionInfo = FileVersionInfo.GetVersionInfo(component.Location);

            item.Text = versionInfo.FileDescription;
            item.SubItems.Add(versionInfo.FileVersion);
            item.SubItems.Add(versionInfo.CompanyName);
            item.ToolTipText = string.Concat(component.GetName().Name, Environment.NewLine, versionInfo.FileDescription, Environment.NewLine, Environment.NewLine, versionInfo.LegalCopyright);

            componentsListView.Items.Add(item);
          }
          catch
          { }
        }
      }

      componentsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
    }

  #endregion  Protected Overridden Methods  

  #region  Event Handlers  

    private void closeButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void webLinkLabel_Click(object sender, EventArgs e)
    {
      try
      {
        Process.Start(((Control)sender).Tag.ToString());
      }
      catch (Exception ex)
      {
        MessageBox.Show(string.Format("Unable to start the specified URI.\n\n{0}", ex.Message), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

  #endregion  Event Handlers  
  }
}
