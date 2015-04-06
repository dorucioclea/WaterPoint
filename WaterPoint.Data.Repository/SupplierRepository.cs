using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.DbContext;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Repository.Interfaces;

namespace WaterPoint.Data.Repository
{
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(IDbContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<IEnumerable<Supplier>> ListAllAsync(int organizationId)
        {
            var result = await DbContext.ListAsync<Supplier>(
                SupplierScripts.ListAllAsync,
                new { organizationId });

            return result;
        }

        public async Task<Supplier> GetAsync(int organizationId, int id)
        {
            var result = await DbContext.ListAsync<Supplier>(
                SupplierScripts.GetAsync,
                new
                {
                    id,
                    organizationId
                });

            return result.FirstOrDefault();
        }
    }
}
