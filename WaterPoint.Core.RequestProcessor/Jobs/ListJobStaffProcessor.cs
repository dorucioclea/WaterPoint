using System.Collections.Generic;
using System.Linq;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Staff;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Jobs;
using WaterPoint.Core.Domain.Requests.Jobs;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.Staff;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    public class ListJobStaffProcessor
     : BaseDapperUowRequestProcess, IListProcessor<ListJobStaffRequest, JobStaffContract>

    {
        private readonly IQuery<ListJobStaff, JobStaffPoco> _query;
        private readonly IQueryListRunner _runner;

        public ListJobStaffProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListJobStaff, JobStaffPoco> query,
            IQueryListRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public IEnumerable<JobStaffContract> Process(ListJobStaffRequest input)
        {
            _query.BuildQuery(new ListJobStaff
            {
                OrganizationId = input.OrganizationId,
                JobId = input.JobId
            });

            var result = _runner.Run(_query);

            return result.Select(StaffMapper.Map);
        }
    }
}
