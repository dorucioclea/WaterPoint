using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.JobTimesheet;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobTimesheet;
using WaterPoint.Core.Domain.QueryParameters.Shared;
using WaterPoint.Core.Domain.Requests.JobTimesheet;
using WaterPoint.Core.Domain.Requests.Shared;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.JobTimesheet;

namespace WaterPoint.Core.RequestProcessor.Timesheet
{
    public class GetJobTimesheetProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<GetJobTimesheetRequest, JobTimesheetContract>
    {
        private readonly IQuery<GetJobTimesheet, JobTimesheet> _query;
        private readonly IQueryRunner _runner;

        public GetJobTimesheetProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetJobTimesheet, JobTimesheet> query,
            IQueryRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public JobTimesheetContract Process(GetJobTimesheetRequest input)
        {
            var parameter = new GetJobTimesheet
            {
                OrganizationId = input.OrganizationId,
                Id = input.Id,
                JobId = input.JobId
            };

            _query.BuildQuery(parameter);

            using (DapperUnitOfWork.Begin())
            {
                var jobTimesheet = _runner.Run(_query);

                var result = JobTimesheetMapper.Map(jobTimesheet);

                return result;
            }
        }
    }
}
