using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain.Contracts
{
    public class TableTypeContract
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int Name { get; set; }
    }
}
