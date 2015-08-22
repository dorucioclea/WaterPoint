using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Services;

namespace WaterPoint.Api.Controllers
{
    public abstract class BaseRestaurantContextController : ApiController
    {
        //TODO: load from the db;
        protected IRestaurantContext CurrentRestaurant = new TempContext();

        public class TempContext:IRestaurantContext
        {

            public int RestaurantId
            {
                get { return 1; }
            }

            public int BranchId
            {
                get { return 1; }
            }

            public int StaffId
            {
                get { return 1; }
            }
        }
    }

    [RoutePrefix("restaurants/{restaurantId:int}/branches/{branchId:int}/groups/{groupId:int}")]
    public class TablesController : BaseRestaurantContextController
    {
        private readonly ITableService _tableService;

        public TablesController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [Route("tables")]
        public IHttpActionResult Get()
        {
            //TODO: get groupid from httpcontext;
            var groupId = 0;

            var result = _tableService.ListByGroupId(CurrentRestaurant, groupId);

            return Ok(result);
        }
    }
}
