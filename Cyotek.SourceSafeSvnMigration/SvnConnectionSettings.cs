using System;
using System.ComponentModel;

namespace Cyotek.SourceSafeSvnMigration
{
  [Serializable]
  [TypeConverter(typeof(ExpandableObjectConverter))]
  public class SvnConnectionSettings
  {
  #region  Public Properties  

    public string LocalFolderName { get; set; }

    public string Password { get; set; }

    public string RepositoryUri { get; set; }

    public string UserName { get; set; }

  #endregion  Public Properties  
  }
}
