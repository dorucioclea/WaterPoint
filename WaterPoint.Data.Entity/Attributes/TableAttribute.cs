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

        public string Alias { get; private set; }

        public string Schema { get; private set; }

        public TableAttribute(string schema, string table, string alias)
        {
            Schema = schema;
            Table = table;
            Alias = alias;
        }
    }

    public class JoinAttribute : Attribute
    {
        public enum JoinType
        {
            Left,
            Inner,
            Right
        }

        public JoinType Join { get; private set; }

        public string Via { get; set; }

        public JoinAttribute(JoinType join)
        {
            Join = join;
        }
    }
}
