using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Customers
{
    public class GetCustomerRequest : IRequest
    {
        public OrgEntityRp OrganizationEntityParameter { get; set; }
    }
}
