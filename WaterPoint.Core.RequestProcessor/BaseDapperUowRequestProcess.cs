﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity;

namespace WaterPoint.Core.RequestProcessor
{
    public abstract class BaseDapperUowRequestProcess<TInput, TOutput>: IRequestProcessor<TInput, TOutput>
    {
        protected IDapperUnitOfWork DapperUnitOfWork { get; }

        protected BaseDapperUowRequestProcess(IDapperUnitOfWork dapperUnitOfWork)
        {
            DapperUnitOfWork = dapperUnitOfWork;
        }

        public abstract TOutput GetResult(TInput request);
    }
}