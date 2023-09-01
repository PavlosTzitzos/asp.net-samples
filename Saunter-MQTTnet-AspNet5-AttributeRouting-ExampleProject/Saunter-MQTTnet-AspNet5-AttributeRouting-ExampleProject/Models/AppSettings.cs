namespace Saunter_MQTTnet_AspNet5_AttributeRouting_ExampleProject.Models
{
    public class AppSettings
    {
        public string ApplicationName { get; set; }
        public string ApplicationVersion { get; set; }
        public string ApplicationBaseUrl { get; set; }
        public KestrelSettings KestrelSettings { get; set; }
        public int KissIntervalSeconds { get; set; }
    }
}