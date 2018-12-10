using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventAppFinal.Startup))]
namespace EventAppFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
