using System;

namespace ScheduleWeek
{
    class ProgramScheduleWeek
    {
        static void Main(string[] args)
        {
            int oficeFirst = 0b_0011110;
            int oficeTwo = 0b_0111111;
            Console.WriteLine("Расписание недели офиса № 1: \n{0}\n", (Week)oficeFirst);
            Console.WriteLine("Расписание недели офиса № 2:  \n{0}\n", (Week)oficeTwo);
        }

        [Flags]
        enum Week
        {
            Понедельник = 0b0000001,
            Вторник = 0b0000010,
            Среда = 0b0000100,
            Четверг = 0b0001000,
            Пятница = 0b0010000,
            Суббота = 0b0100000,
            Воскресенье = 0b1000000
        }
    }
}
