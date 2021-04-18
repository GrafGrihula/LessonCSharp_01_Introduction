using System;

namespace Weather
{
    class ProgramWeather
    {
        static void Main(string[] args)
        {
            Console.Write("Введите порядковый номер текущего месяца: ");
            int monthNum = Int16.Parse(Console.ReadLine());
            Console.WriteLine($"Вы указали месяц: {(Mounth)monthNum}");

            Console.Write("Введите минимальную температуру за сутки: ");
            string temperatureMin = Console.ReadLine();
            Console.Write("Введите максимальную температуру за сутки: ");
            string temperatureMax = Console.ReadLine();

            string temperatureAverage = ((Int32.Parse(temperatureMax ?? String.Empty) +
                                          Int32.Parse(temperatureMin ?? String.Empty)) / 2).ToString();
            Console.WriteLine($"Среднесуточная температура: {temperatureAverage} градус(ов)");

            int seasonCount = 4;
            int seasonNum = Math.Abs(monthNum / seasonCount + 1);

            int temperatureAverageInt = (Int32.Parse(temperatureAverage ?? String.Empty) / 4);
            int temperatureAverageIntClimat = -1;
            if (temperatureAverageInt < 0)
            {
                temperatureAverageIntClimat = 0;
            }
            else if (temperatureAverageInt >= 0 && temperatureAverageInt <= 10)
            {
                temperatureAverageIntClimat = 10;
            }
            else if (temperatureAverageInt > 10 && temperatureAverageInt <= 20)
            {
                temperatureAverageIntClimat = 20;
            }
            else if (temperatureAverageInt > 20 && temperatureAverageInt <= 30)
            {
                temperatureAverageIntClimat = 30;
            }
            Console.WriteLine($"Сейчас : {(Climat)temperatureAverageIntClimat}" + ", " + $"{(Season)seasonNum}");
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

    enum Season
    {
        зима = 1, //January, 
        весна = 2, //February, 
        лето = 3, //March, 
        осень = 4 //April
    }

    enum Climat
    {
        холодно = 0, //January, 
        дождливо = 10, //February, 
        тепло = 20, //March, 
        жарко = 30 //April
    }
}
