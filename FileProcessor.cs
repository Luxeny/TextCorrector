using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextCorrector
{
  static class FileProcessor
  {
    public static void ProcessFolder(string folderPath, 
                                   Dictionary<string, string> corrections)
    {
      if (!Directory.Exists(folderPath))
        throw new DirectoryNotFoundException("Папка не найдена");

      foreach (string filePath in Directory.GetFiles(folderPath, "*.txt"))
      {
        ProcessFile(filePath, corrections);
      }
    }

    private static void ProcessFile(string filePath, 
                                  Dictionary<string, string> corrections)
    {
      string content = File.ReadAllText(filePath, Encoding.UTF8);
      string corrected = ApplyCorrections(content, corrections);
      
      if (content != corrected)
      {
        File.WriteAllText(filePath, corrected, Encoding.UTF8);
      }
    }

    private static string ApplyCorrections(string text, 
                                        Dictionary<string, string> corrections)
    {
      foreach (var pair in corrections)
      {
        text = text.Replace(pair.Key, pair.Value);
      }
      return text;
    }
  }
}
