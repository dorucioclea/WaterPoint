using WaterPoint.Core.Bll.Queries.TaskDefinitions;
using WaterPoint.Core.Bll.QueryRunners.TaskDefinitions;
using WaterPoint.Core.RequestProcessor.Mappers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.TaskDefinitions;
using WaterPoint.Core.Domain.Dtos.Requests.TaskDefinitions;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.TaskDefinitions
{
    public class GetTaskDefinitionByIdRequestProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<GetTaskDefinitionByIdRequest, TaskDefinitionContract>
    {
        private readonly GetTaskDefinitionByIdQuery _query;
        private readonly GetTaskDefinitionByIdQueryRunner _runner;

        public GetTaskDefinitionByIdRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            GetTaskDefinitionByIdQuery query,
            GetTaskDefinitionByIdQueryRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public TaskDefinitionContract Process(GetTaskDefinitionByIdRequest input)
        {
            _query.BuildQuery(input.OrganizationEntityParameter.OrganizationId, input.OrganizationEntityParameter.Id);

            using (DapperUnitOfWork.Begin())
            {
                var taskDefinition = _runner.Run(_query);

                var result = TaskDefinitionMapper.Map(taskDefinition);

                return result;
            }
        }
    }
}
