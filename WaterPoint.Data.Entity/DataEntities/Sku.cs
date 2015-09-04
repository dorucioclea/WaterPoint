using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity.DataEntities
{
    public class Sku
    {
        public virtual int Id { get; set; }

        public virtual Product Product { get; set; }

        public virtual string Code { get; set; }

        public virtual int Quantity { get; set; }

        public virtual DateTime UtcCreatedOn { get; set; }

        public virtual DateTime UtcUpdatedOn { get; set; }

        public virtual IList<Variant> Variants { get; set; }
    }
}
