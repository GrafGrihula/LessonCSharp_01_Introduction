using System;

namespace LeapYearDOPDZ
{
    class ProgramLeapYearDOPDZ
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ГОД: ");
            int year = Int16.Parse(Console.ReadLine());
            if((year % 100 != 0 || year % 400 == 0) && year % 4 == 0)
            {
                Console.WriteLine("Вы указали ВИСОкосный ГОД");
            }
            else
            {
                Console.WriteLine("Вы указали обычный, спокойный и некатаклизьменный ГОД");
            }
        }
    }
}
