using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Bll
{
    public class SelectSqlBuilder<T> : ISqlBuilder
        where T : IDataEntity
    {
        //and or like notlike in not in

        private string Select()
        {
            var type = typeof(T);

            //where it's not a foreign key properties
            var properties = type.GetProperties();//.Where(i=>i.getcu);

            var columns = string.Join(",", properties.Select(i => i.Name));

            var tableAttribute = type.GetCustomAttribute(typeof(TableAttribute)) as TableAttribute;

            if (tableAttribute == null)
                throw new InvalidDataException("Missing TableAttribute decoration.");

            var select = $"SELECT {columns} FROM [{tableAttribute.Schema}].[{tableAttribute.Table}] ";

            return select;
        }

        public string GetSql()
        {
            return GetSql<T>(null);
        }

        public string GetSql<T>(Expression<Func<T, object>> parameters) where T : IDataEntity
        {
            var type = typeof(T);

            var properties = type.GetProperties();

            var columns = string.Join(",", properties.Select(i => i.Name));

            var tableAttribute = type.GetCustomAttribute(typeof(TableAttribute)) as TableAttribute;

            if (tableAttribute == null)
                throw new InvalidDataException("Missing TableAttribute decoration.");

            var select = $"SELECT {columns} FROM [{tableAttribute.Schema}].[{tableAttribute.Table}]";


            return string.Empty;
        }
    }
}
