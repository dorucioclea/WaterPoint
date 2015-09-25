using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Products;
using WaterPoint.Core.Domain.SpecificationRequests.Products;
using WaterPoint.Core.RequestProcessor.Products;

namespace WaterPoint.Api.Flag
{
    public class FlagApiDiModule : NinjectModule
    {
        public override void Load()
        {
            BindRequestProcessors();
        }

        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<ListProductsByFlagRequest, IEnumerable<BasicProduct>>>()
                .To<ListProductsByFlagProcessor>();
        }
    }
}
