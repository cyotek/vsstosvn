using System;
using System.IO;
using SourceSafeTypeLib;

namespace Cyotek.SourceSafeSvnMigration
{
  public static class VssUtilities
  {
  #region  Public Class Methods  

    public static bool DoesProjectContainSubProjects(IVSSItem project)
    {
      bool result;

      if (project == null)
        throw new ArgumentNullException("project");

      if (!project.IsProject())
        throw new ArgumentException("project");

      result = false;

      foreach (IVSSItem childItem in project.Items)
      {
        if (childItem.IsProject())
        {
          result = true;
          break;
        }
      }

      return result;
    }

    public static string GetLocalPath(string path, IVSSItem vssFile, Int32 num_chars_to_chop_in_vss_path)
    {
      string specPath = vssFile.Spec.Substring(num_chars_to_chop_in_vss_path);

	  specPath = specPath.Replace("/", @"\");
      if (specPath.StartsWith(@"\"))
        specPath = specPath.Substring(1, specPath.Length - 1);

      return Path.Combine(path, specPath);
    }

    public static bool IsFileCheckedOut(this IVSSItem item)
    {
      return (item.IsCheckedOut != (int)VSSFileStatus.VSSFILE_NOTCHECKEDOUT);
    }

    public static bool IsProject(this IVSSItem item)
    {
      return (item.Type == (int)VSSItemType.VSSITEM_PROJECT);
    }

    public static VSSDatabase OpenDatabase(string database, string username, string password)
    {
      VSSDatabase ssDatabase;

      if (!string.IsNullOrEmpty(database) && !database.ToLower().EndsWith("srcsafe.ini"))
        database = Path.Combine(database, "srcsafe.ini");

      ssDatabase = new VSSDatabase();
      ssDatabase.Open(string.IsNullOrEmpty(database) ? null : database, string.IsNullOrEmpty(username) ? null : username, string.IsNullOrEmpty(password) ? null : password);

      return ssDatabase;
    }

    public static VSSDatabase OpenDatabase(VssConnectionSettings connectionSettings)
    {
      if (connectionSettings == null)
        throw new ArgumentNullException("connectionSettings");

      return VssUtilities.OpenDatabase(connectionSettings.Database, connectionSettings.UserName, connectionSettings.Password);
    }

    public static bool TestConnection(VssConnectionSettings connectionSettings)
    {
      Exception ex;

      return VssUtilities.TestConnection(connectionSettings, out ex);
    }

    public static bool TestConnection(VssConnectionSettings connectionSettings, out Exception ex)
    {
      if (connectionSettings == null)
        throw new ArgumentNullException("connectionSettings");

      return VssUtilities.TestConnection(connectionSettings.Database, connectionSettings.UserName, connectionSettings.Password, out ex);
    }

    public static bool TestConnection(string database, string username, string password)
    {
      Exception ex;

      return VssUtilities.TestConnection(database, username, password, out ex);
    }

    public static bool TestConnection(string database, string username, string password, out Exception ex)
    {
      VSSDatabase ssDatabase;

      ssDatabase = null;
      ex = null;

      try
      {
        ssDatabase = VssUtilities.OpenDatabase(database, username, password);
        ssDatabase.Close();
      }
      catch (Exception e)
      {
        ex = e;
      }

      return ssDatabase != null;
    }

  #endregion  Public Class Methods  
  }
}
