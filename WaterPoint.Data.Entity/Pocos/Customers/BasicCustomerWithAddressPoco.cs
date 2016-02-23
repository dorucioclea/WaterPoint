using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity.Attributes;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Data.Entity.Pocos
{
    [Table("dbo", "Customer", "c")]
    public class BasicCustomerWithPrimaryAddressPoco : IDataEntity
    {
        [Primary]
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        //[Foreign]
        public int AddressId { get; set; }
        //[Foreign]
        public string Addressestreet { get; set; }
        //[Foreign]
        public string AddressestreetExtraLine { get; set; }
        //[Foreign]
        public string Addressesuburb { get; set; }
        //[Foreign]
        public string AddressCity { get; set; }
        //[Foreign]
        public string AddressPostCode { get; set; }
    }

    [Table("dbo", "Organization", "o")]
    public class OrganizationPoco
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [Table("dbo", "Address", "a")]
    public class AddressPoco
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public string StreetExtraLine { get; set; }

        public string Suburb { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }
    }
}
