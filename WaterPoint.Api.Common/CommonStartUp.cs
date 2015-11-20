using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using WaterPoint.Api.Common.AppStart;
using WaterPoint.Core.DependencyInjection;

namespace WaterPoint.Api.Common
{
    public abstract class CommonStartup
    {
        public virtual IKernel CreateKernel()
        {
            var kernel = new StandardKernel(new CoreDiModule());

            return kernel;
        }

        public virtual void Configuration(IAppBuilder app)
        {
            //var config = new HttpConfiguration();

            //WebApiConfig.Register(config);

            var config = GlobalConfiguration.Configuration;

            app.UseNinjectMiddleware(CreateKernel)
                .UseNinjectWebApi(config);
        }
    }
}
