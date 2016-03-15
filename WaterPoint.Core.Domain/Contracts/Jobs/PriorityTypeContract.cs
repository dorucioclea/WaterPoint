namespace WaterPoint.Core.Domain.Contracts.Jobs
{
    public class PriorityTypeContract : IContract
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
