namespace WaterPoint.Core.Domain.Dtos.Payloads.TaskDefinitions
{
    public class WriteTaskDefinitionPayload
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BaseRate { get; set; }
        public decimal BillableRate { get; set; }
    }
}
