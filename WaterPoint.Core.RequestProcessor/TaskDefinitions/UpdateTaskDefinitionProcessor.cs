using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters.TaskDefinitions;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.TaskDefinitions;
using WaterPoint.Core.Domain.Requests.TaskDefinitions;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.TaskDefinitions
{
    public class UpdateTaskDefinitionProcessor :
        BaseUpdateProcessor<UpdateTaskDefinitionRequest, WriteTaskDefinitionPayload, UpdateTaskDefinition, GetTaskDefinition, TaskDefinition>
    {
        public UpdateTaskDefinitionProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter adapter,
            IQuery<GetTaskDefinition, TaskDefinition> getQuery,
            IQueryRunner getRunner,
            ICommand<UpdateTaskDefinition> updateCommand,
            ICommandExecutor updateExecutor)
            : base(dapperUnitOfWork, adapter, getQuery, getRunner, updateCommand, updateExecutor)
        {
        }

        public override GetTaskDefinition BuildGetParameter(UpdateTaskDefinitionRequest input)
        {
            return new GetTaskDefinition
            {
                OrganizationId = input.OrganizationId,
                TaskDefinitionId = input.Id
            };
        }
    }
}
