using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Quotes;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Quotes;
using WaterPoint.Core.Domain.Requests.Quotes;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Quotes
{
    public class GetQuoteProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<GetQuoteRequest, QuoteContract>
    {
        private readonly IQuery<GetQuote, Quote> _query;
        private readonly IQueryRunner _runner;

        public GetQuoteProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetQuote, Quote> query,
            IQueryRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public QuoteContract Process(GetQuoteRequest input)
        {
            _query.BuildQuery(new GetQuote
            {
                Id = input.Id,
                OrganizationId = input.OrganizationId
            });

            using (DapperUnitOfWork.Begin())
            {
                var quotetask = _runner.Run(_query);

                var result = QuoteMapper.Map(quotetask);

                return result;
            }
        }
    }
}
