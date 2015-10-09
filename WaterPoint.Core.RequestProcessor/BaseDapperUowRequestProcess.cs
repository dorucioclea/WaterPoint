using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Blls;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity;

namespace WaterPoint.Core.RequestProcessor
{
    public abstract class BaseDapperUowRequestProcess<TInput, TOutput>: IRequestProcessor<TInput, TOutput>
    {
        public ICoreMapper Mapper { get; private set; }
        public IDapperUnitOfWork DapperUnitOfWork { get; private set; }

        protected BaseDapperUowRequestProcess(
            ICoreMapper coreMapper,
            IDapperUnitOfWork dapperUnitOfWork)
        {
            Mapper = coreMapper;
            DapperUnitOfWork = dapperUnitOfWork;
        }

        public abstract TOutput Process(TInput request);
    }
}
