using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.Bll.Customers.Commands
{
    public class UpdateCustomerCommand : ICommand
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public UpdateCustomerCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }


        public string Query { get; }
        public object Parameters { get; }
    }
}
