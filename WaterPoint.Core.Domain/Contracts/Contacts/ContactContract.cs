using System;

namespace WaterPoint.Core.Domain.Contracts.Contacts
{
    public class CustomerContactContract : ContactContract
    {
        public int CustomerId { get; set; }
        public bool IsPrimary { get; set; }
    }

    public class ContactContract : IContract
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherName { get; set; }

        public string Phone { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public bool IsDeleted { get; set; }

        public string Version { get; set; }

        public DateTime UtcCreated { get; set; }

        public DateTime UtcUpdated { get; set; }

        public Guid Uid { get; set; }
    }
}
