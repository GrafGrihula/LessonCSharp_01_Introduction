using System;

namespace NumberMonth
{
    class ProgramNumberMonth
    {
        static void Main(string[] args)
        {
            Console.Write("Введите порядковый номер текущего месяца: ");
            int monthNum = Int16.Parse(Console.ReadLine());
            Console.WriteLine($"Вы указали месяц: {(Mounth)monthNum}");
        }
    }

    enum Mounth
    {
        Январь = 1, //January, 
        Февраль = 2, //February, 
        Март = 3, //March, 
        Апрель = 4, //April, 
        Май = 5, //May, 
        Июнь = 6, //June, 
        Июль = 7, //July, 
        Август = 8, //August, 
        Сентябрь = 9, //September, 
        Октябрь = 10, //October, 
        Ноябрь = 11, //November, 
        Декабрь = 12 //December
    }
}
