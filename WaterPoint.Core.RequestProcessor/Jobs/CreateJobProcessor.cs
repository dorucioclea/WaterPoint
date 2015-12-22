using WaterPoint.Core.Bll.QueryParameters.Jobs;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Requests.Jobs;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    public class CreateJobProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<CreateJobRequest, JobWithDetailsContract>
    {
        private readonly ICommand<CreateBasicJob> _command;
        private readonly ICommandExecutor<CreateBasicJob> _executor;
        private readonly IQuery<GetJobDetails> _getQuery;
        private readonly IQueryRunner<GetJobDetails, JobWithDetailsPoco> _getQueryRunner;

        public CreateJobProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateBasicJob> command,
            ICommandExecutor<CreateBasicJob> executor,
            IQuery<GetJobDetails> getQuery,
            IQueryRunner<GetJobDetails, JobWithDetailsPoco> getQueryRunner)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
            _getQuery = getQuery;
            _getQueryRunner = getQueryRunner;
        }

        public JobWithDetailsContract Process(CreateJobRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return result;
        }

        private JobWithDetailsContract  ProcessDeFacto(CreateJobRequest input)
        {
            var parameter = new CreateBasicJob
            {
                OrganizationId = input.OrganizationIdParameter.OrganizationId,
                JobStatusId = input.CreateJobPayload.JobStatusId.Value,
                Code = input.CreateJobPayload.Code,
                ShortDescription = input.CreateJobPayload.ShortDescription,
                CustomerId = input.CreateJobPayload.CustomerId.Value,
                StartDate = input.CreateJobPayload.StartDate.Value,
                EndDate = input.CreateJobPayload.EndDate.Value
            };

            _command.BuildQuery(parameter);

            var newId = _executor.Execute(_command);

            _getQuery.BuildQuery(new GetJobDetails {JobId = newId, OrganizationId = parameter.OrganizationId});

            var job = _getQueryRunner.Run(_getQuery);

            return JobMapper.Map(job);
        }
    }
}
