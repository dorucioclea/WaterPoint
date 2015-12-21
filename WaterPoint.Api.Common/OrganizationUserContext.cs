using System;

namespace WaterPoint.Api.Common
{
    public class OrganizationUserContext
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public int OrganizationUserId { get; set; }

        public int OrganizationUserTypeId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsDeleted { get; set; }

        public string Version { get; set; }

        public DateTime UtcCreated { get; set; }

        public DateTime UtcUpdated { get; set; }

        public Guid Uid { get; set; }
    }
}
