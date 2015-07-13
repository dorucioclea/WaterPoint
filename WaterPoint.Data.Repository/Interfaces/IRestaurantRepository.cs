using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity;

namespace WaterPoint.Data.Repository
{
    public interface IRestaurantRepository
    {
        Task<Restaurant> GetAsync(int id);
    }
}
