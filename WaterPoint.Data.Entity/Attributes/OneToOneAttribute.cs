using System;

namespace WaterPoint.Data.Entity.Attributes
{
    public class OneToOneAttribute : Attribute
    {
        public string Schema { get; private set; }
        public string Table { get; private set; }
        public string Column { get; private set; }
        public string Alias { get; private set; }

        public OneToOneAttribute(string schema, string table, string column, string alias)
        {
            Schema = schema;
            Table = table;
            Column = column;
            Alias = alias;
        }
    }
}