using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests
{
    public class OrganizationEntityRequest : IRequest, IOrgEntity
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }
}
