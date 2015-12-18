using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using WaterPoint.Core.Domain;
using WaterPoint.Core.RequestProcessor;
using Ninject.Web.Common;
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
    //        Bind<IRequestProcessor<ListProdu ctsByFlagRequest, IEnumerable<BasicProduct>>>()
    //            .To<ListProductsByFlagProcessor>();

    //        //Bind<IRequestProcessor<ListBannersByBannerTypeRequest, IEnumerable<BasicBanner>>>()
    //        //    .To<ListBannersByBannerTypeProcessor>();
    //    }
    //}
}
