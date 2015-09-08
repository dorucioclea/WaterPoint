using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using WaterPoint.Core.Domain.Repositories;
using WaterPoint.Core.Domain.SpecificationRequests.Products;
using WaterPoint.Core.Domain.Specifications;
using WaterPoint.Core.Repository;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Repository.Products;
using WaterPoint.Data.DbContext.NHibernate;
using WaterPoint.Data.Entity.DataEntities;


namespace WaterPoint.Core.DependencyInjection
{
    public class CoreDiModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<NHibernateUnitOfWork>();
            Bind<ISessionUnitOfWork>().To<NHibernateUnitOfWork>();
            Bind(typeof (INHibernateRepository<>)).To(typeof (NHibernateRepository<>));
            BindSpecifications();
        }

        private void BindSpecifications()
        {

            Bind<ISpecification<ListProductsByFlagRequest, IEnumerable<Product>>>()
                .To<ListProductByFlagSpecification>();
            
        }
    }
}
