using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain.Contracts.Quotes;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Quotes;
using WaterPoint.Core.Domain.Requests.Quotes;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.Quotes;

namespace WaterPoint.Core.RequestProcessor.Quotes
{
    public class ListQuotesProcessor :
        SimplePagedProcessor<ListQuotesRequest, ListQuotes, QuoteBasicPoco, QuoteBasicContract>
    {
        public ListQuotesProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListQuotes, QuoteBasicPoco> listQuery,
            IPagedQueryRunner listRunner)
            : base(dapperUnitOfWork, listQuery, listRunner)
        {
        }

        public override QuoteBasicContract Map(QuoteBasicPoco source)
        {
            return QuoteMapper.Map(source);
        }
    }
}
