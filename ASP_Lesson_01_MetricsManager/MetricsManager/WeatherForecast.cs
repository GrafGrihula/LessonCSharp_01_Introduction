using System;

namespace MetricsManager
{
    public class WeatherForecast
    {
        public DateTime Time { get; set; }
        public int TemperatureC { get; set; }

        public WeatherForecast()
        {
            Time = new DateTime();
            TemperatureC = new int();
        }
    }
}









//public int TemperatureF => 32 + ( int )(TemperatureC / 0.5556);

//public string Summary { get; set; }
