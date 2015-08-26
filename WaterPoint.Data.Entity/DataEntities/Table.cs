using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.DataEntities
{
    public class Table : IDataEntity
    {
        [Identity]
        public int Id { get; set; }
        
        public int BranchId { get; set; }

        [OneToOne(typeof(TableType))]
        public int TableTypeId { get; set; }
        public string Code { get; set; }
        public int NumberOfSeats { get; set; }
        public int? MaxNumberOfSeats { get; set; }
    }
}
