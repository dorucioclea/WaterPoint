using Microsoft.Owin;
using Ninject;
using WaterPoint.Api.Common;
using WaterPoint.Api.DependencyInjection;

[assembly: OwinStartup(typeof(WaterPoint.Api.Quote.Startup))]

namespace WaterPoint.Api.Quote
{
    public partial class Startup : CommonStartup
    {
        public override IKernel CreateKernel()
        {
            var kernel = base.CreateKernel();

            kernel.Load(new QuoteApiModule());

            return kernel;
        }
    }
}
