using System;
using System.Collections.Generic;

namespace MetricsManager.Controllers
{
        public class ValuesHolder
        {
                public List<WeatherForecast> Weathers;

                public ValuesHolder()
                {
                        Weathers = new List<WeatherForecast>();
                }

                public List<WeatherForecast> GetWeathers(DateTime fromDate, DateTime toDate)
                {
                        var result = new List<WeatherForecast>();
                        foreach (WeatherForecast item in Weathers)
                        {
                                if (item.Date >= fromDate && item.Date <= toDate)
                                {
                                        result.Add(item);
                                }
                        }
                        return result;
                }

                public void UpdateWeather(DateTime searchDate, int updateTemper)
                {
                        foreach (WeatherForecast item in Weathers)
                        {
                                if (item.Date == searchDate)
                                {
                                        item.TemperatureC = updateTemper;
                                }
                        }
                }

                public void DeleteWeather(DateTime fromDate, DateTime toDate)
                {
                        for (int i = 0; i < Weathers.Count; i++)
                        {
                                if (Weathers[i].Date >= fromDate && Weathers[i].Date <= toDate)
                                {
                                        Weathers.RemoveAt(i);
                                        i--;
                                }
                        }
                }
        }
}