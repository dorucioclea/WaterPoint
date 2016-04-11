using System.Collections.Generic;
using System.Linq;
using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
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
        BaseDapperUowRequestProcess,
        IListProcessor<ListJobCostItemsRequest, JobCostItemBasicContract>
    {
        private readonly IQuery<ListJobCostItems, JobCostItemListPoco> _query;
        private readonly IQueryListRunner _runner;

        public ListJobCostItemsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListJobCostItems, JobCostItemListPoco> query,
            IQueryListRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public IEnumerable<JobCostItemBasicContract> Process(ListJobCostItemsRequest input)
        {
            _query.BuildQuery(new ListJobCostItems
            {
                OrganizationId = input.OrganizationId,
                JobId = input.JobId
            });

            var result = _runner.Run(_query);

            return result.Select(JobCostItemMapper.Map);
        }
    }
}
