#region Using Imports

using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MQTTnet.AspNetCore;
using MQTTnet.AspNetCore.AttributeRouting;
using MQTTnet.AspNetCore.Extensions;
using Saunter;
using Saunter.AsyncApiSchema.v2;
using Saunter.Generation;
using Saunter_MQTTnet_AspNet5_AttributeRouting_ExampleProject.Controllers.Mqtt;
using Saunter_MQTTnet_AspNet5_AttributeRouting_ExampleProject.Models;
using Saunter_MQTTnet_AspNet5_AttributeRouting_ExampleProject.Services;

#endregion Using Imports

/*
Warning: Because the Official MQTTnet.AspNetCore.AttributeRouting was outdated a Fork was used which allows to be used
with the latest MQTTnet.AspNetCore package!
When updating packages in the future we will have to pay attention if the Official or Forked package has received new 
updates: 
- Source-Code:  https://github.com/Atlas-LiftTech/MQTTnet.AspNetCore.AttributeRouting
- Official:     https://www.nuget.org/packages/MQTTnet.AspNetCore.AttributeRouting
- Fork:         https://www.nuget.org/packages/MQTTnet.AspNetCore.AttributeRouting.Forked/ 
*/

namespace Saunter_MQTTnet_AspNet5_AttributeRouting_ExampleProject
{
    public class Startup
    {
        #region Variable Declarations

        private AppSettings _appSettings;
        public IConfiguration Configuration { get; }

        #endregion Variable Declarations

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Read out the appsettings.json settings & Bind them to the corresponding keys in AppSettings.cs,
            // Then add the populated AppSettings class as an easy to access Singleton
            _appSettings = new AppSettings();
            Configuration.Bind("AppSettings", _appSettings);
            services.AddSingleton(_appSettings);

            // Allow CORS
            services.AddCors();

            // Add Singleton MQTT Server object
            services.AddSingleton<MqttService>();

            // Add the MQTT Controllers
            services.AddMqttControllers();

            // Add the MQTT Service
            services
                .AddHostedMqttServerWithServices(aspNetMqttServerOptionsBuilder =>
                {
                    var mqttService = aspNetMqttServerOptionsBuilder.ServiceProvider.GetRequiredService<MqttService>();
                    mqttService.ConfigureMqttServerOptions(aspNetMqttServerOptionsBuilder);
                    aspNetMqttServerOptionsBuilder.Build();
                })
                .AddMqttConnectionHandler()
                .AddConnections()
                .AddMqttWebSocketServerAdapter();

            // Add Saunter to the application services (for Automatic AsyncAPI MQTT Documentation Generation) 
            services.AddAsyncApiSchemaGeneration(options =>
            {
                // Specify example type(s) from assemblies to scan.
                options.AssemblyMarkerTypes = new[] { typeof(Startup) };

                // Build as much (or as little) of the AsyncApi document as you like.
                // Saunter will generate Channels, Operations, Messages, etc, but you may want to specify Info here.
                options.AsyncApi = new AsyncApiDocument
                {
                    Info = new Info(_appSettings.ApplicationName, _appSettings.ApplicationVersion)
                    {
                        Description =
                            "Example project implementing Saunter with MQTTnet Attribute Routing in ASP.NET 5",
                        License = new License("Apache 2.0") { Url = "https://www.apache.org/licenses/LICENSE-2.0" }
                    },
                    Servers =
                    {
                        { _appSettings.ApplicationName, new Server(_appSettings.ApplicationBaseUrl, "mqtt") }
                    }
                };
            });

            // Add Scoped Services
            services.AddScoped<MqttBaseController, ExampleController>();

            // Add the Controllers
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseCors(
                options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Setup EndPoints for Controller actions
                endpoints.MapControllers();
                // Setup MQTT EndPoints for WebSocket connection on: "{_appSettings.ApplicationBaseUrl}:{port}/mqtt"
                endpoints.MapConnectionHandler<MqttConnectionHandler>(
                    "/mqtt",
                    httpConnectionDispatcherOptions =>
                        httpConnectionDispatcherOptions.WebSockets.SubProtocolSelector =
                            protocolList => protocolList.FirstOrDefault() ?? string.Empty);

                // Setup Saunter AsyncAPI Documentation EndPoints
                endpoints.MapAsyncApiDocuments();
                endpoints.MapAsyncApiUi();
            });

            app.UseMqttServer(server =>
                app.ApplicationServices.GetRequiredService<MqttService>().ConfigureMqttServer(server));

            // Print the AsyncAPI Docs Location
            var logger = app.ApplicationServices.GetService<ILoggerFactory>().CreateLogger<Program>();
            var addresses = app.ServerFeatures.Get<IServerAddressesFeature>().Addresses;

            logger.LogInformation("AsyncAPI Docs available at: {Url}",
                $"{addresses.FirstOrDefault()}/asyncapi/asyncapi.json");
            logger.LogInformation("AsyncAPI UI available at: {Url}",
                $"{addresses.FirstOrDefault()}/asyncapi/ui/index.html");
        }
    }
}