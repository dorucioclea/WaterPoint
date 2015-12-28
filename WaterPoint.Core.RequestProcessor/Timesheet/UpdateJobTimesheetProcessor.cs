using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.JobTimesheet;
using WaterPoint.Core.Domain.QueryParameters.JobTimesheet;
using WaterPoint.Core.Domain.Requests.JobTimesheet;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.JobTimesheet;

namespace WaterPoint.Core.RequestProcessor.Timesheet
{
    public class UpdateJobTimesheetProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<UpdateJobTimesheetRequest, CommandResultContract>
    {
        private readonly IPatchEntityAdapter _patchEntityAdapter;
        private readonly IQuery<GetJobTimesheet> _getJobTimesheetByIdQuery;
        private readonly IQueryRunner<GetJobTimesheet, JobTimesheet> _getJobTimesheetByIdQueryRunner;
        private readonly ICommand<UpdateJobTimesheet> _updateJobTimesheetByIdQuery;
        private readonly ICommandExecutor<UpdateJobTimesheet> _updateCommandExecutor;

        public UpdateJobTimesheetProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter patchEntityAdapter,
            IQuery<GetJobTimesheet> getJobTimesheetByIdQuery,
            IQueryRunner<GetJobTimesheet, JobTimesheet> getJobTimesheetByIdQueryRunner,
            ICommand<UpdateJobTimesheet> updateJobTimesheetByIdQuery,
            ICommandExecutor<UpdateJobTimesheet> updateCommandExecutor)
            : base(dapperUnitOfWork)
        {
            _patchEntityAdapter = patchEntityAdapter;
            _getJobTimesheetByIdQuery = getJobTimesheetByIdQuery;
            _getJobTimesheetByIdQueryRunner = getJobTimesheetByIdQueryRunner;
            _updateJobTimesheetByIdQuery = updateJobTimesheetByIdQuery;
            _updateCommandExecutor = updateCommandExecutor;
        }

        public CommandResultContract Process(UpdateJobTimesheetRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return result;
        }

        private CommandResultContract ProcessDeFacto(UpdateJobTimesheetRequest input)
        {
            var getJobTimesheetParam = new GetJobTimesheet
            {
                Id = input.Parameter.Id,
                JobId = input.Parameter.JobId,
                OrganizationId = input.Parameter.OrganizationId
            };

            _getJobTimesheetByIdQuery.BuildQuery(getJobTimesheetParam);

            var existingJobTimesheet = _getJobTimesheetByIdQueryRunner.Run(_getJobTimesheetByIdQuery);

            var updatedJobTimesheet =
                _patchEntityAdapter.PatchEnitity<WriteJobTimesheetPayload, JobTimesheet, UpdateJobTimesheet>
                (
                    existingJobTimesheet,
                    input.Payload.Patch
                );

            //then build the query to update the object.
            _updateJobTimesheetByIdQuery.BuildQuery(updatedJobTimesheet);

            var success = _updateCommandExecutor.Execute(_updateJobTimesheetByIdQuery) > 0;

            if (success)
                return new CommandResultContract
                {
                    Message = $"JobTimesheet {input.Parameter.Id} has been updated",
                    Status = CommandResultContract.Success
                };

            return new CommandResultContract
            {
                Message = $"JobTimesheet {input.Parameter.Id} has not been updated, operation is finished but there is no result returned",
                Status = CommandResultContract.Failed
            };
        }
    }
}
