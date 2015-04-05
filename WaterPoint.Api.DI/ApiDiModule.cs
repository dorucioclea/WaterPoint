using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using WaterPoint.Data.Bll;
using WaterPoint.Data.Bll.Interfaces;
using WaterPoint.Data.Repository;
using WaterPoint.Data.DbContext;
using WaterPoint.Data.Service;
using WaterPoint.Data.Service.Interfaces;

namespace WaterPoint.Api.DI
{
    public class ApiDiModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IDbContext>().To<DapperDbContext>();
            BindRepositories();
            BindServices();
            BindBlls();
            
        }

        private void BindServices()
        {
            Bind<ISupplierService>().To<SupplierService>();
        }

        private void BindRepositories()
        {
            Bind<ISupplierRepository>().To<SupplierRepository>();
        }

        private void BindBlls()
        {
            Bind<ISupplierBll>().To<SupplierBll>();
        }
    }
}
