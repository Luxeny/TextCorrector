using System;
using System.Collections.Generic;
using System.IO;

namespace TextFileCorrector
{
  public class Program
  {
    private static readonly Dictionary<string, string> s_wordCorrections = 
      new Dictionary<string, string>()
      {
        {"првиет", "привет"},
        {"пирвет", "привет"},
        {"превед", "привет"},
        {"здарова", "здравствуйте"},
        {"здраствуйте", "здравствуйте"},
        {"извеняюсь", "извиняюсь"},
        {"абаза", "обязательно"},
        {"пасиб", "спасибо"},
        {"спс", "спасибо"}
      };

    public static void Main(string[] args)
    {
      string directoryPath;
      
      if (args.Length == 0)
      {
        Console.WriteLine("Введите путь к директории с файлами для обработки:");
        directoryPath = Console.ReadLine();
      }
      else
      {
        directoryPath = args[0];
      }
      
      if (!Directory.Exists(directoryPath))
      {
        Console.WriteLine("Указанная директория не существует");
        return;
      }

      var fileProcessor = new FileProcessor(s_wordCorrections);
      fileProcessor.ProcessFilesInDirectory(directoryPath);
      
      Console.WriteLine("Обработка файлов завершена");
    }
  }
}
