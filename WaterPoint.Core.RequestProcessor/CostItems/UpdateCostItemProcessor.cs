using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters.CostItems;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.CostItems;
using WaterPoint.Core.Domain.Requests.CostItems;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.CostItems
{
    public class UpdateCostItemProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<UpdateCostItemRequest, CommandResultContract>
    {
        private readonly IPatchEntityAdapter _patchEntityAdapter;
        private readonly IQuery<GetCostItem> _getCostItemByIdQuery;
        private readonly IQueryRunner<GetCostItem, CostItem> _getCostItemByIdQueryRunner;
        private readonly ICommand<UpdateCostItem> _updateCostItemByIdQuery;
        private readonly ICommandExecutor<UpdateCostItem> _updateCommandExecutor;

        public UpdateCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter patchEntityAdapter,
            IQuery<GetCostItem> getCostItemByIdQuery,
            IQueryRunner<GetCostItem, CostItem> getCostItemByIdQueryRunner,
            ICommand<UpdateCostItem> updateCostItemByIdQuery,
            ICommandExecutor<UpdateCostItem> updateCommandExecutor)
            : base(dapperUnitOfWork)
        {
            _patchEntityAdapter = patchEntityAdapter;
            _getCostItemByIdQuery = getCostItemByIdQuery;
            _getCostItemByIdQueryRunner = getCostItemByIdQueryRunner;
            _updateCostItemByIdQuery = updateCostItemByIdQuery;
            _updateCommandExecutor = updateCommandExecutor;
        }

        public CommandResultContract Process(UpdateCostItemRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResultContract(result, "cost item", result > 0);
        }

        private int ProcessDeFacto(UpdateCostItemRequest input)
        {
            var getCusParam = new GetCostItem
            {
                CostItemId = input.Parameter.Id,
                OrganizationId = input.Parameter.OrganizationId
            };

            _getCostItemByIdQuery.BuildQuery(getCusParam);

            var existingCostItem = _getCostItemByIdQueryRunner.Run(_getCostItemByIdQuery);

            var updatedCostItem = _patchEntityAdapter.PatchEnitity<WriteCostItemPayload, CostItem, UpdateCostItem>(
                existingCostItem,
                input.Payload.Patch);

            var updateParameter = updatedCostItem.MapTo(new UpdateCostItem());

            //then build the query to update the object.
            _updateCostItemByIdQuery.BuildQuery(updateParameter);

            return _updateCommandExecutor.Execute(_updateCostItemByIdQuery);
        }
    }



}
