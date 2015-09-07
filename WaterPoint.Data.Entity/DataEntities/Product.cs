using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity.DataEntities
{
    public class Product
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual bool IsDeleted { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime UtcCreated { get; set; }

        public virtual DateTime UtcUpdated { get; set; }

        public virtual Shop Shop { get; set; }

        public virtual IList<Sku> Skus { get; set; }

        //public virtual IList<Category> Categories { get; set; }

        public virtual IList<Flag> Flags { get; set; } 
    }
}
