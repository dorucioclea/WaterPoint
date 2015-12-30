using Microsoft.Owin;
using Ninject;
using WaterPoint.Api.Common;
using WaterPoint.Api.DependencyInjection;

[assembly: OwinStartup(typeof(WaterPoint.Api.Invoice.Startup))]

namespace WaterPoint.Api.Invoice
{
    public partial class Startup : CommonStartup
    {
        public override IKernel CreateKernel()
        {
            var kernel = base.CreateKernel();

            kernel.Load(new InvoiceApiModule());

            return kernel;
        }
    }
}
