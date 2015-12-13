using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;
using Microsoft.Owin;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.AppStart;
using WaterPoint.Api.DependencyInjection;
using WaterPoint.Core.DependencyInjection;

[assembly: OwinStartup(typeof(WaterPoint.Api.Authorization.Startup))]

namespace WaterPoint.Api.Authorization
{
    public partial class Startup : CommonStartup
    {
        public override void Configuration(IAppBuilder app)
        {
            var kernel = ConfigureNinjectKernel(app);

            ConfigureAuth(app, kernel);
        }

        public override IKernel CreateKernel()
        {
            var kernel = base.CreateKernel();

            kernel.Load(new AuthorizationApiModule());

            return kernel;
        }
    }
}
