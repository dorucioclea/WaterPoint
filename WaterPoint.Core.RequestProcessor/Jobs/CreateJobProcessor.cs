using WaterPoint.Core.Domain.QueryParameters.Jobs;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.Jobs;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    public class CreateJobProcessor : BaseCreateProcessor<CreateJobRequest, CreateJob>
    {
        public CreateJobProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateJob> command,
            ICommandExecutor executor)
            : base(dapperUnitOfWork, command, executor)
        {
        }

        public override CreateJob BuildParameter(CreateJobRequest input)
        {
            return new CreateJob
            {
                OrganizationId = input.OrganizationId,
                JobStatusId = input.Payload.JobStatusId.Value,
                Code = input.Payload.Code,
                ShortDescription = input.Payload.ShortDescription,
                CustomerId = input.Payload.CustomerId.Value,
                StartDate = input.Payload.StartDate.Value,
                EndDate = input.Payload.EndDate.Value,
                PriorityTypeId = input.Payload.PriorityTypeId,
                JobCategoryId = input.Payload.JobCategoryId,
                LongDescription = input.Payload.LongDescription,
                DueDate = input.Payload.DueDate,
                Budget = input.Payload.Budget,
                ExcludeFromWip = input.Payload.ExcludeFromWip ?? false
            };
        }
    }
}
