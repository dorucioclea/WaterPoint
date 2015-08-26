using System.Threading.Tasks;
using WaterPoint.Core.Domain.Contracts;

namespace WaterPoint.Core.Domain.Services
{
    public interface IRestaurantService
    {
        Task<RestaurantContract> GetByIdAsync(int restaurantId);
    }
}
