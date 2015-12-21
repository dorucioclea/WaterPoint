using System;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Bll.QueryParameters.Customers
{
    public class UpdateCustomer : IQueryParameter
    {
        [IgnoreWhenUpdate]
        public int Id { get; set; }

        [IgnoreWhenUpdate]
        public int OrganizationId { get; set; }

        public int? CustomerTypeId { get; set; }

        public bool IsProspect { get; set; }

        public string Gender { get; set; }

        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherName { get; set; }

        public string Phone { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public DateTime? Dob { get; set; }

        public bool IsDeleted { get; set; }

        public int? InvoiceCustomerId { get; set; }

        public DateTime UtcUpdated { get; set; }
    }
}
