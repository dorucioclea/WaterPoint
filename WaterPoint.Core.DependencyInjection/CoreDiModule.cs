using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using WaterPoint.Core.Domain.Repositories;
using WaterPoint.Core.Repository;
using WaterPoint.Core.Domain;
using WaterPoint.Data.DbContext.NHibernate;


namespace WaterPoint.Core.DependencyInjection
{
    public class CoreDiModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<NHibernateUnitOfWork>();
            Bind<ISessionUnitOfWork>().To<NHibernateUnitOfWork>();
            BindRepositories();
        }

        private void BindRepositories()
        {
            Bind<IProductRepository>().To<ProductRepository>();
        }
    }
}
