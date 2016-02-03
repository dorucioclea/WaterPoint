//using WaterPoint.Core.Bll.QueryRunners.Staffs;

using System.Collections.Generic;
using System.Linq;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Staff;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Staff;
using WaterPoint.Core.Domain.Requests.Staff;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.Staff;

namespace WaterPoint.Core.RequestProcessor.Staff
{
    public class ListStaffProcessor :
        BaseDapperUowRequestProcess,
        IListProcessor<ListStaffRequest, BasicStaffContract>
    {
        private readonly IQuery<ListStaff, BasicStaffPoco> _query;
        private readonly IQueryListRunner _runner;

        public ListStaffProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListStaff, BasicStaffPoco> query,
            IQueryListRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public IEnumerable<BasicStaffContract> Process(ListStaffRequest input)
        {
            var parameter = new ListStaff
            {
                OrganizationId = input.OrganizationId
            };

            _query.BuildQuery(parameter);

            using (DapperUnitOfWork.Begin())
            {
                var staff = _runner.Run(_query);

                var result = staff.Select(StaffMapper.Map);

                return result;
            }
        }
    }
}
