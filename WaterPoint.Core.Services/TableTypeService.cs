using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Bll;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Services;

namespace WaterPoint.Core.Services
{
    public class TableTypeService : ITableTypeService
    {
        private readonly ITableTypeBll _tableTypeBll;

        public TableTypeService(ITableTypeBll tableTypeBll)
        {
            _tableTypeBll = tableTypeBll;
        }

        public Task<TableTypeContract> GetByBranchId(IRestaurantContext restaurantContext)
        {
        }
    }

    public interface ITableTypeBll
    {

    }
}
