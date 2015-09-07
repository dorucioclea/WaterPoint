using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using NHibernate;
using WaterPoint.Core.Domain.Repositories;
using WaterPoint.Data.DbContext.NHibernate;

namespace WaterPoint.Core.Repository
{
    public interface INHibernateRepository<T> : IRepository<T> where T : class
    {
        ISession Session { get; }
    }

    public class NHibernateRepository<T> : INHibernateRepository<T> where T : class
    {
        private readonly ISessionUnitOfWork _uow;

        public ISession Session { get { return _uow.Session; } }

        public NHibernateRepository(ISessionUnitOfWork uow)
        {
            _uow = uow;
        }

        public T GetById(int id)
        {
            return Session.Get<T>(id);
        }

        public void Create(T entity)
        {
            Session.Save(entity);
        }

        public void Update(T entity)
        {
            Session.Update(entity);
        }

        public void Delete(int id)
        {
            Session.Delete(Session.Load<T>(id));
        }
    }
}
