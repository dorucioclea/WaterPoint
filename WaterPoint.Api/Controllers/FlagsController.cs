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
using WaterPoint.Core.Domain.Specifications;
using WaterPoint.Core.Services;

namespace WaterPoint.Api.Controllers
{
    [RoutePrefix("shops/{shopId:int}/flags")]
    public class FlagsController : BaseShopContextController
    {
        private readonly IRequestProcessor<ListProductsByFlag, IEnumerable<ProductMinimumMetaInfoContract>> _productMinimumMetaInfoContract;

        //private readonly ISpecification<ListProductsByFlag, IEnumerable<Product>> _listProductsByFlagService;

        public FlagsController(
            IUnitOfWork unitOfWork,
            IRequestProcessor<ListProductsByFlag, IEnumerable<ProductMinimumMetaInfoContract>> productMinimumMetaInfoContract)
            : base(unitOfWork)
        {
            _productMinimumMetaInfoContract = productMinimumMetaInfoContract;
        }

        [Route("{flagId:int}/products")]
        public IHttpActionResult Get([FromUri]ListProductsByFlag request)
        {
            var isRequestValid = true;

            if (!isRequestValid)
            {
                return BadRequest();
            }

            var result = _productMinimumMetaInfoContract.Process(request);

            return Ok(result);
        }
    }
}
