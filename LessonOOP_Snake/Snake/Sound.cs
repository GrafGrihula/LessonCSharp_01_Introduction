using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Sound
    {
        public void funeralMarch()
        {
            Console.Beep(300, 200);
            Console.Beep(300, 200);
            Console.Beep(300, 100);
            Console.Beep(300, 400);
            Thread.Sleep(100);
            Console.Beep(350, 250);
            Console.Beep(330, 100);
            Console.Beep(330, 150);
            Console.Beep(300, 100);
            Console.Beep(300, 150);
            Console.Beep(290, 100);
            Console.Beep(300, 400);
        }

        public void chomping()
        {
            Console.Beep(300, 80);
            Console.Beep(500, 80);
            Console.Beep(700, 80);
            Console.Beep(900, 80);
        }
    }
}
