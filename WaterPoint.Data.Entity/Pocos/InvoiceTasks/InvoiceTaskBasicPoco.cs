﻿using System;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.Pocos.InvoiceTasks
{
    [Table("dbo", "InvoiceTask", "ijt")]
    public class InvoiceTaskBasicPoco : IDataEntity
    {
        [Primary]
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        public int JobTaskId { get; set; }

        public int? DisplayOrder { get; set; }

        public int EstimatedTimeInMinutes { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        public bool IsBillable { get; set; }

        public bool IsCompleted { get; set; }

        public decimal BaseRate { get; set; }

        public decimal BillableRate { get; set; }

        public string ShortDescription { get; set; }

        [AutoGenerated]
        public byte[] Version { get; set; }

    }
}
