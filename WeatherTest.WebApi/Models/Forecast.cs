using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherTest.WebApi.Models
{
    public sealed class Forecast
    {
        public String Date { get; set; }

        public String Summary { get; set; }

        public Temperature Temperature { get; set; }

        public Wind Wind { get; set; }
    }
}