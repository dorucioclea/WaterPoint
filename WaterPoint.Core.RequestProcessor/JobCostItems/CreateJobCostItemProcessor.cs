using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobCostItems;
using WaterPoint.Core.Domain.Requests.JobCostItems;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.JobCostItems
{
    public class CreateJobCostItemProcessor : BaseCreateProcessor<CreateJobCostItemRequest, CreateJobCostItem>
    {
        public CreateJobCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateJobCostItem> command,
            ICommandExecutor<CreateJobCostItem> executor)
            : base(dapperUnitOfWork, command, executor)
        {
        }

        public override CreateJobCostItem BuildParameter(CreateJobCostItemRequest input)
        {
            return new CreateJobCostItem
            {
                JobId = input.JobId,
                IsBillable = input.Payload.IsBillable.Value,
                LongDescription = input.Payload.LongDescription,
                ShortDescription = input.Payload.ShortDescription,
                Code = input.Payload.Code,
                CostItemId = input.Payload.CostItemId,
                Quantity = input.Payload.Quantity,
                UnitCost = input.Payload.UnitCost.Value,
                UnitPrice = input.Payload.UnitPrice.Value
            };
        }
    }
}
