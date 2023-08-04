using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApp6UnitTestsandIdentity.Startup))]
namespace WebApp6UnitTestsandIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
