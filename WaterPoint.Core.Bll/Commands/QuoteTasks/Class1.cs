using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Quotes;

namespace WaterPoint.Core.Bll.Commands.QuoteTasks
{
    public class CreateQuoteTaskCommand : ICommand<CreateQuoteTask>
    {
        public void BuildQuery(CreateQuoteTask input)
        {
            throw new NotImplementedException();
        }

        public string Query { get; }
        public object Parameters { get; }
    }
}
