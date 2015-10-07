using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ninject.Extensions.Factory;
using Ninject.Parameters;
using WaterPoint.Core.Bll.Enum;

namespace WaterPoint.Core.Bll
{
    public class SqlBuilderProvider : StandardInstanceProvider
    {
        protected override Type GetType(MethodInfo methodInfo, object[] arguments)
        {
            switch ((Crud)arguments[0])
            {
                case Crud.Read:
                    return typeof(SelectSqlBuilder);
                case Crud.Create:
                    throw new NotImplementedException();
                case Crud.Update:
                    throw new NotImplementedException();
                case Crud.Delete:
                    throw new NotImplementedException();
                default:
                    return typeof(SelectSqlBuilder);
            }
        }

        protected override IConstructorArgument[] GetConstructorArguments(MethodInfo methodInfo, object[] arguments)
        {
            return new IConstructorArgument[]
            {
                new ConstructorArgument("dataEntityType", arguments[1])
            };
        }
    }
}
