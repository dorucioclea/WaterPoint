using WaterPoint.Core.Domain.QueryParameters.TaskDefinitions;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.TaskDefinitions;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.TaskDefinitions;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.TaskDefinitions
{
    public class GetTaskDefinitionByIdRequestProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<GetTaskDefinitionByIdRequest, TaskDefinitionContract>
    {
        private readonly IQuery<GetTaskDefinition> _query;
        private readonly IQueryRunner<GetTaskDefinition, TaskDefinition> _runner;

        public GetTaskDefinitionByIdRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetTaskDefinition> query,
            IQueryRunner<GetTaskDefinition, TaskDefinition> runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public TaskDefinitionContract Process(GetTaskDefinitionByIdRequest input)
        {
            var parameter = new GetTaskDefinition
            {
                OrganizationId = input.OrganizationId,
                TaskDefinitionId = input.Id
            };

            _query.BuildQuery(parameter);

            using (DapperUnitOfWork.Begin())
            {
                var taskDefinition = _runner.Run(_query);

                var result = TaskDefinitionMapper.Map(taskDefinition);

                return result;
            }
        }
    }
}
