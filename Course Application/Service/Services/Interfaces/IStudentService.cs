using Domain.Models;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        Student Create(Student student);
        Student Update(int id, Student student);
        void Delete(int id);
        Student GetById(int id);
        List<Student> GetAllByGroupId(int id);
        List<Student> GetByNameOrSurname(string text);
        List<Student> GetByAge(int age);
        List<Student> GetAll();

    }
}
