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
    public class TableTypeRepository : RepositoryBase<Table>, ITableTypeRepository
    {
        public TableTypeRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<IEnumerable<TableType>> GetById(int )
        {
            using (var trans = new TransactionScope())
            {
            }


        }
    }
}
