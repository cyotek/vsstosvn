using SharpSvn;

namespace Cyotek.SourceSafeSvnMigration
{
  public static class SvnUtilities
  {
  #region  Public Class Methods  

    public static SvnClient CreateClient(SvnConnectionSettings connectionSettings)
    {
      SvnClient client;

      client = new SvnClient();
      client.Authentication.DefaultCredentials = new SvnCredentialProvider(connectionSettings.UserName, connectionSettings.Password);

      return client;
    }

  #endregion  Public Class Methods  
  }
}
