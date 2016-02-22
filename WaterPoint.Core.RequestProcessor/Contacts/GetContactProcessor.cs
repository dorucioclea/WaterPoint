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
    public class GetContactProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<GetContactRequest, ContactContract>
    {
        private readonly IQuery<GetContact, Contact> _query;
        private readonly IQueryRunner _runner;

        public GetContactProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetContact, Contact> query,
            IQueryRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public ContactContract Process(GetContactRequest input)
        {
            var parameter = new GetContact
            {
                OrganizationId = input.OrganizationId,
                Id = input.Id
            };

            _query.BuildQuery(parameter);

            using (DapperUnitOfWork.Begin())
            {
                var contact = _runner.Run(_query);

                var result = ContactMapper.Map(contact);

                return result;
            }
        }
    }
}
