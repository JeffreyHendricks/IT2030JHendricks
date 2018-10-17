using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApplication_indiv.Startup))]
namespace WebApplication_indiv
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
