using WeatherForecast.Web.Models;

namespace WeatherForecast.Web.Services.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherForecastModel>> Find();
    }
}
