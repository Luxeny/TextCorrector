using System;
using System.Collections.Generic;

namespace TextFix
{
  class Program
  {
    static void Main()
    {
      new TextProcessor().ProcessDirectory(Console.ReadLine());
    }
  }
}
