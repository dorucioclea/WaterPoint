namespace WaterPoint.Core.Domain.Dtos.Requests.Customers
{
    public class GetCustomerRequest : IRequest
    {
        public OrgEntityRp OrganizationEntityParameter { get; set; }
    }
}
