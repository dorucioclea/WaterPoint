using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity.DataEntities
{
    public class BannerType
    {
        public virtual int Id { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual string Name { get; set; }

        public virtual IList<Banner> Banners { get; set; }
    }
}
