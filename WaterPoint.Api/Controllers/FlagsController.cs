using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WaterPoint.Api.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Products;
using WaterPoint.Core.Domain.Requests.Products;
using WaterPoint.Core.Domain.Services;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Api.Controllers
{
    [Route("flags")]
    public class FlagsController : BaseStoreContextController
    {
        private readonly IService<ListProductsByFlagRequest, IEnumerable<ProductContract>> _listProductsByFlagService;

        public FlagsController(
            IUnitOfWork unitOfWork,
            IService<ListProductsByFlagRequest, IEnumerable<ProductContract>> listProductsByFlagService)
            : base(unitOfWork)
        {
            _listProductsByFlagService = listProductsByFlagService;
        }

        [Route("flags/{flagId:int}/products")]
        public IHttpActionResult Get([FromUri]ListProductsByFlagRequest query)
        {
            var isRequestValid = true;

            if (!isRequestValid)
            {
                return BadRequest();
            }

            var result = _listProductsByFlagService.Run(query);

            return Ok(result);
        }
    }
}
