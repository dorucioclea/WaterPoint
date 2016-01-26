namespace WaterPoint.Core.Domain.Contracts.TaskDefinitions
{
    public class TaskDefinitionBasicContract : IContract
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string ShortDescription { get; set; }
        public decimal BaseRate { get; set; }
        public decimal BillableRate { get; set; }
        public bool IsDeleted { get; set; }
        public string Version { get; set; }
    }
}