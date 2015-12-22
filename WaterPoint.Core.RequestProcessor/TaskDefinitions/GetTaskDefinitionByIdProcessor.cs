using WaterPoint.Core.Bll.Queries.TaskDefinitions;
using WaterPoint.Core.Bll.QueryParameters.TaskDefinitions;
using WaterPoint.Core.Bll.QueryRunners.TaskDefinitions;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.TaskDefinitions;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Requests.TaskDefinitions;
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
                OrganizationId = input.OrganizationEntityParameter.OrganizationId,
                TaskDefinitionId = input.OrganizationEntityParameter.Id
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
