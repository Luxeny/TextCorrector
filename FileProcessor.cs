using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace TextFileCorrector
{
  public class FileProcessor
  {
    private readonly Dictionary<string, string> _corrections;
    private readonly Regex _phoneRegex = new Regex(
      @"\((\d{3})\)\s(\d{3})-(\d{2})-(\d{2})", 
      RegexOptions.Compiled);

    public FileProcessor(Dictionary<string, string> corrections)
    {
      _corrections = corrections ?? throw new ArgumentNullException(nameof(corrections));
    }

    public void ProcessFilesInDirectory(string directoryPath)
    {
      if (!Directory.Exists(directoryPath))
        throw new DirectoryNotFoundException("Директория не найдена");

      foreach (var filePath in Directory.GetFiles(directoryPath, "*.txt"))
      {
        ProcessTextFile(filePath);
      }
    }

    private void ProcessTextFile(string filePath)
    {
      string content = File.ReadAllText(filePath, Encoding.UTF8);
      string correctedContent = ApplyCorrections(content);

      if (content != correctedContent)
      {
        File.WriteAllText(filePath, correctedContent, Encoding.UTF8);
      }
    }

    private string ApplyCorrections(string text)
    {
      foreach (var correction in _corrections)
      {
        text = Regex.Replace(text, $@"\b{Regex.Escape(correction.Key)}\b", 
          correction.Value, RegexOptions.IgnoreCase);
      }

      return _phoneRegex.Replace(text, "+380 $1 $2 $3 $4");
    }
  }
}
