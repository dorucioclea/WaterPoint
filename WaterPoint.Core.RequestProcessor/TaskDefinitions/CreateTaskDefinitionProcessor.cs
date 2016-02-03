using WaterPoint.Core.Domain.QueryParameters.TaskDefinitions;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.TaskDefinitions;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.TaskDefinitions
{
    public class CreateTaskDefinitionProcessor : BaseCreateProcessor<CreateTaskDefinitionRequest, CreateTaskDefinition>
    {
        public CreateTaskDefinitionProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateTaskDefinition> command,
            ICommandExecutor executor)
            : base(dapperUnitOfWork, command, executor)
        {
        }

        public override CreateTaskDefinition BuildParameter(CreateTaskDefinitionRequest input)
        {
            var parameter = new CreateTaskDefinition
            {
                OrganizationId = input.OrganizationId,
                ShortDescription = input.Payload.ShortDescription,
                BaseRate = input.Payload.BaseRate.Value,
                BillableRate = input.Payload.BillableRate.Value,
                LongDescription = input.Payload.LongDescription
            };

            return parameter;
        }
    }
}
