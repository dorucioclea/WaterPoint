namespace WaterPoint.Core.Domain.Dtos.Requests.Customers
{
    public class GetCustomerByIdRequest : IRequest
    {
        public OrganizationEntityParameter OrganizationEntityParameter { get; set; }
    }
}
