using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Ninject;
using Owin;
using WaterPoint.Api.Common;
using WaterPoint.Api.DependencyInjection;

[assembly: OwinStartup(typeof(WaterPoint.Api.TaskDefinition.Startup))]

namespace WaterPoint.Api.TaskDefinition
{
    public partial class Startup : CommonStartup
    {
        public override IKernel CreateKernel()
        {
            var kernel = base.CreateKernel();

            kernel.Load(new TaskDefinitionApiModule());

            return kernel;
        }
    }
}
