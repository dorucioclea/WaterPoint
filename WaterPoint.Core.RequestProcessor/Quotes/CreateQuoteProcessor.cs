using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Quotes;
using WaterPoint.Core.Domain.Requests.Quotes;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Enums;

namespace WaterPoint.Core.RequestProcessor.Quotes
{
    public class CreateQuoteProcessor : BaseCreateProcessor<CreateQuoteRequest, CreateQuote>
    {
        public CreateQuoteProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateQuote> command,
            ICommandExecutor<CreateQuote> executor)
            : base(dapperUnitOfWork, command, executor)
        {
        }

        public override CreateQuote BuildParameter(CreateQuoteRequest input)
        {
            var createQuote = input.Payload.MapTo(new CreateQuote());

            createQuote.QuoteStatusId = (int)QuoteStatuses.Draft;

            createQuote.OrganizationId = input.OrganizationId;

            createQuote.CustomerId = input.CustomerId;

            return createQuote;
        }
    }
}
