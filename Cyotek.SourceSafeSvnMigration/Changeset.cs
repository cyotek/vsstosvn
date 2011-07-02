using System;
using System.Collections.Generic;

namespace Cyotek.SourceSafeSvnMigration
{
  public class Changeset
  {
  #region  Public Constructors  

    public Changeset()
    {
      this.Files = new List<ChangesetFileInfo>();
    }

  #endregion  Public Constructors  

  #region  Public Properties  

    public string Comment { get; set; }

    public DateTime DateTime { get; set; }

    public List<ChangesetFileInfo> Files { get; set; }

    public string Username { get; set; }

  #endregion  Public Properties  
  }
}
