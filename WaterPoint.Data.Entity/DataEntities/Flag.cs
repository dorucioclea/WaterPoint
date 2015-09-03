using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity.DataEntities
{
    public class Flag
    {
        public virtual int Id { get; set; }
        
        public virtual string Name { get; set; }

        public virtual IList<Product> Products { get; set; } 
    }
}
