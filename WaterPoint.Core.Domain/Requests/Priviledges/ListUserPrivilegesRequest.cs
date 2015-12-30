namespace WaterPoint.Core.Domain.Requests.Priviledges
{
    public class ListUserPrivilegesRequest : IRequest
    {
        public string OrganizationUserIds { get; set; }
    }
}
