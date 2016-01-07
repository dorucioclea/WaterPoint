using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain.Contracts.JobCostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobTasks;
using WaterPoint.Core.Domain.Requests.JobCostItems;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.JobCostItems;

namespace WaterPoint.Core.RequestProcessor.JobCostItems
{
    public class ListJobCostItemsProcessor :
        SimplePagedProcessor<ListJobCostItemsRequest, ListJobCostItems, JobCostItemListPoco, JobCostItemBasicContract>
    {
        public ListJobCostItemsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListJobCostItems> listQuery,
            IPagedQueryRunner<ListJobCostItems, JobCostItemListPoco> listQueryRunner)
            : base(dapperUnitOfWork, listQuery, listQueryRunner)
        {
        }

        public override JobCostItemBasicContract Map(JobCostItemListPoco source)
        {
            return JobCostItemMapper.Map(source);
        }
    }
}
