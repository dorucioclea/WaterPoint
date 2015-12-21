namespace WaterPoint.Core.Domain.Dtos.Requests.Jobs
{
    public class GetJobByIdRequest: IRequest
    {
        public OrganizationEntityParameter OrganizationEntityParameter { get; set; }
    }
}
