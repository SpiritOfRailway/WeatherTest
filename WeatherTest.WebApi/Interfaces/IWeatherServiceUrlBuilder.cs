using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTest.WebApi.Interfaces
{
    internal interface IWeatherServiceUrlBuilder
    {
        String GetUrl();
    }
}
