namespace WaterPoint.Core.Domain.Requests.UserPrivileges
{
    public class DeleteUserPrivilegeRequest : IRequest
    {
        public int OrgnizationId { get; set; }
        public int UserId { get; set; }
        public int PrivilegeId { get; set; }
    }
}
