using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherTest.WebApi.Models;

namespace WeatherTest.WebApi.Interfaces
{
    internal interface IWeatherService
    {
        ForecastForCity GetForecastForCity(String city, int days);
    }
}
