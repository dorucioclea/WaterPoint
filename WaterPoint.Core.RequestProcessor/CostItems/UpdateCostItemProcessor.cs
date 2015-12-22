using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.QueryParameters.CostItems;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.CostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Payloads.CostItems;
using WaterPoint.Core.Domain.Dtos.Requests.CostItems;
using WaterPoint.Core.Domain.Exceptions;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.CostItems
{
    public class UpdateCostItemProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<UpdateCostItemRequest, CostItemContract>
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

        public CostItemContract Process(UpdateCostItemRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return result;
        }

        private CostItemContract ProcessDeFacto(UpdateCostItemRequest input)
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

            var success = _updateCommandExecutor.Execute(_updateCostItemByIdQuery) > 0;

            if (success)
                return CostItemMapper.Map(existingCostItem);

            var updateException = new UpdateFailedException();

            updateException.AddMessage("operation is finished but there is no result returned");

            throw updateException;
        }
    }



}
