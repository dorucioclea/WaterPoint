using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.Contacts;
using WaterPoint.Core.Domain.QueryParameters.Contacts;
using WaterPoint.Core.Domain.Requests.Contacts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Contacts
{
    public class UpdateContactProcessor:
        BaseUpdateProcessor<UpdateContactRequest, WriteContactPayload, UpdateContact, GetContact, Contact>
    {
        public UpdateContactProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter patchEntityAdapter,
            IQuery<GetContact, Contact> getQuery,
            IQueryRunner getQueryRunner,
            ICommand<UpdateContact> updateQuery,
            ICommandExecutor updateCommandExecutor)
            : base(dapperUnitOfWork, patchEntityAdapter, getQuery, getQueryRunner, updateQuery, updateCommandExecutor)
        {
        }

        public override GetContact BuildGetParameter(UpdateContactRequest input)
        {
            return new GetContact
            {
                Id = input.Id,
                OrganizationId = input.OrganizationId
            };
        }
    }
}
