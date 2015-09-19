using NHibernate;
using WaterPoint.Core.Domain.Repositories;

namespace WaterPoint.Core.Repository
{
    public interface INHibernateDbContext<T> : IRepository<T> where T : class
    {
        ISession Session { get; }
    }
}
