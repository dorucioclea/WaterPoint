using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.QuoteCostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.QuoteCostItems;
using WaterPoint.Core.Domain.Requests.QuoteCostItems;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.QuoteCostItems;

namespace WaterPoint.Core.RequestProcessor.QuoteCostItems
{
    public class ListQuoteCostItemsProcessor :
        SimplePagedProcessor<ListQuoteCostItemsRequest, ListQuoteCostItems, QuoteCostItemBasicPoco, QuoteCostItemBasicContract>
    {
        public ListQuoteCostItemsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListQuoteCostItems, QuoteCostItemBasicPoco> listQuery,
            IPagedQueryRunner listQueryRunner)
            : base(dapperUnitOfWork, listQuery, listQueryRunner)
        {
        }

        public override QuoteCostItemBasicContract Map(QuoteCostItemBasicPoco source)
        {
            return QuoteCostItemMapper.Map(source);
        }
    }
}
