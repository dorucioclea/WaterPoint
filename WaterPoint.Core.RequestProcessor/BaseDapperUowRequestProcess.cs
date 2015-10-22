using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor
{
    public abstract class BaseDapperUowRequestProcess
    {
        public IDapperUnitOfWork DapperUnitOfWork { get; private set; }

        protected BaseDapperUowRequestProcess(IDapperUnitOfWork dapperUnitOfWork)
        {
            DapperUnitOfWork = dapperUnitOfWork;
        }
    }
}
