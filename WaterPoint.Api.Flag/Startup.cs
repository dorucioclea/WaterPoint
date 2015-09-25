using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using WaterPoint.Api.Common;
using WaterPoint.Core.DependencyInjection;

[assembly: OwinStartup(typeof(WaterPoint.Api.Flag.Startup))]

namespace WaterPoint.Api.Flag
{
    public partial class Startup : CommonStartup
    {
        public override IKernel CreateKernel()
        {
            var kernel = base.CreateKernel();

            kernel.Load(new FlagApiDiModule());

            return kernel;
        }
    }
}
