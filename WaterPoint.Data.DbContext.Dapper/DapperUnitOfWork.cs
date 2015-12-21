using System.Data;
using WaterPoint.Core.Domain.Db;

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
            Dispose();
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
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }

            if (DbContext.Connection != null && DbContext.Connection.State != ConnectionState.Closed)
                DbContext.Connection.Close();

        }

        #endregion
    }
}
