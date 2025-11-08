using Domain.Common;

namespace Repository.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(int id, T entity);
        void Delete(int id);
        T Get(Predicate<T>? predicate);
        List<T> GetAll(Predicate<T>? predicate);
    }
}
