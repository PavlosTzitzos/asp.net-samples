
// Go To : https://localhost:7201/weatherforecast

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthentication("Bearer")
    .AddIdentityServerAuthentication("Bearer", options =>
    {
        options.ApiName = "myApi";
        options.Authority = "https://localhost:7232";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
