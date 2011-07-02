using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cyotek.SourceSafeSvnMigration
{
  public class SvnRevProps
  {
  #region  Private Class Member Declarations  

    private static readonly int _utcOffset;

  #endregion  Private Class Member Declarations  

  #region  Public Member Declarations  

    public List<KeyValuePair<string, string>> Pairs = new List<KeyValuePair<string, string>>();

  #endregion  Public Member Declarations  

  #region  Private Member Declarations  

    private readonly string _filePath;

  #endregion  Private Member Declarations  

  #region  Static Constructors  

    static SvnRevProps()
    {
      _utcOffset = (int)DateTime.UtcNow.Subtract(DateTime.Now).TotalHours;
    }

  #endregion  Static Constructors  

  #region  Public Constructors  

    public SvnRevProps(string fileName)
    {
      if (string.IsNullOrEmpty(fileName))
      {
        throw new ArgumentException("Can't be null or Empty", "fileName");
      }
      if (!File.Exists(fileName))
      {
        throw new FileNotFoundException("Svn props file", fileName);
      }
      _filePath = fileName;
      using (var stream = File.OpenRead(_filePath))
      {
        KeyValuePair<string, string> pair;
        string header = GetHeader(stream);
        while (!string.IsNullOrEmpty(header) && header != "END")
        {
          string[] headerParts = header.Split((char)0x20);
          int textChars = int.Parse(headerParts[1]);
          string k = GetText(stream, textChars);
          if (10 != stream.ReadByte())
          {
            throw new Exception("Error reading SvnRevProps file");
          }
          header = GetHeader(stream);
          headerParts = header.Split((char)0x20);
          textChars = int.Parse(headerParts[1]);
          string v = GetText(stream, textChars);
          if (10 != stream.ReadByte())
          {
            throw new Exception("Error reading SvnRevProps file");
          }
          pair = new KeyValuePair<string, string>(k, v);
          Pairs.Add(pair);
          header = GetHeader(stream);
        }
      }
    }

  #endregion  Public Constructors  

  #region  Public Methods  

    public void Save()
    {
      using (var stream = File.Open(_filePath, FileMode.Open, FileAccess.Write))
      {
        foreach (var pair in Pairs)
        {
          WriteText(stream, "K {0}", pair.Key);
          WriteText(stream, "V {0}", pair.Value);
        }
        WriteText(stream, "END");
      }
    }

    public void SetAuthor(string author)
    {
      SetPropertyValue("svn:author", author);
    }

    public void SetDate(DateTime date)
    {
      //2008-10-22T04:50:56.056632Z
      string dateString = date.AddHours(_utcOffset).ToString("s") + ".000000Z";
      SetPropertyValue("svn:date", dateString);
    }

  #endregion  Public Methods  

  #region  Private Methods  

    private string GetHeader(Stream stream)
    {
      var sb = new StringBuilder();
      byte b;
      while ((b = (byte)stream.ReadByte()) != 0x0A)
      {
        sb.Append(Encoding.Default.GetChars(new[] { b }));
      }
      return sb.ToString();
    }

    private KeyValuePair<string, string> GetPair(string key)
    {
      foreach (var pair in Pairs)
      {
        if (string.Compare(pair.Key, key, false) == 0)
        {
          return pair;
        }
      }
      throw new ArgumentOutOfRangeException("key", string.Format("Couldn't find key {0}", key));
    }

    private string GetText(Stream stream, int textChars)
    {
      var bytes = new byte[textChars];
      var buffer = new byte[textChars];
      int totalRead = 0;
      int bytesRead;
      while (totalRead < textChars && 0 != (bytesRead = stream.Read(buffer, 0, buffer.Length)))
      {
        Array.Copy(buffer, 0, bytes, totalRead, bytesRead);
        totalRead += bytesRead;
      }
      return Encoding.Default.GetString(bytes);
    }

    private void SetPropertyValue(string key, string value)
    {
      KeyValuePair<string, string> pair = GetPair(key);
      int index = Pairs.IndexOf(pair);
      Pairs.Remove(pair);
      Pairs.Insert(index, new KeyValuePair<string, string>(key, value));
    }

    private void WriteText(Stream stream, string headerFormat, string text)
    {
      string header = string.Format(headerFormat, text.Length);
      WriteText(stream, header);
      WriteText(stream, text);
    }

    private void WriteText(Stream stream, string text)
    {
      byte[] bytes = Encoding.Default.GetBytes(text);
      stream.Write(bytes, 0, bytes.Length);
      stream.WriteByte(0x0A);
    }

  #endregion  Private Methods  
  }
}
