using Microsoft.Build.Framework;

namespace WaterPoint.Core.Domain.Dtos.Payloads.TaskDefinitions
{
    public class WriteTaskDefinitionPayload
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal BaseRate { get; set; }
        [Required]
        public decimal BillableRate { get; set; }
    }
}
