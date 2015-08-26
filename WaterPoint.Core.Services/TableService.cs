//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using WaterPoint.Core.ContractMapper;
//using WaterPoint.Core.Domain;
//using WaterPoint.Core.Domain.Bll;
//using WaterPoint.Core.Domain.Contracts;
//using WaterPoint.Core.Domain.Services;

//namespace WaterPoint.Core.Services
//{
//    public class TableService : ITableService
//    {
//        private readonly ITableBll _tableBll;

//        public TableService(ITableBll tableBll)
//        {
//            _tableBll = tableBll;
//        }

//        public async Task<IEnumerable<TableContract>> ListByGroupId(IRestaurantContext restaurantContext, int groupId)
//        {
//            var taskResult = await _tableBll.ListByGroupId(restaurantContext, groupId).ConfigureAwait(false);

//            //do something that doesn't require the actual results 

//            var result =  taskResult;

//            return result.Select(CoreMapperHelper.MapTo<TableContract>);
//        }

//        public async Task Ttt()
//        {
//            await _tableBll.Ttt();
//        }
//    }
//}
