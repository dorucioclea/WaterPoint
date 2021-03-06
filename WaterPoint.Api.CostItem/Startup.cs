﻿using Microsoft.Owin;
using Ninject;
using WaterPoint.Api.Common;
using WaterPoint.Api.DependencyInjection;

[assembly: OwinStartup(typeof(WaterPoint.Api.CostItem.Startup))]

namespace WaterPoint.Api.CostItem
{
    public partial class Startup : CommonStartup
    {
        public override IKernel CreateKernel()
        {
            var kernel = base.CreateKernel();

            kernel.Load(new CostItemApiModule());

            return kernel;
        }
    }
}
