using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity.DataEntities
{
    public class TableType : IDataEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual IList<Table> Tables { get; set; }
    }
}
