using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WaterPoint.Api.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Products;
using WaterPoint.Core.Domain.SpecificationRequests.Products;

namespace WaterPoint.Api.Controllers
{
    [RoutePrefix(RouteDefinitions.Banners.Prefix)]
    public class BannerTypesController : BaseShopContextController
    {
        public BannerTypesController(
            IUnitOfWork unitOfWork
            )
            : base(unitOfWork)
        {

        }

        [Route(RouteDefinitions.Banners.GetBanners)]
        public IHttpActionResult GetBanners()
        {
            return Ok();
        }
    }
}
