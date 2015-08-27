using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Type;

namespace WaterPoint.Data.Entity.DataEntities
{
    public class Branch : IDataEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual DateTime UpdatedOn { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual IList<TableType> TableTypes { get; set; }
    }
}
