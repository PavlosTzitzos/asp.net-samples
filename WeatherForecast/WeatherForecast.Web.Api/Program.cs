using WeatherForecast.Web.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

LocationEndpointsConfig.AddEndpoints(app);

app.Run();