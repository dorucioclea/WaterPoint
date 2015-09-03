using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
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
        private static readonly ISessionFactory SessionFactory;

        private ITransaction _transaction;

        static NHibernateUnitOfWork()
        {
            SessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProductMap>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();
        }

        public ISession Session { get; private set; }

        public NHibernateUnitOfWork()
        {
            Session = SessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                Session.Close();
            }
        }
    }
}
