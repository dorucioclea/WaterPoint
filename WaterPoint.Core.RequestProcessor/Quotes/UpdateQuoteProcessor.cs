using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters.Quotes;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.Quotes;
using WaterPoint.Core.Domain.Requests.Quotes;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Quotes
{
    public class UpdateQuoteProcessor :
        BaseUpdateProcessor<UpdateQuoteRequest, UpdateQuotePayload, UpdateQuote, GetQuote, Quote>
    {
        public UpdateQuoteProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter adapter,
            IQuery<GetQuote> getQuery,
            IQueryRunner<GetQuote, Quote> getRunner,
            ICommand<UpdateQuote> updateCommand,
            ICommandExecutor<UpdateQuote> updateExecutor)
            : base(dapperUnitOfWork, adapter, getQuery, getRunner, updateCommand, updateExecutor)
        {
        }

        public override GetQuote BuildGetParameter(UpdateQuoteRequest input)
        {
            return new GetQuote
            {
                OrganizationId = input.OrganizationId,
                Id = input.Id
            };
        }
    }
}
