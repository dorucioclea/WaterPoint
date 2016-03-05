namespace WaterPoint.Core.Domain.Contracts.JobStatuses
{
    public class JobStatusContract : IContract
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int OrganizationId { get; set; }

        public bool ForPlanned { get; set; }

        public bool ForDeleted { get; set; }

        public bool ForOnHold { get; set; }

        public bool ForCompleted { get; set; }

        public bool ForInProgress { get; set; }

        public bool ForCancelled { get; set; }

        public bool IsDeleted { get; set; }

        public int DisplayOrder { get; set; }

        public string Version { get; set; }
    }
}