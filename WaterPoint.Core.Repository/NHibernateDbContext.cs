using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using NHibernate;
using WaterPoint.Data.DbContext.NHibernate;

namespace WaterPoint.Core.Repository
{
    public class NHibernateDbContext<T> : INHibernateDbContext<T> where T : class
    {
        private readonly ISessionUnitOfWork _uow;

        public ISession Session { get { return _uow.Session; } }

        public NHibernateDbContext(ISessionUnitOfWork uow)
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
