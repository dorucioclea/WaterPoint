using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WaterPoint.Api.Domain.Services;

namespace WaterPoint.Api.Controllers
{
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        //[Route(Routes.Restaurants.Get)]
        //public async Task<IHttpActionResult> Get()
        //{
        
        //}

        [Route(Routes.Restaurants.GetById)]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var result = await _restaurantService.GetByIdAsync(id);

            return Ok(result);
        }
    }
    
}
