using System;


namespace WaterPoint.Core.Domain.Contracts.Credentials
{
    public class ValidCredentialContract : IContract
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public int OrganizationUserId { get; set; }

        public int OrganizationUserTypeId { get; set; }

        public int EntityId { get; set; }

        public string Email { get; set; }

        public bool IsDeleted { get; set; }

        public Guid Uid { get; set; }
    }
}
