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

namespace WaterPoint.Core.RequestProcessor.Contacts
{
    public class ListContactsForCustomerProcessor :
        BaseDapperUowRequestProcess,
        IListProcessor<ListContactsForCustomerRequest, ContactContract>
    {
        private readonly IQuery<ListContactsForCustomer, Contact> _query;
        private readonly IQueryListRunner _runner;

        public ListContactsForCustomerProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListContactsForCustomer, Contact> query,
            IQueryListRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public IEnumerable<ContactContract> Process(ListContactsForCustomerRequest input)
        {
            _query.BuildQuery(new ListContactsForCustomer
            {
                OrganizationId = input.OrganizationId,
                CustomerId = input.CustomerId
            });

            var result = _runner.Run(_query);

            return result.Select(ContactMapper.Map);
        }
    }
}
