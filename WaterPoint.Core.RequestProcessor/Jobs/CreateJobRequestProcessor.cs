//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WaterPoint.Core.Bll.Commands.Jobs;
//using WaterPoint.Core.Bll.Executors;
//using WaterPoint.Core.ContractMapper;
//using WaterPoint.Core.Domain;
//using WaterPoint.Core.Domain.Contracts.Jobs;
//using WaterPoint.Core.Domain.Dtos.Requests.Jobs;
//using WaterPoint.Data.DbContext.Dapper;
//using WaterPoint.Data.Entity.DataEntities;

//namespace WaterPoint.Core.RequestProcessor.Jobs
//{
//    public class CreateJobRequestProcessor : BaseDapperUowRequestProcess,
//        IRequestProcessor<CreateJobRequest, JobContract>
//    {
//        private readonly CreateJobCommand _command;
//        private readonly CreateCommandExecutor _executor;

//        public CreateJobRequestProcessor(
//            IDapperUnitOfWork dapperUnitOfWork,
//            CreateJobCommand command,
//            CreateCommandExecutor executor)
//            : base(dapperUnitOfWork)
//        {
//            _command = command;
//            _executor = executor;
//        }

//        public JobWithCustomerAndStatusContract Process(CreateJobRequest input)
//        {
//            var result = UowProcess(ProcessDeFacto, input);

//            return result;
//        }

//        private JobWithCustomerAndStatusContract ProcessDeFacto(CreateJobRequest input)
//        {
//            var job = new JobWithCustomerAndStatusContract
//            {
//                OrganizationId = input.OrganizationIdParameter.OrganizationId,
//                JobStatusId = input.CreateJobPayload.JobStatusId,
//                Code = input.CreateJobPayload.Code,
//                ShortDescription = input.CreateJobPayload.ShortDescription,
//                LongDescription = input.CreateJobPayload.LongDescription,
//                CustomerId = input.CreateJobPayload.CustomerId,
//                StartDate = input.CreateJobPayload.StartDate,
//                EndDate = input.CreateJobPayload.EndDate,
//                DueDate = input.CreateJobPayload.DueDate
//            };

//            _command.BuildQuery(input.OrganizationIdParameter.OrganizationId, job);

//            var newId = _executor.Run(_command);

//            job.Id = newId;

//            var result = JobMapper.Map(job);

//            return result;
//        }
//    }
//}
