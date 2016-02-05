using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Core.Domain.QueryParameters.Staff;

namespace WaterPoint.Core.Bll.Commands.Staff
{
    public class CreateStaffCommand : ICommand<CreateStaff>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateStaffCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateStaff input)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<Data.Entity.DataEntities.Staff>>();

            builder.Analyze<CreateStaff>();
            builder.AddValueParameters(input);

            var sql = builder.GetSql();

            Query = sql;
            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => false;
    }
}
