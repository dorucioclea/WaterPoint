using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Bll;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Repository;

namespace WaterPoint.Data.Bll
{
    public class RestaurantBll : IRestaurantBll
    {
        private readonly RestaurantRepository _restaurantRepo;

        public RestaurantBll(RestaurantRepository restaurantRepo)
        {
            _restaurantRepo = restaurantRepo;
        }

        public async Task<Restaurant> GetAsync(int restaurantId)
        {
            var restaurant = await _restaurantRepo.GetAsync(restaurantId);

            return restaurant;
        }
    }
}
