using System;

namespace WaterPoint.Core.Domain.Contracts.Invoices
{
    public class InvoiceContract : IContract
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public int InvoiceTypeId { get; set; }

        public int InvoiceStatusId { get; set; }

        public int CustomerId { get; set; }

        public int? ContactId { get; set; }

        public string Code { get; set; }

        public DateTime? PaidDate { get; set; }

        public DateTime? DueDate { get; set; }

        public decimal? TotalPrice { get; set; }

        public decimal? TotalPriceWithTax { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string Version { get; set; }

        public DateTime UtcCreated { get; set; }

        public DateTime UtcUpdated { get; set; }

        public Guid Uid { get; set; }
    }
}
