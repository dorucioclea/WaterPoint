using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Bll.Commands.TaskDefinitions;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.TaskDefinitions;
using WaterPoint.Core.Domain.Dtos.Requests.TaskDefinitions;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.TaskDefinitions
{
    public class CreateTaskDefinitionRequestProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<CreateTaskDefinitionRequest, TaskDefinitionContract>
    {
        private readonly CreateTaskDefinitionCommand _command;
        private readonly CreateCommandExecutor _executor;

        public CreateTaskDefinitionRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            CreateTaskDefinitionCommand command,
            CreateCommandExecutor executor)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
        }

        public TaskDefinitionContract Process(CreateTaskDefinitionRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return result;
        }

        private TaskDefinitionContract ProcessDeFacto(CreateTaskDefinitionRequest input)
        {
            var taskDefinition = new TaskDefinition
            {
                OrganizationId = input.OrganizationIdParameter.OrganizationId,
                BaseRate = input.CreateTaskDefinitionPayload.BaseRate,
                BillableRate = input.CreateTaskDefinitionPayload.BillableRate,
                Description = input.CreateTaskDefinitionPayload.Description,
                IsDeleted = input.CreateTaskDefinitionPayload.IsDeleted,
                Name = input.CreateTaskDefinitionPayload.Name
            };

            _command.BuildQuery(input.OrganizationIdParameter.OrganizationId, taskDefinition);

            var newId = _executor.Run(_command);

            taskDefinition.Id = newId;

            var result = TaskDefinitionMapper.Map(taskDefinition);

            return result;
        }
    }
}
