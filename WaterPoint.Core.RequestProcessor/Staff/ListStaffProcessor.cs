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
using System;
using WaterPoint.Core.Bll.QueryRunners;

namespace WaterPoint.Core.RequestProcessor.Staff
{
    public class ListStaffProcessor :
        PagedProcessor<ListStaffRequest, ListStaff, BasicStaffPoco, BasicStaffContract>
    {
        public ListStaffProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListStaff, BasicStaffPoco> query,
            IPagedQueryRunner runner)
            : base(dapperUnitOfWork, query, runner)
        {
        }

        public override BasicStaffContract Map(BasicStaffPoco source)
        {
            return StaffMapper.Map(source);
        }
    }
}
