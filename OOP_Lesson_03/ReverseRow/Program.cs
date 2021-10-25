using System;

namespace ReverseRow
{
    class Program
    {
        static void Main(string[] args)
        {
            Revers revers = new Revers();
            Console.Write("Введите текст:\t");
            //Console.WriteLine();
            string input = Console.ReadLine();
            Console.WriteLine($"Результат:\t{revers.StringRevers(input)}");

            Console.Read();
        }
    }
}
