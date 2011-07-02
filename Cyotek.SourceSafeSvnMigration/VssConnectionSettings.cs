using System;
using System.ComponentModel;

namespace Cyotek.SourceSafeSvnMigration
{
  [Serializable]
  [TypeConverter(typeof(ExpandableObjectConverter))]
  public class VssConnectionSettings
  {
  #region  Public Properties  

    public string Database { get; set; }

    public string Password { get; set; }

    public string UserName { get; set; }

  #endregion  Public Properties  
  }
}
