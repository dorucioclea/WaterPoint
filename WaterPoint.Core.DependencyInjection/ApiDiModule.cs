using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

using WaterPoint.Data.Bll;
using WaterPoint.Data.Repository;
using WaterPoint.Data.DbContext;
using WaterPoint.Data.Repository.Interfaces;

using WaterPoint.Core.Domain.Services;
using WaterPoint.Core.Domain.Bll;
using WaterPoint.Api.Service;


namespace WaterPoint.Core.DependencyInjection
{
    public class ApiDiModule : NinjectModule
    {
        public override void Load()
        {
            BindDb();
            BindRepositories();
            BindBlls();
            BindServices();
        }

        private void BindDb()
        {
            Bind<IDbContext>().To<DapperDbContext>();
        }

        private void BindServices()
        {
            Bind<ISupplierService>().To<SupplierService>();
            Bind<IOrganizationService>().To<OrganizationService>();
        }

        private void BindRepositories()
        {
            Bind<ISupplierRepository>().To<SupplierRepository>();
            Bind<IOrganizationRepository>().To<OrganizationRepository>();
        }

        private void BindBlls()
        {
            Bind<ISupplierBll>().To<SupplierBll>();
            Bind<IOrganizationBll>().To<OrganizationBll>();
        }

    }
}
