using System;
using System.Collections.Generic;

namespace TextFileCorrector
{
  public class Program
  {
    public static void Main()
    {
      try
      {
        var corrections = GetCorrectionDictionary();
        
        Console.WriteLine("\nВведите путь к директории с файлами:");
        string directoryPath = Console.ReadLine();

        new FileProcessor(corrections).ProcessFilesInDirectory(directoryPath);
        
        Console.WriteLine("\nОбработка завершена успешно!");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"\nОшибка: {ex.Message}");
      }
      finally
      {
        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
      }
    }

    private static Dictionary<string, string> GetCorrectionDictionary()
    {
      var corrections = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
      Console.WriteLine("Введите пары для замены (ошибка → исправление):");

      while (true)
      {
        Console.Write("\nОшибочное слово (Enter для завершения): ");
        string errorWord = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(errorWord)) break;

        Console.Write("Правильный вариант: ");
        string correctWord = Console.ReadLine()?.Trim();

        if (!string.IsNullOrEmpty(correctWord))
        {
          corrections[errorWord] = correctWord;
          Console.WriteLine($"Добавлена замена: '{errorWord}' → '{correctWord}'");
        }
      }

      return corrections;
    }
  }
}
