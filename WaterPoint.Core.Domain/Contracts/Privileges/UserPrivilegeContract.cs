using System.Collections.Generic;

namespace WaterPoint.Core.Domain.Contracts.Privileges
{
    public class UserPrivilegeContract : IContract
    {
        public int OrganizationUserId { get; set; }
        public IEnumerable<PrivilegeContract> Privileges { get; set; }
    }

    public class PrivilegeContract
    {
        public int Id { get; set; }
        public bool IsFull { get; set; }
    }
}
