using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity.DataEntities
{
    public class Table : IDataEntity
    {
        public virtual int Id { get; set; }
        public virtual string Code { get; set; }
        public virtual int NumberOfSeats { get; set; }
        public virtual int? MaxNumberOfSeats { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual TableType TableType { get; set; }
        public virtual Guid Uid { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual DateTime UpdatedOn { get; set; }
    }
}
