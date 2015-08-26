using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WaterPoint.Api.BaseControllers;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Services;

namespace WaterPoint.Api.Controllers
{
    [RoutePrefix("restaurants/{restaurantId:int}/branches/{branchId:int}")]
    public class TableTypesController : BaseRestaurantContextController
    {
        private readonly ITableTypeService _tableTypeService;

        public TableTypesController(ITableTypeService tableTypeService)
        {
            _tableTypeService = tableTypeService;
        }

        [Route("tabletypes/{tableTypeId:int}")]
        public Task<TableTypeContract> Get(int tableTypeId)
        {
        }
    }
}
