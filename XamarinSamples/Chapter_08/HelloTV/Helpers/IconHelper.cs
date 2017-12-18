using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Foundation;
using HelloTV.Models;
using UIKit;

namespace HelloTV.Helpers
{
    public static class IconHelper
    {
        private static HttpClient httpClient;

        private static string baseAddress = "http://openweathermap.org/img/w/";
        private static string iconExtension = ".png";

        static IconHelper()
        {
            httpClient = new HttpClient();
        }

        public static async Task<UIImage> GetIcon(WeatherInfo weatherInfo)
        {
            var iconUrl = GetIconUrl(weatherInfo);

            var imageData = await httpClient.GetByteArrayAsync(iconUrl);

            return UIImage.LoadFromData(NSData.FromArray(imageData));
        }

        private static string GetIconUrl(WeatherInfo weatherInfo)
        {
            var iconName = weatherInfo.Weather.FirstOrDefault().Icon;

            return $"{baseAddress}{iconName}{iconExtension}";
        }
    }
}
