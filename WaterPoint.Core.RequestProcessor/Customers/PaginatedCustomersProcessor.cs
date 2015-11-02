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
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class PaginatedCustomersProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<OrganizationIdRequest, PaginationRequest, PaginatedResult<IEnumerable<BasicCustomerContract>>>
    {
        private readonly PaginationAnalyzer _paginationAnalyzer;
        private readonly PaginatedBasicCustomerPocosQuery _paginatedCustomersQuery;
        private readonly PaginatedCustomerRunner _paginatedCustomerRunner;

        public PaginatedCustomersProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            PaginatedCustomerRunner paginatedCustomerRunner,
            PaginationAnalyzer paginationAnalyzer,
            PaginatedBasicCustomerPocosQuery paginatedCustomersQuery)
            : base(dapperUnitOfWork)
        {
            _paginatedCustomerRunner = paginatedCustomerRunner;
            _paginationAnalyzer = paginationAnalyzer;
            _paginatedCustomersQuery = paginatedCustomersQuery;
        }

        public PaginatedResult<IEnumerable<BasicCustomerContract>> Process(OrganizationIdRequest path, PaginationRequest request)
        {
            _paginationAnalyzer.Analyze(request, "Id");

            _paginatedCustomersQuery.BuildQuery(
                    path.OrganizationId,
                    _paginationAnalyzer.Offset,
                    _paginationAnalyzer.PageSize,
                    _paginationAnalyzer.Sort,
                    _paginationAnalyzer.IsDesc);

            using (DapperUnitOfWork.Begin())
            {
                var result = _paginatedCustomerRunner.Run(_paginatedCustomersQuery);

                return (result != null)
                    ? new PaginatedResult<IEnumerable<BasicCustomerContract>>
                    {
                        Data = result.Data.Select(CustomerMapper.Map),
                        TotalCount = result.TotalCount,
                        PageNumber = _paginationAnalyzer.PageNumber,
                        PageSize = _paginationAnalyzer.PageSize,
                        Sort = _paginationAnalyzer.Sort,
                        IsDesc = _paginationAnalyzer.IsDesc
                    }
                    : null;
            }
        }
    }
}
