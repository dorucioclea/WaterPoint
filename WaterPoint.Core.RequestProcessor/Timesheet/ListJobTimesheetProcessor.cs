using System.Collections.Generic;
using System.Linq;
using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.JobTimesheet;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobTimesheet;
using WaterPoint.Core.Domain.Requests.JobTimesheet;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.JobTimesheet;

namespace WaterPoint.Core.RequestProcessor.Timesheet
{
    public class ListJobTimesheetProcessor :
        BaseDapperUowRequestProcess,
        IListProcessor<ListJobTimesheetRequest, JobTimesheetBasicContract>
    {
        private readonly IQuery<ListJobTimesheet, JobTimesheetPoco> _query;
        private readonly IQueryListRunner _runner;

        public ListJobTimesheetProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListJobTimesheet, JobTimesheetPoco> query,
            IQueryListRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public IEnumerable<JobTimesheetBasicContract> Process(ListJobTimesheetRequest input)
        {
            _query.BuildQuery(new ListJobTimesheet
            {
                OrganizationId = input.OrganizationId,
                JobId = input.JobId
            });

            var result = _runner.Run(_query);

            return result.Select(JobTimesheetMapper.Map);
        }
    }
}
