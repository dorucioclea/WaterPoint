using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Bll.Customers;
using WaterPoint.Core.Bll.Customers.Queries;
using WaterPoint.Core.Bll.Customers.Runners;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class PaginatedCustomersProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<OrganizationIdRequest, PaginationRequest, IEnumerable<BasicCustomer>>
    {
        private readonly PaginatedCustomersQuery _paginatedCustomersQuery;
        private readonly PaginatedCustomerQueryRunner _paginatedCustomerQueryRunner;

        public PaginatedCustomersProcessor(
            ICoreMapper coreMapper,
            IDapperUnitOfWork dapperUnitOfWork,
            PaginatedCustomersQuery paginatedCustomersQuery,
            PaginatedCustomerQueryRunner paginatedCustomerQueryRunner)
            : base(coreMapper, dapperUnitOfWork)
        {
            _paginatedCustomersQuery = paginatedCustomersQuery;
            _paginatedCustomerQueryRunner = paginatedCustomerQueryRunner;
        }

        public IEnumerable<BasicCustomer> Process(OrganizationIdRequest path, PaginationRequest query)
        {
            using (DapperUnitOfWork.Begin())
            {
                _paginatedCustomersQuery.BuildQuery(path.OrganizationId);

                var result = _paginatedCustomerQueryRunner.Run(_paginatedCustomersQuery);

                return Mapper.MapTo<IEnumerable<BasicCustomer>>(result);
            }
        }
    }

    public class PaginationAnalyzer
    {
        public int PageNumber { get; private set; }

        public int PageSize { get; private set; }

        public PaginationAnalyzer(PaginationRequest request)
        {

        }
    }
}
