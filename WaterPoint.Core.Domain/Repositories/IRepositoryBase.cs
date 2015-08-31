
namespace WaterPoint.Core.Domain.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
