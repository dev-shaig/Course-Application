using Domain.Models;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.Implementations
{
    public class StudentRepository : IRepository<Student>
    {
        public void Create(Student entity)
        {
            throw new NotImplementedException();
        }
        public void Update(int id, Student entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Student Get(Predicate<Student>? predicate)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll(Predicate<Student>? predicate)
        {
            throw new NotImplementedException();
        }

       
    }
}
