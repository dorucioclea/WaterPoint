﻿using System;
using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.QuoteCostItems
{
    public class CreateQuoteCostItem : IQueryParameter
    {
        public int OrganizationId { get; set; }

        public int CustomerId { get; set; }

        public int QuoteId { get; set; }

        public int CostItemId { get; set; }

        public string ShortDescription { get; set; }

        public decimal UnitCost { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal Quantity { get; set; }

        public bool IsBillable { get; set; }
    }
}
