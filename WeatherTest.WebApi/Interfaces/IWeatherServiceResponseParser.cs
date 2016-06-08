
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherTest.WebApi.Models;

namespace WeatherTest.WebApi.Interfaces
{
    internal interface IWeatherServiceResponseParser
    {
        ForecastForCity Parse(String json);
    }
}