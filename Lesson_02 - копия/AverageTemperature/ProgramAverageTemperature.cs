using System;

namespace AverageTemperature
{
    class ProgramAverageTemperature
    {
        static void Main(string[] args)
        {
            Console.Write("Введите минимальную температуру за сутки: ");
            string temperatureMin = Console.ReadLine();
            Console.Write("Введите максимальную температуру за сутки: ");
            string temperatureMax = Console.ReadLine();

            string temperatureAverage = ((Int32.Parse(temperatureMax ?? String.Empty) +
                                          Int32.Parse(temperatureMin ?? String.Empty)) / 2).ToString();
            Console.WriteLine($"Среднесуточная температура: {temperatureAverage} градус(ов)");
            Console.Read();
        }
    }
}
