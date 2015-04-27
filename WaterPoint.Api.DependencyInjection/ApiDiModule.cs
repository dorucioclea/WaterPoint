using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using WaterPoint.Api.Service;
using WaterPoint.Core.Domain.Services;

namespace WaterPoint.Api.DependencyInjection
{
    public class ApiDiModule : NinjectModule
    {
        public override void Load()
        {
            BindServices();
        }

        private void BindServices()
        {
            Bind<ISupplierService>().To<SupplierService>();
            Bind<IOrganizationService>().To<OrganizationService>();
        }
    }
}
