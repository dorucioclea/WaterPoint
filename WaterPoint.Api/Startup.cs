using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Ninject;
using Owin;
//using Microsoft.Owin.Cors;
//using Microsoft.Owin.Security.Infrastructure;
//using Microsoft.Owin.Security.OAuth;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;

[assembly: OwinStartup(typeof(WaterPoint.Api.Startup))]

namespace WaterPoint.Api
{
    public class Startup
    {
        public IKernel CreateCernel()
        {
            var kernel = new StandardKernel(new WaterPoint.Api.DI.ApiDiModule());

            return kernel;

        }

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            app.UseNinjectMiddleware(() => CreateCernel())
                .UseNinjectWebApi(config);
        }
    }
}
