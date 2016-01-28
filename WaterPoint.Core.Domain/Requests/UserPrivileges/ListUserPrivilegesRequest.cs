namespace WaterPoint.Core.Domain.Requests.UserPrivileges
{
    public class ListUserPrivilegesRequest : IRequest
    {
        public string OrganizationUserIds { get; set; }
    }
}
