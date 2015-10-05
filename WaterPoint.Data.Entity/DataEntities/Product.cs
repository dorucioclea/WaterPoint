using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity.DataEntities
{
    public class Product : IDataEntity
    {
        public virtual int Id { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual string Name { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime UtcCreated { get; set; }

        public virtual DateTime UtcUpdated { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual IList<Sku> Skus { get; set; }

        //public virtual IList<Category> Categories { get; set; }

        public virtual IList<Flag> Flags { get; set; }
    }
}
