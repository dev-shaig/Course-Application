using Domain.Models;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        Student Create(Student student);
        Student Update(int id, Student student);
        void Delete(int id);
        Student GetStudentById(int id);
        List<Student> GetStudentsByGroupId(int id);
        List<Student> GetByNameOrSurname(string text);
        List<Student> GetAll();

    }
}
