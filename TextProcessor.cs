using System;
using System.Collections.Generic;
using System.IO;

namespace TextFix
{
  class TextProcessor
  {
    private Dictionary<string, string> _corrections = new()
    {
      {"првиет", "привет"}, {"пирвет", "привет"}
    };

    public void ProcessDirectory(string path)
    {
      foreach (var file in Directory.GetFiles(path, "*.txt"))
      {
        string text = File.ReadAllText(file);
        foreach (var c in _corrections) text = text.Replace(c.Key, c.Value);
        File.WriteAllText(file, text);
      }
    }
  }
}
