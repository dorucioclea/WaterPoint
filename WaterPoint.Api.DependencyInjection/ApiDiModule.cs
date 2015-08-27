﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Services;
using WaterPoint.Core.Services;
using WaterPoint.Data.DbContext.NHibernate;
using Ninject.Web.Common;

namespace WaterPoint.Api.DependencyInjection
{
    public class ApiDiModule : NinjectModule
    {
        public override void Load()
        {
            BindServices();
        }

        private void BindServices()
        {
            Bind<IRestaurantService>().To<RestaurantService>();
            Bind<ITableTypeService>().To<TableTypeService>();
            Bind<IUnitOfWork>().To<NHibernateUnitOfWork>();
        }
    }
}
