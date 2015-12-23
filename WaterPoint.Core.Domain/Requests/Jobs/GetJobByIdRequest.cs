using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Jobs
{
    public class GetJobByIdRequest: IRequest
    {
        public OrgEntityRp OrganizationEntityParameter { get; set; }
    }
}
