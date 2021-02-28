using System;

namespace SeasonName
{
    /// <summary>
    /// Написать метод по определению времени года. 
    /// На вход подаётся число – порядковый номер месяца.
    /// На выходе — значение из перечисления(enum) — Winter, Spring, Summer, Autumn.
    /// Написать метод, принимающий на вход значение из этого перечисления 
    /// и возвращающий название времени года (зима, весна, лето, осень). 
    /// Используя эти методы, ввести с клавиатуры номер месяца и вывести название времени года.
    /// Если введено некорректное число, вывести в консоль текст 
    /// «Ошибка: введите число от 1 до 12».
    /// </summary>
    class ProgramSeasonName
    {
        static void Main(string[] args)
        {
            bool s = true;
            do
            {                
                Console.Write("Введите порядковый номер месяца: ");
                string str = Console.ReadLine();
                int monthNum = 0;
                bool isNum = int.TryParse(str, out monthNum);
                if (isNum && monthNum > 0 && monthNum <= 12)
                {
                    string seasonName = null;
                    seasonName = SeasonValue(monthNum);

                    string seasonRusName = null;
                    seasonRusName = SeasonRusName(seasonName);
                    Console.WriteLine($"{monthNum}-й месяц соответствует сезону: {seasonRusName}");
                    Console.Read();
                    break;
                }
                else
                {
                    s = false;
                }
            } while (s == false);
        }

        static string SeasonValue(int monthNum)
        {
            string seasonName = null;
            switch (monthNum)
            {
                case 1:
                case 2:
                case 12:
                    seasonName = $"{(Season)1}";
                    break;
                case 3:
                case 4:
                case 5:
                    seasonName = $"{(Season)2}";
                    break;
                case 6:
                case 7:
                case 8:
                    seasonName = $"{(Season)3}";
                    break;
                case 9:
                case 10:
                case 11:
                    seasonName = $"{(Season)4}";
                    break;
            }

            return seasonName;
        }

        static string SeasonRusName(string seasonName)
        {
            string seasonRusName = null;

            switch (seasonName)
            {
                case "Winter":
                    seasonRusName = "зима";
                    break;
                case "Spring":
                    seasonRusName = "весна";
                    break;
                case "Summer":
                    seasonRusName = "лето";
                    break;
                case "Autumn":
                    seasonRusName = "осень";
                    break;
            }

            return seasonRusName;
        }
    }

    enum Season
    {
        Winter = 1,
        Spring = 2,
        Summer = 3,
        Autumn = 4
    }
}
