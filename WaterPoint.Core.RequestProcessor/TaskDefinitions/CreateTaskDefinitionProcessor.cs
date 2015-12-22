using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.QueryParameters.TaskDefinitions;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.TaskDefinitions;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Requests.TaskDefinitions;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.TaskDefinitions
{
    public class CreateTaskDefinitionProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<CreateTaskDefinitionRequest, TaskDefinitionContract>
    {
        private readonly ICommand<CreateTaskDefinition> _command;
        private readonly ICommandExecutor<CreateTaskDefinition> _executor;
        private readonly IQuery<GetTaskDefinition> _getQuery;
        private readonly IQueryRunner<GetTaskDefinition, TaskDefinition> _getQueryRunner;

        public CreateTaskDefinitionProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateTaskDefinition> command,
            ICommandExecutor<CreateTaskDefinition> executor,
            IQuery<GetTaskDefinition> getQuery,
            IQueryRunner<GetTaskDefinition, TaskDefinition> getQueryRunner)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
            _getQuery = getQuery;
            _getQueryRunner = getQueryRunner;
        }

        public TaskDefinitionContract Process(CreateTaskDefinitionRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return result;
        }

        private TaskDefinitionContract ProcessDeFacto(CreateTaskDefinitionRequest input)
        {
            var parameter = new CreateTaskDefinition
            {
                OrganizationId = input.OrganizationId.OrganizationId,
                Name = input.Payload.Name,
                BaseRate = input.Payload.BaseRate.Value,
                BillableRate = input.Payload.BillableRate.Value,
                Description = input.Payload.Description
            };

            _command.BuildQuery(parameter);

            var newId = _executor.Execute(_command);

            _getQuery.BuildQuery(new GetTaskDefinition
            {
                OrganizationId = parameter.OrganizationId,
                TaskDefinitionId = newId
            });

            var taskDefinition = _getQueryRunner.Run(_getQuery);

            var result = TaskDefinitionMapper.Map(taskDefinition);

            return result;
        }
    }
}
