using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalEventApplication.Startup))]
namespace FinalEventApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
