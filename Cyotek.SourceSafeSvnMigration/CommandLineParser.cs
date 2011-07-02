using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Cyotek.SourceSafeSvnMigration
{
  // Based on code from http://www.codeproject.com/KB/recipes/command_line.aspx
  
  public class CommandLineParser : Dictionary<string, object>
  {
  #region  Public Constructors  

    public CommandLineParser()
      : this(string.Empty)
    { }

    public CommandLineParser(string defaultName)
      : this(CommandLineParser.DefaultArguments, defaultName)
    { }

    public CommandLineParser(string[] args)
      : this(args, string.Empty)
    { }

    public CommandLineParser(string[] args, string defaultName)
    {
      Regex remover;

      remover = new Regex(@"^['""]?(.*?)['""]?$", RegexOptions.IgnoreCase);

      for (int i = 0; i < args.Length; i++)
      {
        string arg;

        arg = args[i];

        if (arg.StartsWith("/") || arg.StartsWith("-"))
        {
          arg = arg.Substring(1);

          // named parameter
          int valueIndex;

          valueIndex = arg.IndexOf("=");
          if (valueIndex == -1)
          {
            // flag
            this[arg] = true.ToString();
          }
          else
          {
            // value
            string value;
            string name;

            name = arg.Substring(0, valueIndex);
            value = remover.Replace(arg.Substring(valueIndex + 1), "$1");

            this.SetNamedValue(name, value);
          }
        }
        else
        {
          // default parameter
          arg = remover.Replace(arg, "$1");

          this.SetNamedValue(defaultName, arg);
        }
      }

    }

  #endregion  Public Constructors  

  #region  Public Class Properties  

    public static string[] DefaultArguments
    {
      get
      {
        List<string> arguments;
        string[] commandLine;

        commandLine = Environment.GetCommandLineArgs();
        arguments = new List<string>();

        for (int i = 1; i < commandLine.Length; i++)
          arguments.Add(commandLine[i]);

        return arguments.ToArray();
      }
    }

  #endregion  Public Class Properties  

  #region  Public Methods  

    public bool AsBoolean(string name)
    {
      return this.AsBoolean(name, false);
    }

    public bool AsBoolean(string name, bool defaultValue)
    {
      if (this.ContainsKey(name))
        return Convert.ToBoolean(this[name]);
      else
        return defaultValue;
    }

    public int AsInteger(string name)
    {
      return this.AsInteger(name, 0);
    }

    public int AsInteger(string name, int defaultValue)
    {
      if (this.ContainsKey(name))
        return Convert.ToInt32(this[name]);
      else
        return defaultValue;
    }

    public string AsString(string name)
    {
      return this.AsString(name, string.Empty);
    }

    public string AsString(string name, string defaultValue)
    {
      if (this.ContainsKey(name))
        return this[name].ToString();
      else
        return defaultValue;
    }

    public string[] AsStringList(string name)
    {
      List<string> results;

      if (this[name] is List<string>)
        results = (List<string>)this[name];
      else
      {
        results = new List<string>();
        results.Add(this.AsString(name));
      }

      return results.ToArray();
    }

    public bool ContainsKeys(params string[] keys)
    {
      bool result;

      result = false;
      foreach (string key in keys)
        if (this.ContainsKey(key))
        {
          result = true;
          break;
        }

      return result;
    }

    public bool HasValue(string key)
    {
      return this.ContainsKey(key) && this[key] != null && !string.IsNullOrEmpty(this[key].ToString());
    }

  #endregion  Public Methods  

  #region  Private Methods  

    private void SetNamedValue(string name, string value)
    {
      if (this.ContainsKey(name))
      {
        if (this[name] is List<string>)
          ((List<string>)this[name]).Add(value);
        else
        {
          List<string> values;

          values = new List<string>();
          values.Add(this[name].ToString());
          values.Add(value);
          this[name] = values;
        }
      }
      else
        this.Add(name, value);
    }

  #endregion  Private Methods  
  }
}