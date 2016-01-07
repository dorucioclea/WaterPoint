using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters.JobTasks;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain.Contracts.JobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.JobTasks;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.JobTasks;

namespace WaterPoint.Core.RequestProcessor.JobTasks
{
    public class ListJobTasksProcessor :
        SimplePagedProcessor<ListJobTasksRequest, ListJobTasks, JobTaskBasicPoco, JobTaskBasicContract>
    {
        public ListJobTasksProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListJobTasks> listQuery,
            IPagedQueryRunner<ListJobTasks, JobTaskBasicPoco> listQueryRunner)
            : base(dapperUnitOfWork, listQuery, listQueryRunner)
        {
        }

        public override JobTaskBasicContract Map(JobTaskBasicPoco source)
        {
            return JobTaskMapper.Map(source);
        }
    }
}
