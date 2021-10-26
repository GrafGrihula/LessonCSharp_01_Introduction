using System;
using System.IO;

namespace RandomDataToText
{
    /// <summary>
    /// 1. Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл
    /// </summary>
    class ProgramRandomDataToText
    {
        static void Main(string[] args)
        {
            string filename = "dataText.txt";
            Console.WriteLine("Введете произвольный набор данных:");
            string text = Console.ReadLine();
            File.WriteAllText(filename, text);
            Console.WriteLine("Спасибо! Данные сохранены в текстовый файл.");
            Console.Read();
        }
    }
}
