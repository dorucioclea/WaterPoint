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

namespace WaterPoint.Core.RequestProcessor.Quotes
{
    public class CreateQuoteTaskProcessor :
        BaseDapperUowRequestProcess,
        IWriteRequestProcessor<CreateQuoteTaskRequest>
    {
        private readonly ICommand<CreateQuoteTask> _command;
        private readonly ICommandExecutor<CreateQuoteTask> _executor;

        public CreateQuoteTaskProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateQuoteTask> command,
            ICommandExecutor<CreateQuoteTask> executor)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
        }

        public CommandResult Process(CreateQuoteTaskRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResult(result, "Quote task", result > 0);
        }

        private static CreateQuoteTask GetParameter(CreateQuoteTaskRequest input)
        {
            var createQuoteTask = input.MapTo(new CreateQuoteTask());

            input.Payload.MapTo(createQuoteTask);

            return createQuoteTask;
        }

        private int ProcessDeFacto(CreateQuoteTaskRequest input)
        {
            var createQuote = GetParameter(input);

            _command.BuildQuery(createQuote);

            return _executor.Execute(_command);
        }
    }
}
