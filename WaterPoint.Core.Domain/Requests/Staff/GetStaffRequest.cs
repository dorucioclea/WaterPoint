namespace WaterPoint.Core.Domain.Requests.Staff
{
    public class GetStaffRequest : IRequest
    {
        public int OrganizationId { get; set; }
        //staffId
        public int Id { get; set; }
    }
}
