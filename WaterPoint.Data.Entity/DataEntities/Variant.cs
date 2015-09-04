using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity.DataEntities
{
    public class Variant
    {
        public virtual int Id { get; set; }

        public virtual string Value { get; set; }

        public virtual int Order { get; set; }

        public virtual IList<Sku> Skus { get; set; }
    }
}
