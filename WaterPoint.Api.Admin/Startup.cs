using Microsoft.Owin;
using Ninject;
using WaterPoint.Api.Common;
using WaterPoint.Api.DependencyInjection;

[assembly: OwinStartup(typeof(WaterPoint.Api.Admin.Startup))]

namespace WaterPoint.Api.Admin
{
    public partial class Startup : CommonStartup
    {
        public override IKernel CreateKernel()
        {
            var kernel = base.CreateKernel();

            kernel.Load(new AdminApiModule());

            return kernel;
        }
    }
}
