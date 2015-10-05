using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Requests.Products;
using WaterPoint.Core.RequestProcessor.Contracts.Products;

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
        }
    }
}
