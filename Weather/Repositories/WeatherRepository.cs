using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Weather.OpenWeatherMapModels;
namespace Weather.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        WeatherResponse IWeatherRepository.GetForecast(string city)
        {
            string key = "2d716452512427c5fd5bbfe5262ea00f";
            // Connection String
            var client = new RestClient($"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&APPID={key}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);
                return content.ToObject<WeatherResponse>();
            }
            return null;
        }
    }
}
