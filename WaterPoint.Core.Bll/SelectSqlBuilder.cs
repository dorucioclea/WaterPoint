using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Bll
{
    public class SelectSqlBuilder : ISqlBuilder
    {
        private readonly Type _dataEntityType;

        public SelectSqlBuilder(Type dataEntityType)
        {
            _dataEntityType = dataEntityType;
        }

        public string GetSql()
        {
            var properties = _dataEntityType.GetProperties();

            var columns = string.Join(",", properties.Select(i => i.Name));

            var tableAttribute = _dataEntityType.GetCustomAttribute(typeof(TableAttribute));

            if (tableAttribute == null)
                throw new InvalidDataException("Missing TableAttribute decoration.");

            var select = "SELECT " + columns + " FROM "


            return string.Empty;
        }


    }
}
