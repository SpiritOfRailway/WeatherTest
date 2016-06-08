using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherTest.WebApi.Interfaces;
using WeatherTest.WebApi.Models;

namespace WeatherTest.WebApi.Infrastructure
{
    internal sealed class OpenWeatherParser : IWeatherServiceResponseParser
    {
        //openweathermap.org provide time as offset from unix time
        private static DateTime unixDefaultTime = new DateTime(1970, 1, 1);

        ForecastForCity IWeatherServiceResponseParser.Parse(String json)
        {
            //Anonymous object as template for deserialization 
            var typeTemplate = new
            {
                City = new { Name = "", Country = "" },
                List = Enumerable.Empty<object>().Select(x => new
                {
                    Dt = 1,
                    Speed = 1.2M,
                    Deg = 1,
                    Temp = new { Day = 1.2M, Night = 1.2M },
                    Weather = Enumerable.Empty<object>().Select(y => new { Description = "" })
                })
            };

            var rawInfo = JsonConvert.DeserializeAnonymousType(json, typeTemplate);

            //Copy data to result
            ForecastForCity result = null;
            if (rawInfo.City != null)
            { 
                result = new ForecastForCity();

                result.Location = new Location { Country = rawInfo.City.Country, Name = rawInfo.City.Name };

                if (rawInfo.List != null)
                {
                    List<Forecast> forecasts = new List<Forecast>();
                    foreach (var item in rawInfo.List)
                    {
                        Forecast forecast = new Forecast();
                        forecast.Date = unixDefaultTime.AddSeconds(item.Dt).ToString("yyyy-MM-dd");
                        if (item.Weather != null && item.Weather.Count() > 0)
                        {
                            forecast.Summary = item.Weather.First().Description;
                        }

                        forecast.Temperature = new Temperature { Day = item.Temp.Day, Night = item.Temp.Night };

                        WindDirection wind = WindDirection.Create(item.Deg);

                        forecast.Wind = new Wind { Speed = item.Speed, Direction = wind.Direction };
                        forecasts.Add(forecast);
                    }
                    result.Forecast = forecasts;
                }
            }

            return result;
        }
    }
}