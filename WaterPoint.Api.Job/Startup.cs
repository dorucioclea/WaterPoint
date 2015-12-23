using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Ninject;
using Owin;
using WaterPoint.Api.Common;
using WaterPoint.Api.DependencyInjection;

[assembly: OwinStartup(typeof(WaterPoint.Api.Job.Startup))]

namespace WaterPoint.Api.Job
{
    public partial class Startup : CommonStartup
    {
        public override IKernel CreateKernel()
        {
            var kernel = base.CreateKernel();

            kernel.Load(new JobApiModule());
            kernel.Load(new JobTaskApiModule());

            return kernel;
        }
    }
}
