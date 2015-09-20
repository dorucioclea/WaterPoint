using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Extensions.NamedScope;
using Ninject.Modules;
using WaterPoint.Core.Domain.Repositories;
using WaterPoint.Core.Domain.SpecificationRequests.Banners;
using WaterPoint.Core.Domain.SpecificationRequests.Products;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Specification;
using WaterPoint.Core.Specification.Products;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;


namespace WaterPoint.Core.DependencyInjection
{
    public class CoreDiModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<DapperUnitOfWork>();
            Bind<IDapperDbContext>().To<DapperDbContext>().InCallScope()
                .WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["DefaultConnection"]);
            BindSpecifications();
        }

        private void BindSpecifications()
        {
            Bind<ISpecification<ListProductsByFlagRequest, IEnumerable<Product>>>()
                .To<ListProductByFlagSpecification>();

        }
    }
}
