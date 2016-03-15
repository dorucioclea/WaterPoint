using System.Collections.Generic;
using System.Linq;
using WaterPoint.Core.Bll.QueryRunners;
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
    public class ListContactsProcessor :
        PagedProcessor<ListContactsRequest, ListContacts, Contact, ContactContract>
    {
        public ListContactsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListContacts, Contact> listQuery,
            IPagedQueryRunner listQueryRunner)
            : base(dapperUnitOfWork, listQuery, listQueryRunner)
        {
        }

        public override ContactContract Map(Contact source)
        {
            return ContactMapper.Map(source);
        }
    }
}
