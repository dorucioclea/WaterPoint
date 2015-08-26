using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.DataEntities
{
    public class Branch : IDataEntity
    {
        [Identity]
        public int Id { get; set; }

        [ManyToOne(typeof(Restaurant))]
        public int RestaurantId { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
