using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity.DataEntities
{
    public class Credential
    {
        public virtual int Id { get; set; }

        public virtual int CustomerId { get; set; }

        public virtual string Email { get; set; }

        public virtual string Password { get; set; }

        public virtual DateTime CreatedOn { get; set; }

        public virtual DateTime UpdatedOn { get; set; }

    }
}
