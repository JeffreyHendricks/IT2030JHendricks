using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab8ABonus.Startup))]
namespace Lab8ABonus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
