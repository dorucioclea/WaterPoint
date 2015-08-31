using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using WaterPoint.Core.Domain.Repositories;
using WaterPoint.Core.Repository;
using WaterPoint.Core.Domain;


namespace WaterPoint.Core.DependencyInjection
{
    public class CoreDiModule : NinjectModule
    {
        public override void Load()
        {
            BindDb();
            BindRepositories();
        }

        private void BindDb()
        {
            
        }

        private void BindRepositories()
        {
            Bind<IProductRepository>().To<ProductRepository>();
        }
    }
}
