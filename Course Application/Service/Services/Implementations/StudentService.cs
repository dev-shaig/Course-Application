using Domain.Models;
using Repository.Repositories.Implementations;
using Service.Services.Interfaces;

namespace Service.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private StudentRepository _studentRepository;
        public static int count;
        public StudentService()
        {
            _studentRepository = new();
        }

        public Student Create(Student student)
        {
            return _studentRepository.Create(student);
        }

        public void Delete(int id)
        {
            _studentRepository.Delete(id);
        }

        public List<Student> GetAll()
        {
            List<Student> allStudents = _studentRepository.GetAll();
            return allStudents;
        }

        public List<Student> GetByNameOrSurname(string text)
        {
            List<Student> students = _studentRepository.GetAll(s => s.Name.Trim().ToLower().StartsWith(text.Trim().ToLower()) || s.Surname.Trim().ToLower().StartsWith(text.Trim().ToLower()));
            return students;
        }

        public List<Student> GetAllByGroupId(int groupId)
        {
            List<Student> students  = _studentRepository.GetAll(s => s.Group.Id == groupId);
            return students;
        }

        public Student GetById(int id)
        {
           Student existData = _studentRepository.Get(x => x.Id == id);

            if (existData != null)
            {
                return existData;
            }
            return null;
        }

        public Student Update(int id, Student student)
        {
            return _studentRepository.Update(id, student);
        }
        public List<Student> GetByAge(int age)
        {
            List<Student> students = _studentRepository.GetAll(s => s.Age == age);
            return students;
        }
    }
}
