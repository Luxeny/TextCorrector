using System;
using System.Collections.Generic;

namespace TextCorrector
{
  class Program
  {
    private static readonly Dictionary<string, string> s_correctionDictionary = 
      new Dictionary<string, string>
      {
        {"првиет", "привет"},
        {"пирвет", "привет"},
        {"превед", "привет"},
        {"здарова", "здравствуйте"}
      };

    static void Main(string[] args)
    {
      Console.WriteLine("Введите путь к папке с файлами:");
      string folderPath = Console.ReadLine();

      try
      {
        FileProcessor.ProcessFolder(folderPath, s_correctionDictionary);
        Console.WriteLine("Обработка завершена успешно!");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Ошибка: {ex.Message}");
      }
      
      Console.ReadKey();
    }
  }
}
