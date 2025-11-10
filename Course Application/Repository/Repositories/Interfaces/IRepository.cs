using Domain.Common;
using Domain.Models;

namespace Repository.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T data);
        T Update(int id, T data);
        void Delete(int id);
        T Get(Predicate<T>? predicate);
        List<T> GetAll();
        List<T> GetAll(Predicate<T>? predicate);
    }
}
