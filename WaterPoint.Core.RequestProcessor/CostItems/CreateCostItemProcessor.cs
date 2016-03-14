using WaterPoint.Core.Domain.QueryParameters.CostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.CostItems;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.CostItems
{
    public class CreateCostItemProcessor : BaseCreateProcessor<CreateCostItemRequest, CreateCostItem>
    {
        public CreateCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateCostItem> command,
            ICommandExecutor executor)
            : base(dapperUnitOfWork, command, executor)
        {
        }

        public override CreateCostItem BuildParameter(CreateCostItemRequest input)
        {
            return new CreateCostItem
            {
                OrganizationId = input.OrganizationId,
                Code = input.Payload.Code,
                IsBillable = input.Payload.IsBillable,
                LongDescription = input.Payload.LongDescription,
                ShortDescription = input.Payload.ShortDescription,
                SupplierId = input.Payload.SupplierId,
                UnitCost = input.Payload.UnitCost,
                UnitPrice = input.Payload.UnitPrice,
                UnitOfMeasurementId = input.Payload.UnitOfMeasurementId,
                CostItemTypeId = input.Payload.CostItemTypeId
            };
        }
    }
}
