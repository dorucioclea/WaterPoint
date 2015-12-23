
using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Payloads.TaskDefinitions
{
    public class WriteTaskDefinitionPayload
    {
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string LongDescription { get; set; }
        [Required]
        public decimal? BaseRate { get; set; }
        [Required]
        public decimal? BillableRate { get; set; }
    }
}
