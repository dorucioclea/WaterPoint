using System.Collections.Generic;
using System.Linq;
using Utility;
using WaterPoint.Core.Bll.QueryParameters;
using WaterPoint.Core.Bll.QueryParameters.Customers;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Requests.Customers;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class ListPaginatedCustomersProcessor :
        IRequestProcessor<ListCustomersRequest, PaginatedResult<IEnumerable<CustomerContract>>>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly PaginationQueryParameterConverter _paginationQueryParameterConverter;
        private readonly IQuery<PaginatedOrgIdIsProspect> _paginatedCustomersQuery;
        private readonly IListPaginatedEntitiesRunner<PaginatedOrgIdIsProspect, Customer> _paginatedCustomerRunner;

        public ListPaginatedCustomersProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            PaginationQueryParameterConverter paginationQueryParameterConverter,
            IQuery<PaginatedOrgIdIsProspect> paginatedCustomersQuery,
            IListPaginatedEntitiesRunner<PaginatedOrgIdIsProspect, Customer> paginatedCustomerRunner)
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

        public PaginatedResult<IEnumerable<CustomerContract>> Process(ListCustomersRequest input)
        {
            var parameter = _paginationQueryParameterConverter.Convert(input.Pagination, "Id")
                .MapTo(new PaginatedOrgIdIsProspect());

            parameter.OrganizationId = input.IsProspectOrgId.OrganizationId;
            parameter.IsProspect = input.IsProspectOrgId.IsProspect;

            _paginatedCustomersQuery.BuildQuery(parameter);

            using (_dapperUnitOfWork.Begin())
            {
                var result = _paginatedCustomerRunner.Run(_paginatedCustomersQuery);

                return (result != null)
                    ? new PaginatedResult<IEnumerable<CustomerContract>>
                    {
                        Data = result.Data.Select(Map),
                        TotalCount = result.TotalCount,
                        PageNumber = _paginationQueryParameterConverter.PageNumber,
                        PageSize = _paginationQueryParameterConverter.PageSize,
                        Sort = _paginationQueryParameterConverter.Sort,
                        IsDesc = _paginationQueryParameterConverter.IsDesc
                    }
                    : null;
            }
        }
    }
}
