using System;

namespace ArrayDiagonal
{
    class ProgramArrayDiagonal
    {
        static void Main(string[] args)
        {
            string[,] array =
            {
                {"1.1", "1.2", "1.3" },
                {"2.1", "2.2", "2.3" },
                {"3.1", "3.2", "3.3" }
            };

            for (int i = 0, j = 0; i < array.GetLength(0); i++, j++)
            {
                Console.WriteLine(array[i, j]);
            }            
        }
    }
}
