using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Repositories;
using WaterPoint.Core.Repository;
using WaterPoint.Data.DbContext;
using WaterPoint.Data.DbContext.NHibernate;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Repository
{
    public class TableTypeRepository : RepositoryBase<Table>, ITableTypeRepository
    {
        public TableTypeRepository(ISessionUnitOfWork sessionUnitOfWork)
            : base(sessionUnitOfWork)
        {
        }

        //public async Task<IEnumerable<TableType>> GetById(int )
        //{
        //    using (var trans = new TransactionScope())
        //    {
        //    }


        //}
    }
}
