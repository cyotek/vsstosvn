using System;
using System.Net;

namespace Cyotek.SourceSafeSvnMigration
{
  public class SvnCredentialProvider : ICredentials
  {
  #region  Private Member Declarations  

    private readonly NetworkCredential _credential;

  #endregion  Private Member Declarations  

  #region  Public Constructors  

    public SvnCredentialProvider(string userName, string password)
    {
      _credential = new NetworkCredential(userName, password);
    }

  #endregion  Public Constructors  

  #region  Public Methods  

    public NetworkCredential GetCredential(Uri uri, string authType)
    {
      return _credential;
    }

  #endregion  Public Methods  
  }
}
