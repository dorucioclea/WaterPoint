using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Contract
{
    public class SupplierContract
    {
        public int Id { get; set; }
        
        public string Uid { get; set; }
        
        public string Name { get; set; }
        
        public string DisplayName { get; set; }
        
        public string Mobile { get; set; }
        
        public string Phone1 { get; set; }
    }
}
