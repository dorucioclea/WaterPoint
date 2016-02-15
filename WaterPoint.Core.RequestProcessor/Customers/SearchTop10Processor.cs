using System.Collections.Generic;
using System.Linq;
using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Customers;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class SearchTop10Processor : IListProcessor<SearchTop10CustomerRequest, CustomerContract>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly IQuery<SearchTop10Customers, Customer> _listQuery;
        private readonly IQueryListRunner _runner;

        public SearchTop10Processor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<SearchTop10Customers, Customer> listQuery,
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

        private SearchTop10Customers GetParameter(SearchTop10CustomerRequest input)
        {
            return new SearchTop10Customers
            {
                OrganizationId = input.OrganizationId,
                SearchTerm = input.SearchTerm
            };
        }

        public IEnumerable<CustomerContract> Process(SearchTop10CustomerRequest input)
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
