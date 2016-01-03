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
    public class CreateQuoteProcessor : BaseDapperUowRequestProcess,
        IWriteRequestProcessor<CreateQuoteRequest>
    {
        private readonly ICommand<CreateQuote> _command;
        private readonly ICommandExecutor<CreateQuote> _executor;

        public CreateQuoteProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateQuote> command,
            ICommandExecutor<CreateQuote> executor)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
        }

        public CommandResult Process(CreateQuoteRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResult(result, "Quote", result > 0);
        }

        private static CreateQuote GetParameter(CreateQuoteRequest input)
        {
            var createQuote = input.Payload.MapTo(new CreateQuote());

            createQuote.QuoteStatusId = (int)QuoteStatuses.Draft;

            createQuote.OrganizationId = input.OrganizationId;

            createQuote.CustomerId = input.CustomerId;

            return createQuote;
        }

        private int ProcessDeFacto(CreateQuoteRequest input)
        {
            var createQuote = GetParameter(input);

            _command.BuildQuery(createQuote);

            return _executor.Execute(_command);
        }
    }
}
