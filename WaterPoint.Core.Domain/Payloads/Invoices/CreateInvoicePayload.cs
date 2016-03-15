using System;
using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Payloads.Invoices
{
    public class WriteInvoicePayload : IPayload
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int InvoiceTypeId { get; set; }

        [Required]
        public int InvoiceStatusId { get; set; }

        public int? ContactId { get; set; }

        [Required]
        public string Code { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? PaidDate { get; set; }

        [Required]
        public bool IsFixedPrice { get; set; }

        [Required]
        public bool IsProgressive { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public decimal TotalPriceWithTax { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
