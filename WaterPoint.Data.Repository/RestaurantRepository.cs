using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.DbContext;
using WaterPoint.Data.Entity;

namespace WaterPoint.Data.Repository
{
    public class RestaurantRepository : RepositoryBase<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<Restaurant> GetAsync(int id)
        {
            //var result = await DbContext.QueryAsync<Restaurant>(RestaurantScripts.GetAsync, new { id });

            //return result.FirstOrDefault();

            return await Task.Run(() => new Restaurant
            {
                Id = id,
                Name = "water point ltd",
                DisplayName = "Water point Ltd.",
                Uid = Guid.NewGuid().ToString()
            });
        }
    }
}
