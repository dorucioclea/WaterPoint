namespace WaterPoint.Core.Domain.Dtos.Requests.JobTasks
{
    public class GetJobTaskByIdRequest: IRequest
    {
        public OrganizationEntityParameter OrganizationEntityParameter { get; set; }
    }
}
