using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WaterPoint.Startup))]
namespace WaterPoint
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
