using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity.DataEntities
{
    public class SkuVariant
    {
        public virtual int Id { get; set; }

        public virtual Sku Sku { get; set; }

        public virtual int VariantTypeId { get; set; }

        public virtual string TextValue { get; set; }

        public virtual decimal? NumberValue { get; set; }

    }
}
