using Microsoft.Owin;
using Ninject;
using WaterPoint.Api.Common;
using WaterPoint.Api.DependencyInjection;

[assembly: OwinStartup(typeof(WaterPoint.Api.Authorization.Startup))]

namespace WaterPoint.Api.Authorization
{
    public partial class Startup : CommonStartup
    {
        public override IKernel CreateKernel()
        {
            var kernel = base.CreateKernel();

            kernel.Load(new AuthorizationApiModule());

            return kernel;
        }
    }
}
