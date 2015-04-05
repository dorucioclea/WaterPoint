using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using WaterPoint.Data.Bll;
using WaterPoint.Data.Bll.Interfaces;
using WaterPoint.Data.Repository;
using WaterPoint.Data.Repository.DbContext;
using WaterPoint.Data.Service;
using WaterPoint.Data.Service.Interfaces;

namespace WaterPoint.Api.DI
{
    public class ApiDiModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IDbContext>().To<DapperDbContext>();

            BindService();
            BindBll();
            
        }

        private void BindService()
        {
            Bind<ISupplierService>().To<SupplierService>();
        }

        private void BindBll()
        {
            Bind<ISupplierBll>().To<SupplierBll>();
        }
    }
}
