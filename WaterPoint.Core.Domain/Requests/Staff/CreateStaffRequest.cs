using WaterPoint.Core.Domain.Payloads.StaffPayloads;

namespace WaterPoint.Core.Domain.Requests.Staff
{
    public class CreateStaffRequest : ICreateRequest<CreateStaffPayload>
    {
        public int OrganizationId { get; set; }

        public CreateStaffPayload Payload { get; set; }
    }
}
