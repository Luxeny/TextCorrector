using System;
using System.Collections.Generic;
using System.IO;

namespace TextFileCorrector
{
  public class Program
  {
    public static void Main()
    {
      var wordCorrections = GetUserCorrections();
      string directoryPath = GetDirectoryPath();

      try
      {
        FileProcessor.ProcessFolder(directoryPath, wordCorrections);
        Console.WriteLine("\nОбработка завершена успешно!");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"\nОшибка: {ex.Message}");
      }
      
      Console.WriteLine("\nНажмите любую клавишу...");
      Console.ReadKey();
    }

    private static string GetDirectoryPath()
    {
      Console.WriteLine("\nВведите путь к директории с файлами:");
      return Console.ReadLine();
    }

    private static Dictionary<string, string> GetUserCorrections()
    {
      var corrections = new Dictionary<string, string>();
      Console.WriteLine("Введите пары 'ошибка-исправление' (пустая строка - завершение):");

      while (true)
      {
        Console.Write("Ошибка: ");
        string error = Console.ReadLine();
        if (string.IsNullOrEmpty(error)) break;

        Console.Write("Исправление: ");
        string correction = Console.ReadLine();
        
        if (!string.IsNullOrEmpty(correction))
        {
          corrections[error] = correction;
          Console.WriteLine($"Добавлено: {error} → {correction}\n");
        }
      }

      return corrections;
    }
  }
}
