using System;

namespace NumberSum
{
    /// <summary>
    /// 2. Написать программу, принимающую на вход строку — набор чисел, разделенных
    /// пробелом, и возвращающую число — сумму всех чисел в строке. Ввести данные 
    /// с клавиатуры и вывести результат на экран.
    /// </summary>
    class ProgramNumberSum
    {
        static void Main(string[] args)
        {
            Console.Write("Введите через пробел несколько чисел: ");
            string numbersText = Console.ReadLine();

            int numbersSum = NumbersSumFunc(numbersText);
            Console.WriteLine($"Сумма чисел равна {numbersSum}");
        }

        private static int NumbersSumFunc(string numbersText)
        {
            string[] numbersMeaning = numbersText.Split(' ');
            int sum = 0;
            foreach(string s in numbersMeaning)
            {
                sum += Int32.Parse(s);
            }
            return sum;
        }
    }
}
