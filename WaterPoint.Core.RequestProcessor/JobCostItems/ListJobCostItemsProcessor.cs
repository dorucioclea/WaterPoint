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
            IPagedQueryRunner<ListJobCostItems, JobCostItemListPoco> listQueryRunner,
            SimplePaginationParameterConverter converter)
            :base(dapperUnitOfWork, listQuery, listQueryRunner, converter)
        {
        }

        public override JobCostItemBasicContract Map(JobCostItemListPoco source)
        {
            return JobCostItemMapper.Map(source);
        }

        public override ListJobCostItems GetParameter(ListJobCostItemsRequest input)
        {
            var parameter = Converter.Convert(input, "Id")
                .MapTo(new ListJobCostItems());

            parameter.OrganizationId = input.OrganizationId;
            parameter.JobId = input.JobId;

            return parameter;
        }
    }
}
