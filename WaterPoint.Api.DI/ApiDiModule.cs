using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using WaterPoint.Data.Service;
using WaterPoint.Data.Service.Interfaces;

namespace WaterPoint.Api.DI
{
    public class ApiDiModule: NinjectModule
    {
        public override void Load()
        {
            Bind<ISupplierService>().To<SupplierService>();
        }
    }
}
