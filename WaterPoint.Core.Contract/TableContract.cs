using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Contract
{
    public class TableContract
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int BranchId { get; set; }
        public int GroupId { get; set; }
        public string Code { get; set; }
        public int? NumberOfSeats { get; set; }
        public int MaxNumberOfSeats { get; set; }
        public bool IsReserved { get; set; }
    }
}
