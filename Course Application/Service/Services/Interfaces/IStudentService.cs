using Domain.Models;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        Student Create(Student student);
        Student Update(int id, Student student);
        void Delete(int id);
        Student GetById(Predicate<Student> predicate);
        Student GetByGroupId(Predicate<Student> predicate);
        Student GetByNameOrSurname(Predicate<Student> predicate);
        List<Student> GetAll(Predicate<Student> predicate);

    }
}
