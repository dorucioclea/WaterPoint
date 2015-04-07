using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity
{
    public class Variant : IDataEntity
    {
        public int Id { get; set; }
        public int VariantTypeId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
