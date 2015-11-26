using System.Web.Http.OData;
using WaterPoint.Core.Domain.Dtos.Interfaces;
using WaterPoint.Core.Domain.Dtos.Payloads.Jobs;

namespace WaterPoint.Core.Domain.Dtos.Requests.Jobs
{
    public class UpdateJobRequest : IOrganizationEntityParameter, IRequest
    {
        public OrganizationEntityParameter OrganizationEntityParameter { get; set; }
        public Delta<WriteJobPayload> UpdateJobPayload { get; set; }
        public int StaffId { get; set; }
    }
}
