using System;

namespace SeaBattle
{
    class ProgramSeaBattle
    {
        static void Main(string[] args)
        {
            string[,] pole =
            {
                { "X", "X", "X", "X", "O", "O", "O", "O", "O", "O" },
                { "O", "O", "O", "O", "O", "O", "O", "O", "O", "O" },
                { "O", "X", "O", "O", "O", "O", "O", "O", "X", "O" },
                { "O", "O", "O", "X", "X", "O", "O", "O", "O", "O" },
                { "O", "O", "O", "O", "O", "O", "X", "O", "O", "O" },
                { "X", "X", "O", "O", "O", "O", "O", "O", "O", "O" },
                { "O", "O", "O", "X", "O", "O", "O", "O", "O", "O" },
                { "O", "X", "O", "O", "O", "X", "X", "O", "O", "X" },
                { "O", "O", "O", "O", "O", "O", "O", "O", "O", "X" },
                { "X", "X", "X", "O", "O", "O", "O", "O", "O", "X" }
            };

            for (int i = 0; i < pole.GetLength(0); i++)
            {
                for (int j = 0; j < pole.GetLength(1); j++)
                {
                    Console.Write(pole[i,j]);
                    Console.Write(" "); // Это чтобы поле "сквадратить"
                }
                Console.WriteLine();
            }            
        }
    }
}
