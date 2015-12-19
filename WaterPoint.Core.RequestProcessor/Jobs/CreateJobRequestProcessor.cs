using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Bll.Commands.Jobs;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.QueryParameters;
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
    public class CreateJobRequestProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<CreateJobRequest, JobWithCustomerAndStatusContract>
    {
        private readonly CreateJobCommand _command;
        private readonly CreateCommandExecutor _executor;

        public CreateJobRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            CreateJobCommand command,
            CreateCommandExecutor executor)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
        }

        public JobWithCustomerAndStatusContract Process(CreateJobRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return result;
        }

        private JobWithCustomerAndStatusContract ProcessDeFacto(CreateJobRequest input)
        {
            var parameter = new CreateJobQueryParameter
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

            var newId = _executor.Run(_command);

            //just a stub, use mapper 
            var job = new JobWithCustomerAndStatusContract
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
