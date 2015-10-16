using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.Pocos
{
    [Table("dbo", "Customer")]
    public class BasicCustomerPoco : IDataEntity
    {
        public virtual int Id { get; set; }
        public virtual int OrganizationId { get; set; }
        public virtual string Code { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string OtherName { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }

    }
}
