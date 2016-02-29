namespace WaterPoint.Core.Domain.Requests.JobCategories
{
    public class ListJobCategoriesRequest : IRequest
    {
        public int OrganizationId { get; set; }
    }
}
