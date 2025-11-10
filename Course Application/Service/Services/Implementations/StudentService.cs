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
            student.Id = count;

            _studentRepository.Create(student);

            count++;
            return student;
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

        public List<Student> GetStudentsByGroupId(int groupId)
        {
            List<Student> students  = _studentRepository.GetAll(s => s.Group.Id == groupId);
            return students;
        }

        public Student GetStudentById(int id)
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
            _studentRepository.Update(id, student);
            return student;
        }
    }
}
