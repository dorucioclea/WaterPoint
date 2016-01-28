using System;
using System.Collections.Generic;
using WaterPoint.Core.Domain.Contracts.UserPrivileges;

namespace WaterPoint.Api.Common
{
    public class CredentialContext
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public int OrganizationUserId { get; set; }

        public int EntityId { get; set; }

        public int OrganizationUserTypeId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Guid Uid { get; set; }

        public IEnumerable<PrivilegeContract> Privileges { get; set; }
    }
}
