using System;


namespace WaterPoint.Core.Domain.Contracts.JobTasks
{
    public class JobTaskContract : IContract
    {
        public int Id { get; set; }

        public int JobId { get; set; }

        public int TaskDefinitionId { get; set; }

        public int EstimatedTimeInMinutes { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime CompletedDate { get; set; }

        public bool IsBillable { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsAllocated { get; set; }

        public bool IsScheduled { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string Version { get; set; }

        public string Uid { get; set; }

        public DateTime UtcCreated { get; set; }

        public DateTime UtcUpdated { get; set; }
    }
}
