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
    [RoutePrefix(RouteDefinitions.Flags.Prefix)]
    public class FlagsController : BaseShopContextController
    {
        private readonly IRequestProcessor<ListProductsByFlag, IEnumerable<ProductMinimumMetaInfoContract>> _listProductsByFlagProcessor;

        //private readonly ISpecification<ListProductsByFlag, IEnumerable<Product>> _listProductsByFlagService;

        public FlagsController(
            IUnitOfWork unitOfWork,
            IRequestProcessor<ListProductsByFlag, IEnumerable<ProductMinimumMetaInfoContract>> listProductsByFlagProcessor)
            : base(unitOfWork)
        {
            _listProductsByFlagProcessor = listProductsByFlagProcessor;
        }

        [Route(RouteDefinitions.Flags.GetProducts)]
        public IHttpActionResult GetProducts([FromUri]ListProductsByFlag request)
        {
            var isRequestValid = true;

            if (!isRequestValid)
            {
                return BadRequest();
            }

            var result = _listProductsByFlagProcessor.Process(request);

            return Ok(result);
        }
    }
}
