using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity.Attributes;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Data.Entity.Pocos
{
    [Table("dbo", "Customer")]
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

    public class BasicCustomerWithAddressPoco : IDataEntity
    {
        [Primary]
        public virtual int Id { get; set; }
        public virtual int OrganizationId { get; set; }
        public virtual string Code { get; set; }
        [OneToMany("dbo", "Address")]
        public virtual Address Address { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string OtherName { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }
    }
}
