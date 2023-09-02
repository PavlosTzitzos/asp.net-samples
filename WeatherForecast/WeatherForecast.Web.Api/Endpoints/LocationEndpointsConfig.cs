using WeatherForecast.Web.Api.Models;

namespace WeatherForecast.Web.Api.Endpoints
{
    public class LocationEndpointsConfig
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static void AddEndpoints(WebApplication app)
        {
            app.MapGet("api/find", () =>
            {
                var rng = new Random();
                var weatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecastModel
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();

                return Results.Ok(weatherForecast);
            });
        }
    }
}
