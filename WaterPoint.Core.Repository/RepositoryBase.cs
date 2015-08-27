using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using WaterPoint.Core.Domain;
using WaterPoint.Data.DbContext;
using WaterPoint.Data.DbContext.NHibernate;
using WaterPoint.Data.Entity;

namespace WaterPoint.Core.Repository
{
    public abstract class RepositoryBase<T> where T : class
    {
        private readonly ISessionUnitOfWork _uow;

        protected ISession Session { get { return _uow.Session; } }

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
