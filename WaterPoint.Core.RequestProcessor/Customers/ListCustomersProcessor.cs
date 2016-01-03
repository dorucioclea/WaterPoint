using System.Collections.Generic;
using System.Linq;
using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters;
using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class ListCustomersProcessor :
        IPaginatedProcessor<ListCustomersRequest, CustomerContract>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly PaginationQueryParameterConverter _paginationQueryParameterConverter;
        private readonly IQuery<ListCustomers> _paginatedCustomersQuery;
        private readonly IListQueryRunner<ListCustomers, Customer> _paginatedCustomerRunner;

        public ListCustomersProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            PaginationQueryParameterConverter paginationQueryParameterConverter,
            IQuery<ListCustomers> paginatedCustomersQuery,
            IListQueryRunner<ListCustomers, Customer> paginatedCustomerRunner)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _paginationQueryParameterConverter = paginationQueryParameterConverter;
            _paginatedCustomersQuery = paginatedCustomersQuery;
            _paginatedCustomerRunner = paginatedCustomerRunner;
        }

        public CustomerContract Map(Customer source)
        {
            return CustomerMapper.Map(source);
        }

        public PaginatedResult<CustomerContract> Process(ListCustomersRequest input)
        {
            var parameter = _paginationQueryParameterConverter.Convert(input, "Id")
                .MapTo(new ListCustomers());

            parameter.OrganizationId = input.OrganizationId;
            parameter.IsProspect = input.IsProspect;

            _paginatedCustomersQuery.BuildQuery(parameter);

            using (_dapperUnitOfWork.Begin())
            {
                var result = _paginatedCustomerRunner.Run(_paginatedCustomersQuery);

                return new PaginatedResult<CustomerContract>
                {
                    Data = result.Data.Select(Map),
                    TotalCount = result.TotalCount,
                    PageNumber = _paginationQueryParameterConverter.PageNumber,
                    PageSize = _paginationQueryParameterConverter.PageSize,
                    Sort = _paginationQueryParameterConverter.Sort,
                    IsDesc = _paginationQueryParameterConverter.IsDesc
                };
            }
        }
    }
}
