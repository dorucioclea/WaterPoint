using System.Collections.Generic;
using System.Linq;
using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class SearchCustomerByNameProcessor : IListProcessor<SearchCustomerByNameRequest, CustomerContract>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly IQuery<SearchCustomerByName, Customer> _listQuery;
        private readonly IQueryListRunner _runner;

        public SearchCustomerByNameProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<SearchCustomerByName, Customer> listQuery,
            IQueryListRunner runner)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _listQuery = listQuery;
            _runner = runner;
        }

        public CustomerContract Map(Customer source)
        {
            return CustomerMapper.Map(source);
        }

        private SearchCustomerByName GetParameter(SearchCustomerByNameRequest input)
        {
            return new SearchCustomerByName
            {
                OrganizationId = input.OrganizationId,
                SearchTerm = input.SearchTerm
            };
        }

        public IEnumerable<CustomerContract> Process(SearchCustomerByNameRequest input)
        {
            using (_dapperUnitOfWork.Begin())
            {
                try
                {
                    _listQuery.BuildQuery(GetParameter(input));

                    var result = _runner.Run(_listQuery);

                    _dapperUnitOfWork.Commit();

                    return result.Select(Map);
                }
                catch
                {
                    _dapperUnitOfWork.Rollback();

                    throw;
                }
            }
        }
    }
}
