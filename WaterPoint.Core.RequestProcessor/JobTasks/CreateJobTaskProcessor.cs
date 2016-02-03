using WaterPoint.Core.Domain.QueryParameters.JobTasks;
using WaterPoint.Core.Domain.QueryParameters.TaskDefinitions;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.JobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.JobTasks;
using WaterPoint.Core.Domain.Exceptions;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.JobTasks
{
    public class CreateJobTaskRequestProcessor : BaseCreateProcessor<CreateJobTaskRequest, CreateJobTask>
    {
        public CreateJobTaskRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateJobTask> command,
            ICommandExecutor executor)
            : base(dapperUnitOfWork, command, executor)
        {
        }

        public override CreateJobTask BuildParameter(CreateJobTaskRequest input)
        {
            return new CreateJobTask
            {
                OrganizationId = input.OrganizationId,
                TaskDefinitionId = input.Payload.TaskDefinitionId.Value,
                JobId = input.JobId,
                CompletedDate = input.Payload.CompletedDate,
                DisplayOrder = input.Payload.DisplayOrder,
                EndDate = input.Payload.EndDate,
                EstimatedTimeInMinutes = input.Payload.EstimatedTimeInMinutes,
                IsBillable = input.Payload.IsBillable.Value,
                LongDescription = input.Payload.LongDescription,
                ShortDescription = input.Payload.ShortDescription,
                StartDate = input.Payload.StartDate,
                BillableRate = input.Payload.BillableRate,
                BaseRate = input.Payload.BaseRate
            };
        }
    }
}
