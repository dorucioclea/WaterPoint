using System.Collections.Generic;
using System.Linq;
using WaterPoint.Core.Domain.QueryParameters.JobTasks;
using WaterPoint.Core.Domain;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain.Contracts.JobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.JobTasks;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.JobTasks;

namespace WaterPoint.Core.RequestProcessor.JobTasks
{
    public class ListJobTasksProcessor : BaseDapperUowRequestProcess,
        IListProcessor<ListJobTasksRequest, JobTaskBasicContract>
    {
        private readonly IQuery<ListJobTasks, JobTaskBasicPoco> _query;
        private readonly IQueryListRunner _runner;

        public ListJobTasksProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListJobTasks, JobTaskBasicPoco> query,
            IQueryListRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public IEnumerable<JobTaskBasicContract> Process(ListJobTasksRequest input)
        {
            _query.BuildQuery(new ListJobTasks
            {
                OrganizationId = input.OrganizationId,
                JobId = input.JobId
            });

            var result = _runner.Run(_query);

            return result.Select(JobTaskMapper.Map);
        }
    }
}
