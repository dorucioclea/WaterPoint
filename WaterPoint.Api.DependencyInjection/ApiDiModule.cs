using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Products;
using WaterPoint.Core.Domain.Repositories;
using WaterPoint.Core.Domain.SpecificationRequests.Products;
using WaterPoint.Core.Domain.Specifications;
using WaterPoint.Core.Repository;
using WaterPoint.Core.Repository.Products;
using WaterPoint.Core.Services;
using WaterPoint.Data.DbContext.NHibernate;
using Ninject.Web.Common;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Api.DependencyInjection
{
    public class ApiDiModule : NinjectModule
    {
        public override void Load()
        {
            BindConvertors();
        }

        private void BindConvertors()
        {
            Bind<IRequestProcessor<ListProductsByFlag, IEnumerable<ProductMinimumMetaInfoContract>>>()
                .To<ListProductsByFlagRequestProcessor>();

        }
    }
}
