using WaterPoint.Core.Domain.Payloads.OrganizationUsers;

namespace WaterPoint.Core.Domain.Requests.OrganizationUsers
{
    public class EnterOrganizationRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
        public SignInManagementPayload Payload { get; set; }
    }
}
