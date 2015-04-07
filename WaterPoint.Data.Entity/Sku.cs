using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity
{
    public class Sku : IDataEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Code { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal StandardPrice { get; set; }
        public decimal SpecialPrice { get; set; }
    }
}
