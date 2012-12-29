using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms
{
  // Cyotek GroupBox Component
  // www.cyotek.com

  /// <summary>
  /// Represents a Windows control that displays a frame at the top of a group of controls with an optional caption and icon.
  /// </summary>
  [ToolboxItem(true)]
  [DefaultEvent("Click"), DefaultProperty("Text")]
  [Designer("System.Windows.Forms.Design.GroupBoxDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), Designer("System.Windows.Forms.Design.DocumentDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.ComponentModel.Design.IRootDesigner))]
  public partial class GroupBox : System.Windows.Forms.GroupBox
  {
    #region��Private�Member�Declarations

    //private SolidBrush _backgroundBrush;
    private Border3DSide _borders = Border3DSide.Top;
    private Pen _bottomPen;
    private Size _iconMargin;
    private Image _image;
    private Color _lineColorBottom;
    private Color _lineColorTop;
    private SolidBrush _textBrush;
    private Pen _topPen;

    #endregion��Private�Member�Declarations

    #region��Public�Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="GroupBox"/> class.
    /// </summary>
    public GroupBox()
    {
      _iconMargin = new Size(0, 6);
      _lineColorBottom = SystemColors.ButtonHighlight;
      _lineColorTop = SystemColors.ButtonShadow;

      this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw |
                    ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);

      this.CreateResources();
    }

    #endregion��Public�Constructors

    #region��Protected�Overridden�Methods

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.CleanUpResources();

      base.Dispose(disposing);
    }

    /// <summary>
    /// Occurs when the control is to be painted.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
    protected override void OnPaint(PaintEventArgs e)
    {
      SizeF size;
      int y;

      size = e.Graphics.MeasureString(this.Text, this.Font);
      y = (int)(size.Height + 3) / 2;

      if ((_borders & Border3DSide.All) == Border3DSide.All)
      {
        e.Graphics.DrawRectangle(_bottomPen, 1, y + 1, this.Width - 2, this.Height - (y + 2));
        e.Graphics.DrawRectangle(_topPen, 0, y, this.Width - 2, this.Height - (y + 2));
      }
      else
      {
        if ((_borders & Border3DSide.Top) == Border3DSide.Top)
        {
          e.Graphics.DrawLine(_topPen, size.Width + 3, y, this.Width - 5, y);
          e.Graphics.DrawLine(_bottomPen, size.Width + 3, y + 1, this.Width - 5, y + 1);
        }

        if ((_borders & Border3DSide.Left) == Border3DSide.Left)
        {
          e.Graphics.DrawLine(_topPen, 0, y, 0, this.Height - 1);
          e.Graphics.DrawLine(_bottomPen, 1, y, 1, this.Height - 1);
        }

        if ((_borders & Border3DSide.Right) == Border3DSide.Right)
        {
          e.Graphics.DrawLine(_bottomPen, this.Width - 1, y, this.Width - 1, this.Height - 1);
          e.Graphics.DrawLine(_topPen, this.Width - 2, y, this.Width - 2, this.Height - 1);
        }

        if ((_borders & Border3DSide.Bottom) == Border3DSide.Bottom)
        {
          e.Graphics.DrawLine(_topPen, 0, this.Height - 2, this.Width, this.Height - 2);
          e.Graphics.DrawLine(_bottomPen, 0, this.Height - 1, this.Width, this.Height - 1);
        }
      }

      // header text
      //e.Graphics.FillRectangle(_backgroundBrush, 1, 1, size.Width, size.Height);
      e.Graphics.DrawString(this.Text, this.Font, _textBrush, 1, 1);

      // draw the image
      if ((_image != null))
        e.Graphics.DrawImage(_image, this.Padding.Left + _iconMargin.Width, this.Padding.Top + (int)size.Height + _iconMargin.Height, _image.Width, _image.Height);

      //draw a designtime outline
      if (this.DesignMode && !((_borders & Border3DSide.All) == Border3DSide.All))
      {
        Pen pen;
        pen = new Pen(SystemColors.ButtonShadow);
        pen.DashStyle = DashStyle.Dot;
        e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
        pen.Dispose();
      }
    }

    /// <summary>
    /// Raises the <see cref="System.Windows.Forms.Control.SystemColorsChanged"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
    protected override void OnSystemColorsChanged(EventArgs e)
    {
      base.OnSystemColorsChanged(e);

      this.CreateResources();
      this.Invalidate();
    }

    #endregion��Protected�Overridden�Methods

    #region��Public�Properties

    [Category("Appearance")]
    [DefaultValue(typeof(Border3DSide), "Top")]
    public Border3DSide Borders
    {
      get { return _borders; }
      set
      {
        _borders = value;
        this.Invalidate();
      }
    }

    /// <summary>
    /// Gets a rectangle that represents the dimensions of the <see cref="T:System.Windows.Forms.GroupBox"/>.
    /// </summary>
    /// <value></value>
    /// <returns>
    /// A <see cref="T:System.Drawing.Rectangle"/> with the dimensions of the <see cref="T:System.Windows.Forms.GroupBox"/>.
    /// </returns>
    public override Rectangle DisplayRectangle
    {
      get
      {
        Size clientSize;
        int fontHeight;
        int imageSize;

        clientSize = base.ClientSize;
        fontHeight = this.Font.Height;

        if (_image != null)
          imageSize = _iconMargin.Width + _image.Width + 3;
        else
          imageSize = 0;

        return new Rectangle(3 + imageSize, fontHeight + 3, Math.Max(clientSize.Width - (imageSize + 6), 0), Math.Max((clientSize.Height - fontHeight) - 6, 0));
      }
    }

    /// <summary>
    /// Gets or sets the icon margin.
    /// </summary>
    /// <value>The icon margin.</value>
    [Category("Appearance"), DefaultValue(typeof(Size), "0, 6")]
    public Size IconMargin
    {
      get { return _iconMargin; }
      set
      {
        _iconMargin = value;
        this.Invalidate();
      }
    }

    /// <summary>
    /// Gets or sets the image to display.
    /// </summary>
    /// <value>The image to display.</value>
    [Browsable(true), Category("Appearance"), DefaultValue(typeof(Image), "")]
    public Image Image
    {
      get { return _image; }
      set
      {
        _image = value;
        this.Invalidate();
      }
    }

    /// <summary>
    /// Gets or sets the line color bottom.
    /// </summary>
    /// <value>The line color bottom.</value>
    [Browsable(true), Category("Appearance"), DefaultValue(typeof(Color), "ButtonHighlight")]
    public Color LineColorBottom
    {
      get { return _lineColorBottom; }
      set
      {
        _lineColorBottom = value;
        this.CreateResources();
        this.Invalidate();
      }
    }

    /// <summary>
    /// Gets or sets the line color top.
    /// </summary>
    /// <value>The line color top.</value>
    [Browsable(true), Category("Appearance"), DefaultValue(typeof(Color), "ButtonShadow")]
    public Color LineColorTop
    {
      get { return _lineColorTop; }
      set
      {
        _lineColorTop = value;
        this.CreateResources();
        this.Invalidate();
      }
    }

    /// <summary>
    /// Returns or sets the text displayed in this control.
    /// </summary>
    /// <value></value>
    /// <returns>
    /// The text associated with this control.
    /// </returns>
    [Browsable(true), DefaultValue("")]
    public override string Text
    {
      get { return base.Text; }
      set
      {
        base.Text = value;
        this.Invalidate();
      }
    }

    #endregion��Public�Properties

    #region��Private�Methods

    /// <summary>
    /// Cleans up GDI resources.
    /// </summary>
    private void CleanUpResources()
    {
      if (_topPen != null)
        _topPen.Dispose();

      if (_bottomPen != null)
        _bottomPen.Dispose();

      if (_textBrush != null)
        _textBrush.Dispose();

      //if (_backgroundBrush != null)
      //  _backgroundBrush.Dispose();
    }

    /// <summary>
    /// Creates GDI resources.
    /// </summary>
    private void CreateResources()
    {
      this.CleanUpResources();

      _topPen = new Pen(_lineColorTop);
      _bottomPen = new Pen(_lineColorBottom);
      _textBrush = new SolidBrush(this.ForeColor);
      //_backgroundBrush = new SolidBrush(this.BackColor);
    }

    #endregion��Private�Methods
  }
}
