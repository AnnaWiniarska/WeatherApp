
using Weather.OpenWeatherMapModels;

namespace Weather.Repositories
{
    public interface IWeatherRepository
    {
        WeatherResponse GetForecast(string city);
    }
}
