namespace WaterPoint.Core.Domain.Contracts.JobCategories
{
    public class JobCategoryContract : IContract
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsInternal { get; set; }
        public bool IsCapacityReducing { get; set; }
    }
}
