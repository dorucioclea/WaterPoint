using System.Threading.Tasks;
using WaterPoint.Core.Domain.Bll;
using WaterPoint.Core.Domain.Repositories;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll
{
    public class RestaurantBll : IRestaurantBll
    {
        private readonly IRestaurantRepository _restaurantRepo;

        public RestaurantBll(IRestaurantRepository restaurantRepo)
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
