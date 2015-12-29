namespace WaterPoint.Data.Entity.Pocos.Priviledges
{
    public class OrganizationUserPrivilegePoco : IDataEntity
    {
        public int OrganizationUserId { get; set; }
        public int PrivilegeId { get; set; }
        public bool IsFull { get; set; }
    }
}
