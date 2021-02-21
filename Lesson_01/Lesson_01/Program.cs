using System;

namespace Lesson_01
{
    class Program
    {
        /// <summary>
        /// Ввод имени и вывод имени и текущей даты (без времени)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Write("Введите своё имя: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Привет {name}, сегодня {DateTime.Today.ToShortDateString()} года");
            Console.Read();
        }
    }
}