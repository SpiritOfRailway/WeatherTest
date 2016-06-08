using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherTest.WebApi.Infrastructure;
using WeatherTest.WebApi.Interfaces;
using WeatherTest.WebApi.Models;

namespace WeatherTest.WebApi.Controllers
{
    public sealed class WeatherController : ApiController
    {
        private readonly IWeatherService _service;

        public WeatherController()
        {
            _service = new Services.WeatherService();
        }

        [Route("api/weather/daily/{city}/count={count}")]
        [ApiKeyAuthorize]
        public IHttpActionResult Get(String city, int count = 3)
        {
            ForecastForCity result = _service.GetForecastForCity(city, count);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
