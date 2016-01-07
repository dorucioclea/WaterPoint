using System;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Domain.QueryParameters.InvoiceJobTasks
{
    public class UpdateInvoiceJobTask : IQueryParameter
    {
        [IgnoreWhenUpdate]
        public int Id { get; set; }

        [IgnoreWhenUpdate]
        public int InvoiceId { get; set; }

        public int? TaskDefinitionId { get; set; }

        public int? DisplayOrder { get; set; }

        public int EstimatedTimeInMinutes { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public decimal BaseRate { get; set; }

        public decimal BillableRate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        public bool IsBillable { get; set; }

        public bool IsCompleted { get; set; }
    }
}
