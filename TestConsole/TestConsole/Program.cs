using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Parameters;

namespace TestConsole
{
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

    public interface IDataEntity
    {
    }

    [Table("dbo", "Table1")]
    public class Table1 : IDataEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Updated { get; set; }
    }

    public interface ISqlBuilder
    {
        string RawSql();
    }

    public class SelectSqlBuilder : ISqlBuilder
    {
        private readonly Type _dataEntityType;

        public SelectSqlBuilder(Type dataEntityType)
        {
            _dataEntityType = dataEntityType;
        }

        public string RawSql()
        {
            var properties = _dataEntityType.GetProperties();

            var columns = string.Join(",", properties.Select(i => i.Name));

            var tableAttribute = _dataEntityType.GetCustomAttribute(typeof (TableAttribute)) as TableAttribute;

            if (tableAttribute == null)
                throw new InvalidDataException("Missing TableAttribute decoration.");

            var select = string.Format(
                "SELECT {0} FROM [{1}].[{2}]", columns, tableAttribute.Schema,
                tableAttribute.Table);
            
            return string.Empty;
        }
    }

    public enum Crud
    {
        Create,
        Read,
        Update,
        Delete
    }

    public interface ISqlBuilderFactory
    {
        ISqlBuilder Create(Crud action, Type idataEntityType);
    }

    public class SqlBuilderProvider : StandardInstanceProvider
    {
        protected override Type GetType(MethodInfo methodInfo, object[] arguments)
        {
            return typeof(SelectSqlBuilder);
        }

        protected override IConstructorArgument[] GetConstructorArguments(MethodInfo methodInfo, object[] arguments)
        {
            return new IConstructorArgument[]
            {
                new ConstructorArgument("dataEntityType", arguments[1])
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();

            kernel.Bind<ISqlBuilderFactory>().ToFactory(() => new SqlBuilderProvider());

            var f = kernel.Get<ISqlBuilderFactory>();

            var test = f.Create(Crud.Read, typeof(Table1));

            Console.Write(test.RawSql());
        }
    }

    public class Test
    {
        public Test(ISqlBuilder builder)
        {
        }
    }
}
