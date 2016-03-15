using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.Invoices;
using WaterPoint.Core.Domain.QueryParameters;
using WaterPoint.Core.Domain.QueryParameters.Invoices;
using WaterPoint.Core.Domain.Requests.Invoices;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Invoices
{
    public class UpdateInvoiceProcessor :
        BaseUpdateProcessor<UpdateInvoiceRequest, WriteInvoicePayload, UpdateInvoice, GetOrganizationEntity, Invoice>
    {
        public UpdateInvoiceProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter patchAdapter,
            IQuery<GetOrganizationEntity, Invoice> getQuery,
            IQueryRunner getRunner,
            ICommand<UpdateInvoice> updateQuery,
            ICommandExecutor updateExecutor)
            : base(dapperUnitOfWork, patchAdapter, getQuery, getRunner, updateQuery, updateExecutor)
        {
        }

        public override GetOrganizationEntity BuildGetParameter(UpdateInvoiceRequest input)
        {
            var getCusParam = new GetOrganizationEntity
            {
                Id = input.Id,
                OrganizationId = input.OrganizationId
            };

            return getCusParam;
        }
    }
}
