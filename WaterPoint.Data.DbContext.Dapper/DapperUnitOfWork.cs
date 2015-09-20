using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Core.Domain;
using Dapper;
using System.Data;

namespace WaterPoint.Data.DbContext.Dapper
{
    public class DapperUnitOfWork : IDapperUnitOfWork
    {
        private IDbTransaction _dbTransaction;

        public DapperUnitOfWork(IDapperDbContext dbContext)
        {
            DbContext = dbContext;
        }

        ~DapperUnitOfWork()
        {
            Dispose(false);
        }

        public IDapperDbContext DbContext { get; }

        public IUnitOfWork Begin()
        {
            DbContext.Connection.Open();

            _dbTransaction = DbContext.Connection.BeginTransaction();

            return this;
        }

        public void Commit()
        {
            try
            {
                _dbTransaction.Commit();
            }
            catch
            {
                Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            _dbTransaction.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool dispose)
        {
            if (!dispose)
            {
                DbContext.Connection.Close();
                return;
            }

            if (_dbTransaction != null)
            {
                _dbTransaction.Dispose();

                _dbTransaction = null;
            }

            DbContext.Connection?.Close();
            DbContext.Connection?.Dispose();
        }
    }
}
