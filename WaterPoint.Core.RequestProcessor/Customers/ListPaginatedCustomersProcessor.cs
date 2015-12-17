using System.Collections.Generic;
using System.Linq;
using Utility;
using WaterPoint.Core.Bll.QueryParameters;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Dtos.Requests.Shared;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class ListPaginatedCustomersProcessor :
        IRequestProcessor<ListPaginatedWithOrgIdRequest, PaginatedResult<IEnumerable<CustomerContract>>>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly PaginationAnalyzer _paginationAnalyzer;
        private readonly IListPaginatedWithOrgIdQuery<PaginatedWithOrgIdQueryParameter> _paginatedCustomersQuery;
        private readonly IListPaginatedEntitiesRunner<Customer> _paginatedCustomerRunner;

        public ListPaginatedCustomersProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            PaginationAnalyzer paginationAnalyzer,
            IListPaginatedWithOrgIdQuery<PaginatedWithOrgIdQueryParameter> paginatedCustomersQuery,
            IListPaginatedEntitiesRunner<Customer> paginatedCustomerRunner)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _paginationAnalyzer = paginationAnalyzer;
            _paginatedCustomersQuery = paginatedCustomersQuery;
            _paginatedCustomerRunner = paginatedCustomerRunner;
        }

        public CustomerContract Map(Customer source)
        {
            return CustomerMapper.Map(source);
        }

        public PaginatedResult<IEnumerable<CustomerContract>> Process(ListPaginatedWithOrgIdRequest input)
        {
            var parameter = _paginationAnalyzer.Analyze(input.PaginationParamter, "Id")
                .MapTo(new PaginatedWithOrgIdQueryParameter());

            parameter.OrganizationId = input.OrganizationIdParameter.OrganizationId;

            _paginatedCustomersQuery.BuildQuery(parameter);

            using (_dapperUnitOfWork.Begin())
            {
                var result = _paginatedCustomerRunner.Run(_paginatedCustomersQuery);

                return (result != null)
                    ? new PaginatedResult<IEnumerable<CustomerContract>>
                    {
                        Data = result.Data.Select(Map),
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
