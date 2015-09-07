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
        private readonly IContractConvertor<ListProductsByFlag, IEnumerable<ProductMinimumMetaInfoContract>> _productService;

        //private readonly ISpecification<ListProductsByFlag, IEnumerable<Product>> _listProductsByFlagService;

        public FlagsController(
            IUnitOfWork unitOfWork,
            IContractConvertor<ListProductsByFlag, IEnumerable<ProductMinimumMetaInfoContract>>  productService)
            : base(unitOfWork)
        {
            _productService = productService;
        }

        [Route("{flagId:int}/products")]
        public IHttpActionResult Get([FromUri]ListProductsByFlag query)
        {
            var isRequestValid = true;

            if (!isRequestValid)
            {
                return BadRequest();
            }

            var result = _productService.Convert(query);

            return Ok(result);
        }
    }
}
