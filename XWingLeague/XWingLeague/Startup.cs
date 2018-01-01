using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XWingLeague.Startup))]
namespace XWingLeague
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
