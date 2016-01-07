using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Invoices;
using WaterPoint.Core.Domain.Requests.Invoices;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Invoices
{
    public class CreateInvoiceProcessor : BaseCreateProcessor<CreateInvoiceRequest, CreateInvoice>
    {
        public CreateInvoiceProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateInvoice> command,
            ICommandExecutor<CreateInvoice> executor)
            : base(dapperUnitOfWork, command, executor)
        {
        }

        public override CreateInvoice BuildParameter(CreateInvoiceRequest input)
        {
            return new CreateInvoice
            {
                OrganizationId = input.OrganizationId,
                CustomerId = input.CustomerId,
                DueDate = input.Payload.DueDate,
                InvoiceStatusId = input.Payload.InvoiceStatusId,
                Code = input.Payload.Code,
                ContactId = input.Payload.ContactId,
                InvoiceTypeId = input.Payload.InvoiceTypeId,
                IsFixedPrice = input.Payload.IsFixedPrice,
                IsProgressive = input.Payload.IsProgressive,
                ShortDescription = input.Payload.ShortDescription
            };
        }
    }
}
