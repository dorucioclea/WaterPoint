using WaterPoint.Core.Bll.QueryParameters.CostItems;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.CostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Requests.CostItems;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.CostItems
{
    public class CreateCostItemProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<CreateCostItemRequest, CostItemContract>
    {
        private readonly ICommand<CreateCostItem> _command;
        private readonly ICommandExecutor<CreateCostItem> _executor;
        private readonly IQuery<GetCostItem> _query;
        private readonly IQueryRunner<GetCostItem, CostItem> _queryRunner;

        public CreateCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateCostItem> command,
            ICommandExecutor<CreateCostItem> executor,
            IQuery<GetCostItem> query,
            IQueryRunner<GetCostItem, CostItem> queryRunner)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
            _query = query;
            _queryRunner = queryRunner;
        }

        public CostItemContract Process(CreateCostItemRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return result;
        }

        private CostItemContract ProcessDeFacto(CreateCostItemRequest input)
        {
            var parameter = new CreateCostItem
            {
                OrganizationId = input.OrganizationIdParameter.OrganizationId,
                Code = input.CreateCustomerPayload.Code,
                IsBillable = input.CreateCustomerPayload.IsBillable,
                LongDescription = input.CreateCustomerPayload.LongDescription,
                ShortDescription = input.CreateCustomerPayload.ShortDescription,
                SupplierId = input.CreateCustomerPayload.SupplierId,
                UnitCost = input.CreateCustomerPayload.UnitCost,
                UnitPrice = input.CreateCustomerPayload.UnitPrice
            };

            _command.BuildQuery(parameter);

            var newId = _executor.Execute(_command);

            _query.BuildQuery(new GetCostItem
            {
                OrganizationId = input.OrganizationIdParameter.OrganizationId,
                CostItemId = newId
            });

            var costItem = _queryRunner.Run(_query);

            var result = CostItemMapper.Map(costItem);

            return result;
        }
    }
}
