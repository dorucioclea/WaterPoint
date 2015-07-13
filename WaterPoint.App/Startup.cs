using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Ninject;
using Owin;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using WaterPoint.Core.DependencyInjection;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

[assembly: OwinStartupAttribute(typeof(WaterPoint.App.Startup))]
namespace WaterPoint.App
{
    public partial class Startup
    {
        public IKernel CreateKernel()
        {
            var kernel = new StandardKernel(new CoreDiModule());

            kernel.Load(new AppDiModule());

            return kernel;
        }

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            ConfigWeb(config);

            app.UseNinjectMiddleware(CreateKernel)
                .UseNinjectWebApi(config);

            //TODO: auth layer.
            ConfigureAuth(app);
        }
        
        private void ConfigWeb(HttpConfiguration config)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
