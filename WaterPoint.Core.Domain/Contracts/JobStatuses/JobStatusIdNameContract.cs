namespace WaterPoint.Core.Domain.Contracts.JobStatuses
{
    public class JobStatusIdNameContract : IContract
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
