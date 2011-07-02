using SourceSafeTypeLib;

namespace Cyotek.SourceSafeSvnMigration
{
  public class ChangesetFileInfo
  {
  #region  Public Properties  

    public string FilePath { get; set; }

    public bool IsAdd { get; set; }

    public IVSSItem VssFile  { get; set; }

    public IVSSVersion VssVersion  { get; set; }

  #endregion  Public Properties  
  }
}