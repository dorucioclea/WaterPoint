using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity
{
    public class Table : IDataEntity
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public int GroupId { get; set; }
        public string Code { get; set; }
        public int NumberOfSeats { get; set; }
        public int? MaxNumberOfSeats { get; set; }
    }
}
