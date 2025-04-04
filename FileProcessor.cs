using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace TextFileCorrector
{
  public class FileProcessor
  {
    private readonly Dictionary<string, string> _wordCorrections;
    private readonly Regex _phoneRegex;

    public FileProcessor(Dictionary<string, string> wordCorrections)
    {
      _wordCorrections = wordCorrections ?? 
        throw new ArgumentNullException(nameof(wordCorrections));
      
      _phoneRegex = new Regex(
        @"\((\d{3})\)\s(\d{3})-(\d{2})-(\d{2})", 
        RegexOptions.Compiled);
    }

    public void ProcessFilesInDirectory(string directoryPath)
    {
      string[] textFiles = Directory.GetFiles(directoryPath, "*.txt");
      
      foreach (string filePath in textFiles)
      {
        ProcessFile(filePath);
      }
    }

    private void ProcessFile(string filePath)
    {
      string originalContent = File.ReadAllText(filePath, Encoding.UTF8);
      string correctedContent = CorrectText(originalContent);
      
      if (originalContent != correctedContent)
      {
        File.WriteAllText(filePath, correctedContent, Encoding.UTF8);
      }
    }

    private string CorrectText(string text)
    {
      string result = text;
      
      foreach (var correction in _wordCorrections)
      {
        result = Regex.Replace(
          result, 
          $@"\b{correction.Key}\b", 
          correction.Value, 
          RegexOptions.IgnoreCase);
      }
      result = _phoneRegex.Replace(result, "+380 $1 $2 $3 $4");
      
      return result;
    }
  }
}
