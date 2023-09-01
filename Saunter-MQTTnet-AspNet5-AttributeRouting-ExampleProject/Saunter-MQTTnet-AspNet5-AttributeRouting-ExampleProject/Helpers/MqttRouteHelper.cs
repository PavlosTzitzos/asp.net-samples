using System.Text.RegularExpressions;

namespace Saunter_MQTTnet_AspNet5_AttributeRouting_ExampleProject.Helpers
{
    public static class MqttRouteHelper
    {
        /// <summary>
        ///     Useless because C# Attribute properties need to be constants available at compile time.
        ///     However still a good memory aid to quickly check the parsing difference between routes in:
        ///     - Saunter
        ///     - MQTTnet.AspNetCore.AttributeRouting
        /// </summary>
        public static string ParseSaunterMqttRoute(string mqttNetRoute)
        {
            var saunterRoute = mqttNetRoute;

            var singleEventWildcard = new Regex(@"{\w+:\w+}");
            if (singleEventWildcard.IsMatch(saunterRoute))
                saunterRoute = singleEventWildcard.Replace(saunterRoute, "+");

            var multiLevelWildcard = new Regex(@"{\*\w+}");
            if (multiLevelWildcard.IsMatch(saunterRoute))
                saunterRoute = multiLevelWildcard.Replace(saunterRoute, "#");

            return saunterRoute;
        }
    }
}