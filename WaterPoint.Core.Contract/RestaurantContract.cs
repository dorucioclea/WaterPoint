using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Contract
{
    public class RestaurantContract
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string PreferedName { get; set; }
        
        public string Phone { get; set; }

        public Guid Uid { get; set; }
    }
}
