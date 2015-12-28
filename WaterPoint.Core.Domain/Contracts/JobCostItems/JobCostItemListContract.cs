﻿using System;

namespace WaterPoint.Core.Domain.Contracts.JobCostItems
{
    public class JobCostItemListContract : IContract
    {
        public int Id { get; set; }

        public int JobId { get; set; }

        public int? CostItemId { get; set; }

        public string Code { get; set; }

        public decimal UnitCost { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public bool IsBillable { get; set; }

        public string Version { get; set; }

        public Guid Uid { get; set; }
    }
}
