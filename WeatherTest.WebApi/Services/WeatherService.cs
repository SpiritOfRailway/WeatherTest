using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using WeatherTest.WebApi.Infrastructure;
using WeatherTest.WebApi.Interfaces;
using WeatherTest.WebApi.Models;

namespace WeatherTest.WebApi.Services
{
    internal sealed class WeatherService : IWeatherService
    {
        ForecastForCity IWeatherService.GetForecastForCity(String city, int days)
        {
            IWeatherServiceUrlBuilder urlBuilder = new OpenWeatherMapUrlBuilder(city, (byte)days);

            String responseText = MakeRequest(urlBuilder.GetUrl());

            IWeatherServiceResponseParser parser = new OpenWeatherParser();

            ForecastForCity result = parser.Parse(responseText);

            return result;
        }

        private String MakeRequest(string requestUrl)
        {
            String responseText = null;

            HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new InvalidOperationException(String.Format("Error (HTTP {0} : {1}.", response.StatusCode, response.StatusDescription));
                }

                StreamReader reader = new StreamReader(response.GetResponseStream());

                responseText = reader.ReadToEnd();
            }

            return responseText;
        }
    }
}