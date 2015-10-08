using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Blls;
using WaterPoint.Core.RequestProcessor.Customers;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class PaginatedCustomersProcessor : BaseDapperUowRequestProcess<PaginatedCustomersRequest, IEnumerable<BasicCustomer>>
    {
        private readonly IBasicCustomerBll _basicCustomerBll;

        public PaginatedCustomersProcessor(
            ICoreMapper coreMapper,
            IBasicCustomerBll basicCustomerBll,
            IDapperUnitOfWork dapperUnitOfWork)
            : base(coreMapper, dapperUnitOfWork)
        {
            _basicCustomerBll = basicCustomerBll;
        }

        public override IEnumerable<BasicCustomer> Process(PaginatedCustomersRequest request)
        {
            using (DapperUnitOfWork.Begin())
            {
                var result = _basicCustomerBll.ListByOrgId(request.OrganizationId);

                return Mapper.MapTo<IEnumerable<BasicCustomer>>(result);
            }
        }
    }

    public class PaginationAnalyzer
    {
        public int PageNumber { get;  }

        public int PageSize { get; }

        public PaginationAnalyzer(PaginationRequest request)
        {
            
        }
    }
}
