using System;
using WaterPoint.Core.Bll.Queries.JobTasks;
using WaterPoint.Core.Bll.QueryRunners.JobTasks;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.JobTasks;
using WaterPoint.Core.Domain.Dtos.Requests.JobTasks;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.JobTasks
{
    public class GetJobTaskByIdRequestProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<GetJobTaskByIdRequest, JobTaskContract>
    {
        private readonly GetJobTaskByIdQuery _query;
        private readonly GetJobTaskByIdQueryRunner _runner;

        public GetJobTaskByIdRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            GetJobTaskByIdQuery query,
            GetJobTaskByIdQueryRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public JobTaskContract Process(GetJobTaskByIdRequest input)
        {
            throw new NotImplementedException();

            _query.BuildQuery(input.OrganizationEntityParameter.Id);

            using (DapperUnitOfWork.Begin())
            {
                var taskDefinition = _runner.Run(_query);

                var result = JobTaskMapper.Map(taskDefinition);

                return result;
            }
        }
    }
}
