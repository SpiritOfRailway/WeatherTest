using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherTest.WebApi.Models
{
    public sealed class Wind
    {
        public String Direction { get; set; }

        public decimal Speed { get; set; }
    }
}