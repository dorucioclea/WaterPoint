using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Repositories;
using WaterPoint.Core.Repository;
using WaterPoint.Data.DbContext;
using WaterPoint.Data.Entity;

namespace WaterPoint.Core.Repository
{
    public class TableRepository : RepositoryBase<Table>, ITableRepository
    {
        public TableRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<IEnumerable<Table>> GetByGroupIdAsync(int restaurantId, int branchId, int groupId)
        {
            var result = Enumerable.Range(1, 10).Select(i =>
                new Table
                {
                    Id = 1,
                    BranchId = 1,
                    Code = string.Format("table {0}", 1),
                    MaxNumberOfSeats = 5,
                    NumberOfSeats = 4
                }).ToArray();

            return await Task.Run(() => result).ConfigureAwait(false);
        }
    }
}
