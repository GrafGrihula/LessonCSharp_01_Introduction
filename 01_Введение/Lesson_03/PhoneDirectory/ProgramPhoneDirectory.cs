using System;

namespace PhoneDirectory
{
    class ProgramPhoneDirectory
    {
        static void Main(string[] args)
        {
            string[,] array =
            {
                { "Иванов", "+79998887777" },
                { "Петров", "+74954593421" },
                { "Сидоров", "+79997775554" },
                { "Васичкин", "vasichkin@vmail.va" },
                { "Череззаборногузадерищенко", "footup@fmail.fu" }
            };

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
