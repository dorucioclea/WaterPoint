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
        public IDapperDbContext DbContext { get; private set; }

        public DapperUnitOfWork(IDapperDbContext dbContext)
        {
            DbContext = dbContext;
        }

        #region IDapperUnitOfWork implmentation

        private IDbTransaction _transaction;

        ~DapperUnitOfWork()
        {
            Dispose(false);
        }

        public IUnitOfWork Begin()
        {
            DbContext.Connection.Open();

            _transaction = DbContext.GetTransaction();

            return this;
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
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

            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }

            if (DbContext.Connection == null)
                return;

            DbContext.Connection.Close();
            DbContext.Connection.Dispose();
        }

        #endregion
    }
}
