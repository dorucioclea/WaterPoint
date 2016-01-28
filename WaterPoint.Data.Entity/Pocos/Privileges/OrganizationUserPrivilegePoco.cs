namespace WaterPoint.Data.Entity.Pocos.Privileges
{
    public class OrganizationUserPrivilegePoco : IDataEntity
    {
        public int OrganizationUserId { get; set; }
        public int PrivilegeId { get; set; }
    }
}
