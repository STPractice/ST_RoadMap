using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(STRoadMap.Startup))]
namespace STRoadMap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
