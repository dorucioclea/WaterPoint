using Ninject.Modules;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.Commands.JobTimesheet;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.JobTimesheet;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.JobTimesheet;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobTimesheet;
using WaterPoint.Core.Domain.Requests.JobTimesheet;
using WaterPoint.Core.RequestProcessor.Timesheet;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.JobTimesheet;


namespace WaterPoint.Api.DependencyInjection
{
    public class InvoiceApiModule : NinjectModule
    {
        public override void Load()
        {
            BindRequestProcessors();
            BindQueries();
            BindQueryRunners();
            BindCommands();
            BindCommandExecutors();
        }

        private void BindQueries()
        {
        }

        public void BindQueryRunners()
        {
        }

        public void BindCommands()
        {
        }

        public void BindCommandExecutors()
        {
        }

        private void BindRequestProcessors()
        {
        }
    }
}
