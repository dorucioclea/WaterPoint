using System;


namespace WaterPoint.Core.Domain.Contracts.TaskDefinitions
{
    public class TaskDefinitionContract : IContract
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BaseRate { get; set; }
        public decimal BillableRate { get; set; }
        public bool IsDeleted { get; set; }
        public string Version { get; set; }
        public DateTime UtcCreated { get; set; }
        public DateTime UtcUpdated { get; set; }
        public string Uid { get; set; }
    }
}
