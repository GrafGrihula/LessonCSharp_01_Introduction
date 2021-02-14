using System;

namespace ArrayDiagonal
{
    class ProgramArrayDiagonal
    {
        static void Main(string[] args)
        {
            string[ , ] elements = { { "1.1", "1.2", "1.3"}, { "2.1", "2.2", "2.3" }, { "3.1", "3.2", "3.3" } };
            for (int i = 0; i < elements.GetLength(0); i++)
            {
                Console.WriteLine(elements[ i, i ]);
            }
            Console.Read();
        }
    }
}
