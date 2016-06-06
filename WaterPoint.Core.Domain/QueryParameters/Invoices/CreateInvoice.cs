using System;
using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Invoices
{
    public class CreateInvoice : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
        public int InvoiceTypeId { get; set; }
        public int InvoiceStatusId { get; set; }
        public int? ContactId { get; set; }
        public string Code { get; set; }
        public DateTime? DueDate { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal TotalPriceWithTax { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
