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
using WaterPoint.Api.DependencyInjection;
using WaterPoint.Core.DependencyInjection;
using WaterPoint.Core.ContractMapper;

[assembly: OwinStartup(typeof(WaterPoint.Api.Startup))]

namespace WaterPoint.Api
{
    public class Startup
    {

        public IKernel CreateKernel()
        {
            var kernel = new StandardKernel(new CoreDiModule());

            kernel.Load(new ApiDiModule());

            return kernel;
        }

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            WebApiConfig.Register(config);

            app.UseNinjectMiddleware(CreateKernel)
                .UseNinjectWebApi(config);
        }
    }
}
