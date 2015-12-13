﻿using System.Web.Http;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using WaterPoint.Api.Common.AppStart;
using WaterPoint.Core.DependencyInjection;

namespace WaterPoint.Api.Common
{
    public abstract class CommonStartup
    {
        public virtual void Configuration(IAppBuilder app)
        {
            ConfigureNinjectKernel(app);
        }

        public virtual IKernel CreateKernel()
        {
            var kernel = new StandardKernel(new CoreDiModule());

            kernel.Load(new ApiCommonDiModule());

            return kernel;
        }

        public virtual IKernel ConfigureNinjectKernel(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            //?? not sure config is used by globalconfiguration
            WebApiConfig.Register(config);

            var kernel = CreateKernel();

            app.UseNinjectMiddleware(() => kernel)
                .UseNinjectWebApi(config);

            return kernel;
        }
    }
}
