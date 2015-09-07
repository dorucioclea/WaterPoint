using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain.Contracts.Skus
{
    public class SkuContract
    {
        public int Id { get; set; }

        //public ProductContract Product { get; set; }

        public string Code { get; set; }

        public int Quantity { get; set; }

        public DateTime UtcCreated { get; set; }

        public DateTime UtcUpdated { get; set; }
    }
}
