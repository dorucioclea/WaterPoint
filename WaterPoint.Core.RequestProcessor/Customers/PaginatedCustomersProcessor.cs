﻿using System;
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

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class PaginatedCustomersProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<OrganizationIdRequest, PaginationRequest, PaginatedResult<IEnumerable<BasicCustomer>>>
    {
        private readonly PaginationAnalyzer _paginationAnalyzer;
        private readonly PaginatedCustomersQuery _paginatedCustomersQuery;
        private readonly PaginatedCustomerQueryRunner _paginatedCustomerQueryRunner;

        public PaginatedCustomersProcessor(
            ICoreMapper coreMapper,
            IDapperUnitOfWork dapperUnitOfWork,
            PaginationAnalyzer paginationAnalyzer,
            PaginatedCustomersQuery paginatedCustomersQuery,
            PaginatedCustomerQueryRunner paginatedCustomerQueryRunner)
            : base(coreMapper, dapperUnitOfWork)
        {
            _paginationAnalyzer = paginationAnalyzer;
            _paginatedCustomersQuery = paginatedCustomersQuery;
            _paginatedCustomerQueryRunner = paginatedCustomerQueryRunner;
        }

        public PaginatedResult<IEnumerable<BasicCustomer>> Process(OrganizationIdRequest path, PaginationRequest request)
        {
            _paginationAnalyzer.Analyze(request);

            using (DapperUnitOfWork.Begin())
            {
                _paginatedCustomersQuery.BuildQuery(path.OrganizationId, _paginationAnalyzer.Offset,
                    _paginationAnalyzer.PageSize);

                var result = _paginatedCustomerQueryRunner.Run(_paginatedCustomersQuery);

                return (result != null)
                    ? new PaginatedResult<IEnumerable<BasicCustomer>>
                    {
                        ContractData = Mapper.MapTo<IEnumerable<BasicCustomer>>(result.Data),
                        TotalCount = result.TotalCount
                    }.SetPageValues(_paginationAnalyzer)
                    : null;
            }
        }
    }
}