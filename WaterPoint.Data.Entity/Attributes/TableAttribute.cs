using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class TableAttribute : Attribute
    {
        public string Table { get; private set; }

        public string Schema { get; private set; }

        public TableAttribute(string schema, string table)
        {
            Schema = schema;
            Table = table;
        }
    }
}
