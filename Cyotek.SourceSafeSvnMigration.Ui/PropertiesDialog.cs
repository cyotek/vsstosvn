using System;

namespace Cyotek.SourceSafeSvnMigration
{
  public partial class PropertiesDialog : BaseDialog
  {
  #region  Public Constructors  

    public PropertiesDialog()
    {
      InitializeComponent();
    }

    public PropertiesDialog(object propertiesObject)
      : this()
    {
      propertyGrid.SelectedObject = propertiesObject;
    }

  #endregion  Public Constructors  

  #region  Event Handlers  

    private void closeButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

  #endregion  Event Handlers  
  }
}
