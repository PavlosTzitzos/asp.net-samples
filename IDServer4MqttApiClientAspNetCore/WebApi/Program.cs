
// Go To : https://localhost:7201/weatherforecast

using MQTTnet.AspNetCore;
using MQTTnet.AspNetCore.AttributeRouting;
using MQTTnet.AspNetCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMqttControllers(
    /*
        By default, all controllers within the executing assembly are
        discovered (just pass nothing here). To provide a list of assemblies
        explicitly, pass an array of Assembly[] here.
    */
    );

builder.Services
    .AddHostedMqttServerWithServices(s =>
        {
            // Optionally set server options here
            s.WithoutDefaultEndpoint();

            // Enable Attribute routing
            s.WithAttributeRouting(
                /* 
                    By default, messages published to topics that don't
                    match any routes are rejected. Change this to true
                    to allow those messages to be routed without hitting
                    any controller actions.
                */
                allowUnmatchedRoutes: false
            );
        })
    .AddMqttConnectionHandler()
    .AddConnections();


builder.Services.AddAuthentication("Bearer")
    .AddIdentityServerAuthentication("Bearer", options =>
    {
        options.ApiName = "myApi";
        options.Authority = "http://192.168.2.3:7232";
        options.RequireHttpsMetadata = false;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

    // Root endpoint for MQTT - attribute routing picks up after this URL
    endpoints.MapMqtt("/mqtt");
});

app.MapControllers();

app.Run();
