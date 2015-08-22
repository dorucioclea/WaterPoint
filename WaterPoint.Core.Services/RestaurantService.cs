using System.Threading.Tasks;
using WaterPoint.Core.Contract;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain.Bll;
using WaterPoint.Core.Domain.Services;

namespace WaterPoint.Core.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantBll _restaurantBll;

        public RestaurantService(IRestaurantBll restaurantBll)
        {
            _restaurantBll = restaurantBll;
        }

        public async Task<RestaurantContract> GetByIdAsync(int restaurantId)
        {
            var org = await _restaurantBll.GetAsync(restaurantId);

            var result = CoreMapperHelper.MapTo<RestaurantContract>(org);

            return result;
        }
    }
}
