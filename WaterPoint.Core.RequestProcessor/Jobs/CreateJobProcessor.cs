using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Bll.Commands.Jobs;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.QueryParameters;
using WaterPoint.Core.Bll.QueryParameters.Jobs;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Contracts.JobStatuses;
using WaterPoint.Core.Domain.Dtos.Requests.Jobs;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    public class CreateJobProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<CreateJobRequest, JobWithCustomerContract>
    {
        private readonly ICommand<CreateBasicJobQueryParameter> _command;
        private readonly ICommandExecutor<CreateBasicJobQueryParameter> _executor;

        public CreateJobProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateBasicJobQueryParameter> command,
            ICommandExecutor<CreateBasicJobQueryParameter> executor)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
        }

        public JobWithCustomerContract Process(CreateJobRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return result;
        }

        private JobWithCustomerContract ProcessDeFacto(CreateJobRequest input)
        {
            var parameter = new CreateBasicJobQueryParameter
            {
                OrganizationId = input.OrganizationIdParameter.OrganizationId,
                JobStatusId = input.CreateJobPayload.JobStatusId,
                Code = input.CreateJobPayload.Code,
                ShortDescription = input.CreateJobPayload.ShortDescription,
                CustomerId = input.CreateJobPayload.CustomerId,
                StartDate = input.CreateJobPayload.StartDate,
                EndDate = input.CreateJobPayload.EndDate
            };

            _command.BuildQuery(parameter);

            var newId = _executor.Execute(_command);

            //just a stub, use mapper
            var job = new JobWithCustomerContract
            {
                Id = newId,
                OrganizationId = input.OrganizationIdParameter.OrganizationId,
                JobStatus = new JobStatusIdNameContract { Id = input.CreateJobPayload.JobStatusId, Name = "test" },
                Code = input.CreateJobPayload.Code,
                ShortDescription = input.CreateJobPayload.ShortDescription,
                Customer = new CustomerIdNameContract { Id = input.CreateJobPayload.CustomerId },
                StartDate = input.CreateJobPayload.StartDate,
                EndDate = input.CreateJobPayload.EndDate
            };

            return job;
            //get one

            //var result = JobMapper.Map(job);

            //return result;
        }
    }
}
