using System;

namespace Finances
{
    class ConsoleLine
    {
        public void ConsoleWrite(ConsoleColor color, string massage)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(massage);
            Console.WriteLine(new string('=', 50));
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
