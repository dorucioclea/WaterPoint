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
using WaterPoint.Core.RequestProcessor.Contracts.Customers;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class PaginatedCustomersProcessor : BaseDapperUowRequestProcess<PaginatedCustomersRequest, IEnumerable<BasicCustomer>>
    {
        private readonly ICoreMapper _coreMapper;
        private readonly IBasicCustomerBll _basicCustomerBll;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;

        public PaginatedCustomersProcessor(
            ICoreMapper coreMapper,
            IBasicCustomerBll basicCustomerBll,
            IDapperUnitOfWork dapperUnitOfWork)
        {
            _coreMapper = coreMapper;
            _basicCustomerBll = basicCustomerBll;
            _dapperUnitOfWork = dapperUnitOfWork;
        }

        public override IEnumerable<BasicCustomer> Process(PaginatedCustomersRequest request)
        {
            using (_dapperUnitOfWork.Begin())
            {
                var result = _basicCustomerBll.ListByOrgId(request.OrganizationId);

                return _coreMapper.MapTo<IEnumerable<BasicCustomer>>(result);
            }
        }
    }


}
