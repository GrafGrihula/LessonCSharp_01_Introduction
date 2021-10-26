using System;

namespace TextContrary
{
    class ProgramTextContrary
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите понятный текст: ");
            string text = Console.ReadLine();
            for (int i = text.Length-1; i > -1; i--)
            {
                Console.WriteLine(text[i]);
            }
        }
    }
}
