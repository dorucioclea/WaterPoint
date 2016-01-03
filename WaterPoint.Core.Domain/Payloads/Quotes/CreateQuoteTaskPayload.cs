using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;

namespace WaterPoint.Core.Domain.Payloads.Quotes
{
    [FromBody]
    public class CreateQuoteTaskPayload
    {
        [Required]
        public int? TaskDefinitionId { get; set; }

        public int? DisplayOrder { get; set; }

        public int EstimatedTimeInMinutes { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        [Required]
        public bool? IsBillable { get; set; }

        public bool IsCompleted { get; set; }
    }
}
