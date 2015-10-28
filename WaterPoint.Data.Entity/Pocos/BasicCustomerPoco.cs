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
    public class BasicCustomerPoco : IDataEntity
    {
        [Primary]
        public virtual int Id { get; set; }
        public virtual int OrganizationId { get; set; }
        public virtual string Code { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string OtherName { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }
    }

    [Table("dbo", "Customer", "c")]
    public class BasicCustomerWithPrimaryAddressPoco : IDataEntity
    {

        [Primary]
        public virtual int Id { get; set; }
        public virtual int OrganizationId { get; set; }
        public virtual string Code { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string OtherName { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }
        [Foreign]
        public virtual int AddressId { get; set; }
        [Foreign]
        public virtual string AddressStreet { get; set; }
        [Foreign]
        public virtual string AddressStreetExtraLine { get; set; }
        [Foreign]
        public virtual string AddressSuburb { get; set; }
        [Foreign]
        public virtual string AddressCity { get; set; }
        [Foreign]
        public virtual string AddressPostCode { get; set; }
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
        public virtual int Id { get; set; }

        public virtual string Street { get; set; }

        public virtual string StreetExtraLine { get; set; }

        public virtual string Suburb { get; set; }

        public virtual string City { get; set; }

        public virtual string PostCode { get; set; }
    }
}
