using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PreferedName { get; set; }
        public string Phone { get; set; }
        public Guid Uid { get; set; }
    }
}
