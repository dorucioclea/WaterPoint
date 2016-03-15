using System;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Domain.QueryParameters.Invoices
{
    public class UpdateInvoice: IQueryParameter
    {
        [IgnoreWhenUpdate]
        public int Id { get; set; }
        [IgnoreWhenUpdate]
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
        public int InvoiceTypeId { get; set; }
        public int InvoiceStatusId { get; set; }
        public int? ContactId { get; set; }
        public string Code { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsFixedPrice { get; set; }
        public bool IsProgressive { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal TotalPriceWithTax { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
