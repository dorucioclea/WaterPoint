using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using WaterPoint.App.ApiClient.Endpoints;
using WaterPoint.App.ApiClient.Endpoints.Interfaces;
using WaterPoint.Data.Bll;
using WaterPoint.Data.Bll.Interfaces;
using WaterPoint.Data.Repository;
using WaterPoint.Data.DbContext;
using WaterPoint.Data.Service;
using WaterPoint.Data.Service.Interfaces;
using WaterPoint.Data.Repository.Interfaces;

namespace WaterPoint.Api.DI
{
    public class ApiDiModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IDbContext>().To<DapperDbContext>();
            BindRepositories();
            BindBlls();
            BindServices();
            BindApiCalls();
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

        private void BindApiCalls()
        {
            Bind<IOrganizationApiClient>().To<OrganizationApiClient>();
        }
    }
}
