namespace WaterPoint.Core.Domain.Dtos.Requests.JobTasks
{
    public class GetJobTaskByIdRequest: IRequest
    {
        public int Id { get; set; }
    }
}
