using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Bll
{
    public abstract class SqlBuilder<T>
    {
        protected string Columns { get; set; }
        protected string ParentTable { get; set; }
        protected Type Type { get; set; }
        protected List<PropertyInfo> Properties { get; set; }

        protected SqlBuilder()
        {
            Type = typeof(T);

            var tableAttribute = Type.GetCustomAttribute(typeof(TableAttribute)) as TableAttribute;

            if (tableAttribute == null)
                throw new InvalidDataException("Missing TableAttribute.");

            ParentTable = string.Format("[{0}].[{1}]", tableAttribute.Schema, tableAttribute.Table);

            Properties = Type.GetProperties().ToList();
        }
    }
}
