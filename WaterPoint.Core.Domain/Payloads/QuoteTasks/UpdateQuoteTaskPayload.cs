using System;
using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Payloads.QuoteTasks
{
    public class UpdateQuoteTaskPayload : IPayload
    {
        [Required]
        public int? TaskDefinitionId { get; set; }

        public int? DisplayOrder { get; set; }

        public int EstimatedTimeInMinutes { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public decimal BaseRate { get; set; }

        public decimal BillableRate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        [Required]
        public bool? IsBillable { get; set; }

        public bool IsCompleted { get; set; }
    }
}
