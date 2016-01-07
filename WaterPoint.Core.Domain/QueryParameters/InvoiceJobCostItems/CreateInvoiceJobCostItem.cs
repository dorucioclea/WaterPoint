using System;
using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.InvoiceJobCostItems
{
    public class CreateInvoiceJobCostItem : IQueryParameter
    {
        public int OrganizationId { get; set; }

        public int CustomerId { get; set; }

        public int InvoiceId { get; set; }

        public int JobCostItemId { get; set; }

        public string ShortDescription { get; set; }

        public decimal UnitCost { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal Quantity { get; set; }

        public bool IsBillable { get; set; }
    }
}
