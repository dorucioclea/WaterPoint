using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using NHibernate;
using WaterPoint.Core.Domain.Repositories;
using WaterPoint.Data.DbContext.NHibernate;

namespace WaterPoint.Core.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ISessionUnitOfWork _uow;

        public ISession Session { get { return _uow.Session; } }

        protected RepositoryBase(ISessionUnitOfWork uow)
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
