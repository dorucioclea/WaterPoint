using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.SqlCommand;
using NHibernate.Tool.hbm2ddl;
using WaterPoint.Data.DbContext.NHibernate.Mappings;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Core.Domain;

namespace WaterPoint.Data.DbContext.NHibernate
{
    public interface ISessionUnitOfWork : IUnitOfWork
    {
        ISession Session { get; }
    }

    public class NHibernateUnitOfWork : ISessionUnitOfWork
    {

        private class SqlStatementInterceptor : EmptyInterceptor
        {
            public override SqlString OnPrepareStatement(SqlString sql)
            {
                Debug.WriteLine(sql.ToString());
                return base.OnPrepareStatement(sql);
            }
        }

        private static readonly ISessionFactory SessionFactory;

        private ITransaction _transaction;

        static NHibernateUnitOfWork()
        {
            var db = MsSqlConfiguration.MsSql2012.ConnectionString(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
#if DEBUG
            db.ShowSql().FormatSql();
#endif
            var config = Fluently.Configure().Database(db);
#if DEBUG
            config.ExposeConfiguration(x => x.SetInterceptor(new SqlStatementInterceptor()));
#endif
            SessionFactory = config.Mappings(m => m
                .FluentMappings.AddFromAssemblyOf<ProductMap>()
                .Conventions.Add(DefaultLazy.Always()))
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();
        }

        public ISession Session { get; private set; }

        public NHibernateUnitOfWork()
        {
            Session = SessionFactory.OpenSession();
        }

        public IUnitOfWork Begin()
        {
            _transaction = Session.BeginTransaction();

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
            finally
            {
                Session.Close();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
