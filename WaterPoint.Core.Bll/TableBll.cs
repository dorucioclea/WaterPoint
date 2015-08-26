//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Transactions;
//using WaterPoint.Core.Domain;
//using WaterPoint.Core.Domain.Bll;
//using WaterPoint.Core.Domain.Repositories;
//using WaterPoint.Data.Entity;

//namespace WaterPoint.Core.Bll
//{
//    public class TableBll : ITableBll
//    {
//        private readonly ITableRepository _tableRepository;

//        public TableBll(ITableRepository tableRepository)
//        {
//            _tableRepository = tableRepository;
//        }

//        public async Task Ttt()
//        {
//            await _tableRepository.Ttt();
//        }

//        public async Task<IEnumerable<Table>> ListByGroupId(IRestaurantContext currentRestaurant, int groupId)
//        {
//            using (var scope = new TransactionScope())
//            {
//                try
//                {
//                    var result = await _tableRepository
//                        .GetByGroupIdAsync(
//                            currentRestaurant.RestaurantId,
//                            currentRestaurant.BranchId,
//                            groupId);

//                    scope.Complete();

//                    return result;
//                }
//                catch
//                {
//                    scope.Dispose();
//                    throw;
//                }
//            }
//        }
//    }
//}
