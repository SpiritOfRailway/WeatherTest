using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherTest.WebApi.Interfaces;

namespace WeatherTest.WebApi.Infrastructure
{
    /// <summary>
    /// Build url for openweathermap.org api
    /// </summary>
    internal sealed class OpenWeatherMapUrlBuilder : IWeatherServiceUrlBuilder
    {
        private const String WEATHER_SERVICE_URL_TEMPLATE = @"http://api.openweathermap.org/data/2.5/forecast/daily?q={city}&mode=json&units=metric&cnt={days}&apikey=94b7c9a9908d65670675b7edd72079fc";

        private const String CITY_KEYWORD = "{city}";
        private const String DAYS_COUNT_KEYWORD = "{days}";

        private readonly String _city;
        private readonly int _daysCount;

        internal OpenWeatherMapUrlBuilder(String city, byte daysCount)
        {
            if (city == null)
            {
                throw new ArgumentNullException("city");
            }

            _city = city;

            _daysCount = daysCount;
        }

        String IWeatherServiceUrlBuilder.GetUrl()
        {
            String urlWithCity = WEATHER_SERVICE_URL_TEMPLATE.Replace(CITY_KEYWORD, _city);
            String completeUrl = urlWithCity.Replace(DAYS_COUNT_KEYWORD, _daysCount.ToString());

            return completeUrl;
        }
    }
}