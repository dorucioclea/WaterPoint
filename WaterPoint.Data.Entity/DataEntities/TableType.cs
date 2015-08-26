using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.DataEntities
{
    public class TableType : IDataEntity
    {
        [Identity]
        public int Id { get; set; }
        [ManyToOne(typeof(Branch))]
        public int BranchId { get; set; }
        public string Name { get; set; }
    }
}
