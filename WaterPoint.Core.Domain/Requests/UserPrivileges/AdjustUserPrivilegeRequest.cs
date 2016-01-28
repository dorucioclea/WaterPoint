using WaterPoint.Core.Domain.Payloads.UserPrivileges;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.UserPrivileges
{
    public class AdjustUserPrivilegeRequest : ICreateRequest<AdjustUserPrivilegePayload>, IOrgId
    {
        public int OrganizationId { get; set; }

        public AdjustUserPrivilegePayload Payload { get; set; }

        public int OrganizationUserId { get; set; }
    }
}
