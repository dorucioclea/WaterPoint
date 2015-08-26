using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.DataEntities
{
    public class Restaurant
    {
        [Identity]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PreferedName { get; set; }
        public string Phone { get; set; }
        public Guid Uid { get; set; }
    }
}
