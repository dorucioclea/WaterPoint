namespace WaterPoint.Core.Domain.Dtos.Requests.Jobs
{
    public class GetJobByIdRequest: IRequest
    {
        public OrgEntityRp OrganizationEntityParameter { get; set; }
    }
}
