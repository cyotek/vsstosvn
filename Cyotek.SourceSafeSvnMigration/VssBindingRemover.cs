using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Cyotek.SourceSafeSvnMigration
{
  /// <summary>
  /// Strip out the VSS bindings from the solution and project files
  /// Significant code reuse from mcarbenay's project on CodeProject
  /// http://www.codeproject.com/KB/dotnet/RemoveSCCInfo.aspx 
  /// </summary>
  public class VssBindingRemover
  {
  #region  Private Class Member Declarations  

    private static readonly Regex _vs2003ProjRegex = new Regex(
        "Scc\\w*\\s*=\\s*'*\\\".*",
        RegexOptions.IgnoreCase
        | RegexOptions.Multiline
        | RegexOptions.CultureInvariant
        | RegexOptions.Compiled
        );
    private static readonly Regex _vs2005ProjRegex = new Regex(
        "\\<Scc\\w*\\>\\w*\\</Scc\\w*\\>.*",
        RegexOptions.IgnoreCase
        | RegexOptions.Multiline
        | RegexOptions.CultureInvariant
        | RegexOptions.Compiled
        );

  #endregion  Private Class Member Declarations  

  #region  Public Class Methods  

    /// <summary>
    /// Will remove all of the VSS bindings from Soluition and Project files.
    /// All other files are ignored since they don't have VSS bindings.
    /// </summary>
    /// <param name="filePath">Path to the file.</param>
    public static void RemoveBindings(string filePath)
    {
      if (Path.GetExtension(filePath).Contains("sln"))
      {
        PatchSolutionFile(filePath);
      }

      if (Path.GetExtension(filePath).Contains("proj"))
      {
        PatchProjectFile(filePath);
      }
    }

  #endregion  Public Class Methods  

  #region  Private Class Methods  

    private static void PatchProjectFile(string fileName)
    {
      var tempFileName = Path.GetDirectoryName(fileName) + @"\old-scc-remove-" + Path.GetFileName(fileName);

      try
      {
        File.Move(fileName, tempFileName);
        RemoveReadOnlyOnFile(tempFileName);

        var reader = new StreamReader(tempFileName, Encoding.Default);
        var fileContents = reader.ReadToEnd();
        reader.Close();

        var writer = new StreamWriter(fileName, false, Encoding.Default);
        writer.Write(UpdateProjFiles(fileContents));
        writer.Close();
      }
      finally
      {
        if (File.Exists(tempFileName))
        {
          File.Delete(tempFileName);
        }
      }
    }

    private static void PatchSolutionFile(string fileName)
    {
      var tempFileName = Path.GetDirectoryName(fileName) + @"\old-scc-remove-" + Path.GetFileName(fileName);
      var suoFileName = Path.ChangeExtension(fileName, ".suo");

      try
      {
        if (File.Exists(suoFileName))
        {
          RemoveReadOnlyOnFile(suoFileName);
          File.Delete(suoFileName);
        }

        File.Move(fileName, tempFileName);
        RemoveReadOnlyOnFile(tempFileName);

        // create a new .sln file with every non scc-related 
        // info from the old .sln
        // DO NOT use File.Open for it may not open the file with the correct
        // encoding.
        var reader = new StreamReader(tempFileName, Encoding.Default);
        var writer = new StreamWriter(fileName, false, Encoding.Default);
        var inSectionSCC = false;
        var currLine = reader.ReadLine();
        while (currLine != null)
        {
          if (currLine.Trim() == "GlobalSection(SourceCodeControl) = preSolution")
          {
            inSectionSCC = true;
          }
          else
          {
            if (!inSectionSCC)
            {
              writer.WriteLine(currLine);
            }
            else
            {
              if (currLine.Trim() == "EndGlobalSection")
              {
                inSectionSCC = false;
              }
            }
          }

          currLine = reader.ReadLine();
        }
        reader.Close();
        writer.Close();
      }
      finally
      {
        if (File.Exists(tempFileName))
        {
          File.Delete(tempFileName);
        }
      }
    }

    private static void RemoveReadOnlyOnFile(string path)
    {
      var attributes = File.GetAttributes(path);
      if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
      {
        File.SetAttributes(path, attributes & (~FileAttributes.ReadOnly));
      }
    }

    private static string UpdateProjFiles(string fileContents)
    {
      return _vs2003ProjRegex.IsMatch(fileContents)
                 ? _vs2003ProjRegex.Replace(fileContents, string.Empty)
                 : _vs2005ProjRegex.Replace(fileContents, string.Empty);
    }

  #endregion  Private Class Methods  
  }
}
