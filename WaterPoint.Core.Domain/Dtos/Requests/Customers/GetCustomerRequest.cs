namespace WaterPoint.Core.Domain.Dtos.Requests.Customers
{
    public class GetCustomerRequest : IRequest
    {
        public OrganizationEntityParameter OrganizationEntityParameter { get; set; }
    }
}
