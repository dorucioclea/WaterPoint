//using WaterPoint.Core.Bll.QueryRunners.Staffs;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Staff;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Staff;
using WaterPoint.Core.Domain.Requests.Staff;
using WaterPoint.Data.DbContext.Dapper;
using OrgStaff = WaterPoint.Data.Entity.DataEntities.Staff;

namespace WaterPoint.Core.RequestProcessor.Staff
{
    public class GetStaffProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<GetStaffRequest, StaffContract>
    {
        private readonly IQuery<GetStaff> _query;
        private readonly IQueryRunner<GetStaff, OrgStaff> _runner;

        public GetStaffProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetStaff> query,
            IQueryRunner<GetStaff, OrgStaff> runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public StaffContract Process(GetStaffRequest input)
        {
            var parameter = new GetStaff
            {
                OrganizationId = input.OrganizationId,
                OrganizationUserId = input.OrganizationUserId
            };

            _query.BuildQuery(parameter);

            using (DapperUnitOfWork.Begin())
            {
                var staff = _runner.Run(_query);

                var result = StaffMapper.Map(staff);

                return result;
            }
        }
    }
}
