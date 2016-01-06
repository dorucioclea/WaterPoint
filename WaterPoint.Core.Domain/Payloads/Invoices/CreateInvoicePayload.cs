using System;
using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Payloads.Invoices
{
    public class CreateInvoicePayload
    {
        [Required]
        public int InvoiceTypeId { get; set; }

        [Required]
        public int InvoiceStatusId { get; set; }

        public int? ContactId { get; set; }

        [Required]
        public string Code { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        public bool IsFixedPrice { get; set; }

        [Required]
        public bool IsProgressive { get; set; }

        [Required]
        public string ShortDescription { get; set; }
    }
}
