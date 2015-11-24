using WaterPoint.Core.Domain.Dtos.Interfaces;

namespace WaterPoint.Core.Domain.Dtos.Requests.Customers
{
    public class GetCustomerByIdRequest : IOrganizationEntityParameter, IRequest
    {
        public OrganizationEntityParameter OrganizationEntityParameter { get; set; }
    }
}
