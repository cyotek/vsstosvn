using System;

namespace Cyotek.SourceSafeSvnMigration
{
  public class ProgressEventArgs : EventArgs
  {
  #region  Public Constructors  

    public ProgressEventArgs(int percentComplete)
      : this(null, percentComplete)
    { }

    public ProgressEventArgs(string status)
      : this(status, 0)
    { }

    public ProgressEventArgs(string status, int percentComplete)
      : this()
    {
      this.Status = status;
      this.PercentComplete = percentComplete;
    }

  #endregion  Public Constructors  

  #region  Protected Constructors  

    protected ProgressEventArgs()
    { }

  #endregion  Protected Constructors  

  #region  Public Properties  

    public int PercentComplete { get; protected set; }

    public string Status { get; protected set; }

  #endregion  Public Properties  
  }
}
