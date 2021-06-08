using System;
using System.Collections.Generic;

namespace MetricsManager
{
    public class ValuesHolder
    {
        public List<WeatherForecast> Weathers;
        public ValuesHolder()
        {
            Weathers = new List<WeatherForecast>();
        }

        public void UpdateTemper(DateTime time, int temper)
        {
            foreach( WeatherForecast entity in Weathers )
            {
                if( entity.Time == time )
                {
                    entity.TemperatureC = temper;
                }
            }
        }

        public void DeleteTemper(DateTime startTime, DateTime finishTime)
        {
            for( int i = 0; i < Weathers.Count; i++ )
            {
                if( Weathers[ i ].Time >= startTime && Weathers[ i ].Time <= finishTime )
                {
                    Weathers.RemoveAt( i );
                    i--;
                }
            }
        }

        public List<WeatherForecast> GetTemper(DateTime startTime, DateTime finishTime)
        {
            var result = new List<WeatherForecast>();

            foreach( WeatherForecast entity in Weathers )
            {
                if( entity.Time >= startTime && entity.Time <= finishTime )
                {
                    result.Add( entity );
                }
            }
            return result;
        }
    }
}