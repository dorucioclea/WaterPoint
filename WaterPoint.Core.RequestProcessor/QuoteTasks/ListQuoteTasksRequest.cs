using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain.Contracts.QuoteTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.QuoteTasks;
using WaterPoint.Core.Domain.Requests.QuoteTasks;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.QuoteTasks;

namespace WaterPoint.Core.RequestProcessor.QuoteTasks
{
    public class ListQuoteTasksProcessor :
        SimplePagedProcessor<ListQuoteTasksRequest, ListQuoteTasks, QuoteTaskBasicPoco, QuoteTaskBasicContract>
    {
        public ListQuoteTasksProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListQuoteTasks> listQuery,
            IPagedQueryRunner<ListQuoteTasks, QuoteTaskBasicPoco> listRunner)
            : base(dapperUnitOfWork, listQuery, listRunner)
        {
        }

        public override QuoteTaskBasicContract Map(QuoteTaskBasicPoco source)
        {
            return QuoteTaskMapper.Map(source);
        }
    }
}
