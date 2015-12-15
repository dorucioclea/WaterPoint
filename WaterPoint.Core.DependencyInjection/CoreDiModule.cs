using System.Configuration;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Web.Common;
using WaterPoint.Core.Bll;
using WaterPoint.Data.DbContext.Dapper;


namespace WaterPoint.Core.DependencyInjection
{
    public class CoreDiModule : NinjectModule
    {
        public override void Load()
        {
            //revisit inrequestscope should limit the transaction and connection to the very request but need testing
            Bind<IDapperDbContext>().To<DapperDbContext>()
                .WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());

            Bind<ISqlBuilderFactory>().ToFactory(() => new SqlBuilderProvider());

            Bind<IDapperUnitOfWork>().To<DapperUnitOfWork>();
        }
    }
}
