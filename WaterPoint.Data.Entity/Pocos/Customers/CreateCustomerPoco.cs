using System;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.Pocos.Customers
{
    [Table("dbo", "Customer", "c")]
    public class CreateCustomerPoco : IDataEntity
    {
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
    }
}
