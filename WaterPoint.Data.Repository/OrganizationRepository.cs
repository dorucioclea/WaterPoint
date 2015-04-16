using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.DbContext;
using WaterPoint.Data.Entity;

namespace WaterPoint.Data.Repository
{
    public class OrganizationRepository : RepositoryBase<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<Organization> GetAsync(int id)
        {
            //var result = await DbContext.QueryAsync<Organization>(OrganizationScripts.GetAsync, new { id });

            //return result.FirstOrDefault();

            return await Task.Run(() => new Organization
            {
                Id = id,
                Name = "water point ltd",
                DisplayName = "Water point Ltd.",
                Uid = Guid.NewGuid().ToString()
            });
        }
    }
}
