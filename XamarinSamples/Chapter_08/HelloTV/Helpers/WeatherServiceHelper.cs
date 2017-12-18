using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HelloTV.Enums;
using HelloTV.Models;
using Newtonsoft.Json;

namespace HelloTV
{
    public static class WeatherServiceHelper
    {
        private static string appId = "31fbd9047de24999e383c8d397c533b5";
        private static HttpClient httpClient;

        static WeatherServiceHelper()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/weather")
            };
        }

        public static async Task<WeatherInfo> GetWeatherInfo(string cityName, TemperatureUnit unit)
        {
            var getRequestUri = GetRequestUri(cityName, unit);
            var response = await httpClient.GetAsync(getRequestUri);

            CheckStatusCode(response.StatusCode);

            var jsonString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<WeatherInfo>(jsonString);
        }

        public static string GetTemperatureUnitString(TemperatureUnit unit)
        {
            var unitString = string.Empty;
            var degSymbol = (char)176;

            switch (unit)
            {
                case TemperatureUnit.Imperial:
                    unitString = $"{degSymbol}F";
                    break;

                case TemperatureUnit.Metric:
                    unitString = $"{degSymbol}C";
                    break;

                case TemperatureUnit.Default:
                default:
                    unitString = "K";
                    break;
            }

            return unitString;
        }

        private static string GetRequestUri(string cityName, TemperatureUnit unit)
        {
            return $"?appId={appId}"
                + $"&q={cityName}"
                + $"&{TemperatureUnitToQueryString(unit)}";
        }

        private static string TemperatureUnitToQueryString(TemperatureUnit unit)
        {
            var queryString = "units=";

            switch (unit)
            {
                case TemperatureUnit.Imperial:
                    queryString += "imperial";
                    break;

                case TemperatureUnit.Metric:
                    queryString += "metric";
                    break;
            }

            return queryString;
        }

        private static void CheckStatusCode(HttpStatusCode statusCode)
        {
            if (statusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Unexpected status code: {statusCode}");
            }
        }
    }
}