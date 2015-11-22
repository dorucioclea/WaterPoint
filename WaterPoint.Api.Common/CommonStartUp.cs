using System.Web.Http;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using WaterPoint.Core.DependencyInjection;

namespace WaterPoint.Api.Common
{
    public abstract class CommonStartup
    {
        public virtual IKernel CreateKernel()
        {
            var kernel = new StandardKernel(new CoreDiModule());

            kernel.Load(new ApiCommonDiModule());

            return kernel;
        }

        public virtual void Configuration(IAppBuilder app)
        {
            var config = GlobalConfiguration.Configuration;

            app.UseNinjectMiddleware(CreateKernel)
                .UseNinjectWebApi(config);
        }
    }
}
