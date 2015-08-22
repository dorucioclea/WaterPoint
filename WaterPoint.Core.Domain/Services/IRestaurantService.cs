using System.Threading.Tasks;
using WaterPoint.Core.Contract;

namespace WaterPoint.Core.Domain.Services
{
    public interface IRestaurantService
    {
        Task<RestaurantContract> GetByIdAsync(int restaurantId);
    }
}
