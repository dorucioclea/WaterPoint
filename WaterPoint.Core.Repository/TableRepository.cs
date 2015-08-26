//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WaterPoint.Core.Domain.Repositories;
//using WaterPoint.Core.Repository;
//using WaterPoint.Data.DbContext;
//using WaterPoint.Data.Entity;

//namespace WaterPoint.Core.Repository
//{
//    public class TableRepository : RepositoryBase<Table>, ITableRepository
//    {
//        public TableRepository(IDbContext dbContext)
//            : base(dbContext)
//        {
//        }

//        public async Task Ttt()
//        {
//            await DbContext.NonQuery("insert into dbo.[group] (name) values ( 'abc') ", null);
//        }

//        public async Task<IEnumerable<Table>> GetByGroupIdAsync(int restaurantId, int branchId, int groupId)
//        {
//            using(var trans = new TransactionScope())


//        }
//    }
//}
