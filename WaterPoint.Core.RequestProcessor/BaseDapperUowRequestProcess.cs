using System;
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

        protected TO UowProcess<TI, TO>(Func<TI, TO> processDelegate, TI input)
        {
            using (DapperUnitOfWork.Begin())
            {
                try
                {
                    var result = processDelegate.Invoke(input);

                    DapperUnitOfWork.Commit();

                    return result;
                }
                catch
                {
                    DapperUnitOfWork.Rollback();
                    throw;
                }
            }
        }
    }
}
