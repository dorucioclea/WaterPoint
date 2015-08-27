using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity.DataEntities
{
    public class Restaurant
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string PreferedName { get; set; }
        public virtual string Phone { get; set; }
        public virtual Guid Uid { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public virtual IList<Branch> Branches { get; set; }
    }
}
