using System;
using System.IO;
using System.Linq;

namespace EmailText
{
    class Program
    {
        private static string s;

        static void Main(string[] args)
        {
            Search search = new Search();

            // Отображение информации из первого файла
            Console.WriteLine(new string('^', 50));

            Console.WriteLine("Первоначальный текст:");
            Console.WriteLine();
            search.ReadText(ref s);

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));

            Console.ReadLine();

            // Очистка нового файла (если он есть)
            string writePath = @"TextFile2.txt";
            File.WriteAllText(writePath, string.Empty);

            // Отображение информации из второго файла
            Console.WriteLine(new string('^', 50));

            Console.WriteLine("Новый текст в новом файле:");
            Console.WriteLine();
            search.SearchEmail(ref s);

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
        }
    }
}
