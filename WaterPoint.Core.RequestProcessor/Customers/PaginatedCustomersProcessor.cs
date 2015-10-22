using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.Customers;
using WaterPoint.Core.Bll.Customers.Queries;
using WaterPoint.Core.Bll.Customers.Runners;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class PaginatedCustomersProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<OrganizationIdRequest, PaginationRequest, PaginatedResult<IEnumerable<BasicCustomerWithAddress>>>
    {
        private readonly PaginationAnalyzer _paginationAnalyzer;
        private readonly PaginatedCustomersQuery _paginatedCustomersQuery;
        private readonly PaginatedCustomerRunner _paginatedCustomerRunner;

        public PaginatedCustomersProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            PaginatedCustomerRunner paginatedCustomerRunner,
            PaginationAnalyzer paginationAnalyzer,
            PaginatedCustomersQuery paginatedCustomersQuery)
            : base(dapperUnitOfWork)
        {
            _paginatedCustomerRunner = paginatedCustomerRunner;
            _paginationAnalyzer = paginationAnalyzer;
            _paginatedCustomersQuery = paginatedCustomersQuery;
        }

        public PaginatedResult<IEnumerable<BasicCustomerWithAddress>> Process(OrganizationIdRequest path, PaginationRequest request)
        {
            _paginationAnalyzer.Analyze(request);

            using (DapperUnitOfWork.Begin())
            {
                _paginatedCustomersQuery.BuildQuery(
                    path.OrganizationId,
                    _paginationAnalyzer.Offset,
                    _paginationAnalyzer.PageSize,
                    _paginationAnalyzer.Sort,
                    _paginationAnalyzer.Desc);

                var result = _paginatedCustomerRunner.Run(_paginatedCustomersQuery);

                return (result != null)
                    ? new PaginatedResult<IEnumerable<BasicCustomerWithAddress>>
                    {
                        Data = result.Data.Select(CustomerMapper.Map),
                        TotalCount = result.TotalCount,
                        PageNumber = _paginationAnalyzer.PageNumber,
                        PageSize = _paginationAnalyzer.PageSize
                    }
                    : null;
            }
        }
    }
}
