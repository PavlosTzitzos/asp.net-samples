using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApp5Identity.Startup))]
namespace WebApp5Identity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
