using System;


namespace WaterPoint.Core.Domain.Contracts.TaskDefinitions
{
    public class TaskDefinitionContract : TaskDefinitionBasicContract
    {
        public string LongDescription { get; set; }
        public DateTime UtcCreated { get; set; }
        public DateTime UtcUpdated { get; set; }
        public string Uid { get; set; }
    }
}
