using System.ComponentModel;
using System.Windows.Forms;

namespace Cyotek.SourceSafeSvnMigration
{
  public partial class BaseDialog : BaseForm
  {
  #region  Public Constructors  

    public BaseDialog()
    {
      InitializeComponent();
    }

  #endregion  Public Constructors  

  #region  Public Properties  

    [DefaultValue(typeof(FormBorderStyle), "FixedDialog"), Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new FormBorderStyle FormBorderStyle
    {
      get { return base.FormBorderStyle; }
      set { base.FormBorderStyle = value; }
    }

    [DefaultValue(false), Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new bool MaximizeBox
    {
      get { return base.MaximizeBox; }
      set { base.MaximizeBox = value; }
    }

    [DefaultValue(false), Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new bool MinimizeBox
    {
      get { return base.MinimizeBox; }
      set { base.MinimizeBox = value; }
    }

    [DefaultValue(false), Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new bool ShowIcon
    {
      get { return base.ShowIcon; }
      set { base.ShowIcon = value; }
    }

    [DefaultValue(false), Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new bool ShowInTaskbar
    {
      get { return base.ShowInTaskbar; }
      set { base.ShowInTaskbar = value; }
    }

    [DefaultValue(typeof(FormStartPosition), "CenterParent"), Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new FormStartPosition StartPosition
    {
      get { return base.StartPosition; }
      set { base.StartPosition = value; }
    }

  #endregion  Public Properties  
  }
}
