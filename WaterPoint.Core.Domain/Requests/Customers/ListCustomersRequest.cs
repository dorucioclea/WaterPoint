using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Customers
{
    public class ListCustomersRequest : IRequest
    {
        public ListCustomerRp Parameter { get; set; }
    }
}
