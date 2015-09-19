using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WaterPoint.App.Startup))]
namespace WaterPoint.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
