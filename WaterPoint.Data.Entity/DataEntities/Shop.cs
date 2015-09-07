using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity.DataEntities
{
    public class Shop
    {
        public virtual int Id { get; set; }
        public virtual int CountryId { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual DateTime UtcCreated { get; set; }
        public virtual DateTime UtcUpdated { get; set; }
        public virtual IList<Product> Products { get; set; } 
    }
}
