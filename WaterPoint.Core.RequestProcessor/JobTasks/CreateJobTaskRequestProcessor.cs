using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Bll.Commands.JobTasks;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.JobTasks;
using WaterPoint.Core.Domain.Dtos.Requests.JobTasks;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.JobTasks
{
    public class CreateJobTaskRequestProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<CreateJobTaskRequest, JobTaskContract>
    {
        private readonly CreateJobTaskCommand _command;
        private readonly CreateCommandExecutor _executor;

        public CreateJobTaskRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            CreateJobTaskCommand command,
            CreateCommandExecutor executor)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
        }

        public JobTaskContract Process(CreateJobTaskRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return result;
        }

        private JobTaskContract ProcessDeFacto(CreateJobTaskRequest input)
        {
            var jobTask = new JobTask
            {


            };

            _command.BuildQuery(input.OrganizationIdParameter.OrganizationId, jobTask);

            var newId = _executor.Run(_command);

            jobTask.Id = newId;

            var result = JobTaskMapper.Map(jobTask);

            return result;
        }
    }
}
