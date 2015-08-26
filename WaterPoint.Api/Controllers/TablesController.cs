//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using WaterPoint.Api.BaseControllers;
//using WaterPoint.Core.Domain;
//using WaterPoint.Core.Domain.Services;

//namespace WaterPoint.Api.Controllers
//{
//    [RoutePrefix("restaurants/{restaurantId:int}/branches/{branchId:int}/groups/{groupId:int}")]
//    public class TablesController : BaseRestaurantContextController
//    {
//        private readonly ITableService _tableService;

//        public TablesController(ITableService tableService)
//        {
//            _tableService = tableService;
//        }

//        //[Route("tables")]
//        //public IHttpActionResult Get()
//        //{
//        //    _tableService.Ttt();

//        //    return Ok();

//        //    //TODO: get groupid from httpcontext;
//        //    //var groupId = 0;

//        //    //var result = _tableService.ListByGroupId(CurrentRestaurant, groupId);

//        //    //return Ok(result);
//        //}
//    }
//}
