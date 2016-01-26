using System;

namespace WaterPoint.Core.Domain.Contracts.Suppliers
{
    public class SupplierContract : IContract
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public string WebSite { get; set; }

        public string Version { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime UtcCreated { get; set; }

        public DateTime UtcUpdated { get; set; }

        public Guid Uid { get; set; }
    }
}
