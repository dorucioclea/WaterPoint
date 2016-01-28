using System.Collections.Generic;

namespace WaterPoint.Core.Domain.Contracts.UserPrivileges
{
    public class UserPrivilegeContract : IContract
    {
        public int OrgUserId { get; set; }
        public IEnumerable<PrivilegeContract> Privileges { get; set; }
    }

    public class PrivilegeContract
    {
        public int Id { get; set; }
    }
}
