﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherTest.WebApi.Models
{
    public sealed class Temperature
    {
        public decimal Day { get; set; }

        public decimal Night { get; set; }
    }
}