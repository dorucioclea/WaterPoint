using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.JobCostItems;
using WaterPoint.Core.Domain.QueryParameters.JobCostItems;
using WaterPoint.Core.Domain.Requests.JobCostItems;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.JobCostItems
{
    public class UpdateJobCostItemProcessor :
        BaseUpdateProcessor<UpdateJobCostItemRequest, WriteJobCostItemPayload, UpdateJobCostItem, GetJobCostItem, JobCostItem>
    {
        public UpdateJobCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter adapter,
            IQuery<GetJobCostItem> getQuery,
            IQueryRunner<GetJobCostItem, JobCostItem> getRunner,
            ICommand<UpdateJobCostItem> updateQuery,
            ICommandExecutor<UpdateJobCostItem> updateExecutor)
            : base(dapperUnitOfWork, adapter, getQuery, getRunner, updateQuery, updateExecutor)
        {
        }

        public override GetJobCostItem BuildGetParameter(UpdateJobCostItemRequest input)
        {
            var getJobCostItemParam = new GetJobCostItem
            {
                Id = input.Id,
                JobId = input.JobId,
                OrganizationId = input.OrganizationId
            };

            return getJobCostItemParam;
        }
    }
}
