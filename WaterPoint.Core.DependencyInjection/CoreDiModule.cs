using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Extensions.NamedScope;
using Ninject.Modules;
using Ninject.Web.Common;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain.Repositories;
using WaterPoint.Core.Domain.Requests.Products;
using WaterPoint.Core.Domain;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;


namespace WaterPoint.Core.DependencyInjection
{
    public class CoreDiModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDapperUnitOfWork>().To<DapperUnitOfWork>().InRequestScope();

            Bind<IDapperDbContext>().To<DapperDbContext>().InCallScope()
                .WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());

            Bind<ICoreMapper>().To<CoreMapper>().InSingletonScope();

        }
    }
}
