using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Banners;
using WaterPoint.Core.Domain.Contracts.Products;
using WaterPoint.Core.Domain.Repositories;
using WaterPoint.Core.Domain.SpecificationRequests.Banners;
using WaterPoint.Core.Domain.SpecificationRequests.Products;
using WaterPoint.Core.RequestProcessor;
using Ninject.Web.Common;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.RequestProcessor.Products;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Api.DependencyInjection
{
    //public class ApiDiModule : NinjectModule
    //{
    //    public override void Load()
    //    {
    //        BindRequestProcessors();
    //    }

    //    private void BindRequestProcessors()
    //    {
    //        Bind<IRequestProcessor<ListProductsByFlagRequest, IEnumerable<BasicProduct>>>()
    //            .To<ListProductsByFlagProcessor>();

    //        //Bind<IRequestProcessor<ListBannersByBannerTypeRequest, IEnumerable<BasicBanner>>>()
    //        //    .To<ListBannersByBannerTypeProcessor>();
    //    }
    //}
}
