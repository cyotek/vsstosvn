using System;

namespace Cyotek.SourceSafeSvnMigration
{
  public class LogEventArgs : EventArgs
  {
  #region  Public Constructors  

    public LogEventArgs(string message)
      : this(default(Exception), message)
    { }

    public LogEventArgs(Exception exception)
      : this(exception, null)
    { }

    public LogEventArgs(Exception exception, string message)
      : this()
    {
      this.Exception = exception;
      this.Message = message;
    }

    public LogEventArgs(string format, object[] args)
      : this(string.Format(format, args))
    { }

  #endregion  Public Constructors  

  #region  Protected Constructors  

    protected LogEventArgs()
    { }

  #endregion  Protected Constructors  

  #region  Public Properties  

    public Exception Exception { get; set; }

    public string Message { get; protected set; }

  #endregion  Public Properties  
  }
}
