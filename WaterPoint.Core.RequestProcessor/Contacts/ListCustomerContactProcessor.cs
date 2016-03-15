using System.Collections.Generic;
using System.Linq;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Contacts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Contacts;
using WaterPoint.Core.Domain.Requests.Contacts;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Contacts;

namespace WaterPoint.Core.RequestProcessor.Contacts
{
    public class ListCustomerContactProcessor :
        BaseDapperUowRequestProcess,
        IListProcessor<ListCustomerContactsRequest, CustomerContactContract>
    {
        private readonly IQuery<ListCustomerContacts, CustomerContactPoco> _query;
        private readonly IQueryListRunner _runner;

        public ListCustomerContactProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListCustomerContacts, CustomerContactPoco> query,
            IQueryListRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public IEnumerable<CustomerContactContract> Process(ListCustomerContactsRequest input)
        {
            _query.BuildQuery(new ListCustomerContacts
            {
                OrganizationId = input.OrganizationId,
                CustomerId = input.CustomerId,
                IsDeleted = input.IsDeleted ?? false
            });

            var result = _runner.Run(_query);

            return result.Select(ContactMapper.Map);
        }
    }
}
