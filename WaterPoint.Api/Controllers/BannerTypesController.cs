﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ninject.Activation;
using WaterPoint.Api.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Banners;
using WaterPoint.Core.Domain.Contracts.Products;
using WaterPoint.Core.Domain.SpecificationRequests.Banners;
using WaterPoint.Core.Domain.SpecificationRequests.Products;

namespace WaterPoint.Api.Controllers
{
    [RoutePrefix(RouteDefinitions.Banners.Prefix)]
    public class BannerTypesController : BaseShopContextController
    {
        private readonly IRequestProcessor<ListBannersByBannerTypeRequest, IEnumerable<BasicBanner>> _listBannersByBannerTypeRequestProcessor;

        public BannerTypesController(
            IRequestProcessor<ListBannersByBannerTypeRequest, IEnumerable<BasicBanner>> listBannersByBannerTypeRequestProcessor)
        {
            _listBannersByBannerTypeRequestProcessor = listBannersByBannerTypeRequestProcessor;
        }

        [Route(RouteDefinitions.Banners.GetBanners)]
        public IHttpActionResult GetBanners([FromUri]ListBannersByBannerTypeRequest request)
        {
            var result = _listBannersByBannerTypeRequestProcessor.GetResult(request);

            return Ok(result);
        }
    }
}