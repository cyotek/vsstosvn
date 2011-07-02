using System;

namespace Cyotek.SourceSafeSvnMigration
{
  class Program
  {
  #region  Private Class Methods  

    // Icon still life terminal icon (http://www.iconfinder.com/icondetails/22281/128/)
    static void Main(string[] args)
    {
      CommandLineParser commandLine;

      // example command line
      //    /vssdb=C:\SourceSafe\ImportTest1 /vssproject=$/ /svnrepo=https://JUPITER/svn/cyoteklegacy/ /svnfolder=C:\Repositories\cyoteklegacy /temppath=C:\temp\_migrate

      commandLine = new CommandLineParser();
      if (commandLine.AsBoolean("help") || commandLine.AsBoolean("h") || commandLine.AsBoolean("?"))
      {
        Console.WriteLine("SourceSafe to Subversion Migration\n");
        Console.WriteLine("Usage:");
        Console.WriteLine("vsssvn [[settingsfilename] | [options]]\n");
        Console.WriteLine("Options:");
        Console.WriteLine("vssdb\t\tVisual SourceSafe database");
        Console.WriteLine("vssuser\t\tSourceSafe login username");
        Console.WriteLine("vsspassword\tSourceSafe login password");
        Console.WriteLine("svnrepo\t\tSubversion repository URI");
        Console.WriteLine("svnuser\t\tSubversion login username");
        Console.WriteLine("svnpassword\tSubversion login password");
        Console.WriteLine("svnfolder\tSubversion repository local folder");
        Console.WriteLine("svnproject\tRoot project to import into");
        Console.WriteLine("vssproject\tSourceSafe project to import. May be specified multiple times.");
        Console.WriteLine("subfolders\tSpecifies if the sub projects of vssproject arguments are");
        Console.WriteLine("\t\tautomatically included in the import.");
        Console.WriteLine("revprops\tSpecifies if Subversion revision properties should be modified");
        Console.WriteLine("removebindings\tSpecifies if SourceSafe bindings should be removed");
        Console.WriteLine("preview\t\tPreviews actions without performing an actual migration");
        Console.WriteLine("temppath\tFolder where the working copy is created");
      }
      else
      {
        VssMigration migration;

        migration = VssMigration.LoadFromCommandLine();
        migration.Log += migration_Log;

        if (commandLine.AsBoolean("preview"))
          migration.Preview();
        else
          migration.Migrate();
      }

#if DEBUG
      Console.ReadKey(true);
#endif
    }

    static void migration_Log(object sender, LogEventArgs e)
    {
      if (!string.IsNullOrEmpty(e.Message))
        Console.WriteLine(e.Message);

      if (e.Exception != null)
        Console.WriteLine(e.Exception.Message);
    }

  #endregion  Private Class Methods  
  }
}
