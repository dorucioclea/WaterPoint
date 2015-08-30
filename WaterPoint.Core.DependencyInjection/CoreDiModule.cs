﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using WaterPoint.Core.Bll;
using WaterPoint.Core.Domain.Repositories;
using WaterPoint.Core.Repository;
using WaterPoint.Core.Domain.Bll;
using WaterPoint.Core.Domain.DataProvider;
using WaterPoint.Core.Domain;


namespace WaterPoint.Core.DependencyInjection
{
    public class CoreDiModule : NinjectModule
    {
        public override void Load()
        {
            BindDb();
            BindRepositories();
            BindBlls();
        }

        private void BindDb()
        {
            
        }

        private void BindRepositories()
        {
            Bind<IRestaurantRepository>().To<RestaurantRepository>();
            Bind<IProductRepository>().To<ProductRepository>();
        }

        private void BindBlls()
        {
            Bind<IRestaurantBll>().To<RestaurantBll>();
        }
    }
}
