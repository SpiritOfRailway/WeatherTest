using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherTest.WebApi.Models
{
    public sealed class ForecastForCity
    {
        public Location Location { get; set; }

        public ICollection<Forecast> Forecast { get; set; }
    }
}