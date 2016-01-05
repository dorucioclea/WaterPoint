using WaterPoint.Api.Common;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.QuoteCostItems;
using WaterPoint.Core.Domain.QueryParameters.QuoteCostItems;
using WaterPoint.Core.Domain.Requests.QuoteCostItems;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.QuoteCostItems
{
    public class UpdateQuoteCostItemProcessor :
        BaseDapperUowRequestProcess,
        IWriteRequestProcessor<UpdateQuoteCostItemRequest>
    {
        private readonly IPatchEntityAdapter _patchEntityAdapter;
        private readonly ICommand<UpdateQuoteCostItem> _command;
        private readonly ICommandExecutor<UpdateQuoteCostItem> _executor;
        private readonly IQuery<GetQuoteCostItem> _query;
        private readonly IQueryRunner<GetQuoteCostItem, QuoteCostItem> _runner;

        public UpdateQuoteCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter patchEntityAdapter,
            ICommand<UpdateQuoteCostItem> command,
            ICommandExecutor<UpdateQuoteCostItem> executor,
            IQuery<GetQuoteCostItem> query,
            IQueryRunner<GetQuoteCostItem, QuoteCostItem> runner)
            : base(dapperUnitOfWork)
        {
            _patchEntityAdapter = patchEntityAdapter;
            _command = command;
            _executor = executor;
            _query = query;
            _runner = runner;
        }

        public CommandResult Process(UpdateQuoteCostItemRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResult(result, "job task", result > 0);
        }

        private int ProcessDeFacto(UpdateQuoteCostItemRequest input)
        {
            var getQuoteCostItemParam = new GetQuoteCostItem
            {
                Id = input.Id,
                OrganizationId = input.OrganizationId,
                QuoteId = input.QuoteId
            };

            _query.BuildQuery(getQuoteCostItemParam);

            var existingQuoteCostItem = _runner.Run(_query);

            var updatedQuoteCostItem = _patchEntityAdapter
                .PatchEnitity<UpdateQuoteCostItemPayload, QuoteCostItem, UpdateQuoteCostItem>
                (existingQuoteCostItem, input.Payload.Patch);

            //then build the query to update the object.
            _command.BuildQuery(updatedQuoteCostItem);

            return _executor.Execute(_command);
        }
    }
}
