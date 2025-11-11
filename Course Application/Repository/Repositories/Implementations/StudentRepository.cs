using Domain.Models;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.Implementations
{
    public class StudentRepository : IRepository<Student>
    {
        private static int _count = 1;

        public Student Create(Student data)
        {
            try
            {
                if (data is null) throw new DataIsNullException("Data is not found");

                var existingGroup = AppDbContext<Group>.Datas.Find(g => g.Id == data.Group.Id);

                if (existingGroup == null)
                    throw new DataNotFoundException($"Group with Id {data.Group.Id} not found. Student creation failed.");

                data.Group = existingGroup;
                data.Id = _count;
                AppDbContext<Student>.Datas.Add(data);
                _count++;

                return data;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{DateTime.Now} [{ex.GetType().Name}] {ex.Message}");
                Console.ResetColor();
                return null;
            }
        }

        public Student Update(int id, Student data)
        {
            try
            {
                if (data == null)
                    throw new DataIsNullException("Data cannot be null");

                var exist = AppDbContext<Student>.Datas.Find(x => x.Id == id);

                if (exist == null)
                    throw new DataNotFoundException("Student not found");

                var existingGroup = AppDbContext<Group>.Datas.Find(g => g.Id == data.Group.Id);
                if (existingGroup == null)
                    throw new DataNotFoundException($"Group with Id {data.Group.Id} not found. Student update failed.");

                exist.Name = data.Name;
                exist.Surname = data.Surname;
                exist.Age = data.Age;
                exist.Group = existingGroup;

                return exist;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{DateTime.Now} [{ex.GetType().Name}] {ex.Message}");
                Console.ResetColor();
                return null;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var exist = AppDbContext<Student>.Datas.Find(x => x.Id == id);
                if (exist == null) throw new DataNotFoundException("Student not found");

                AppDbContext<Student>.Datas.Remove(exist);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{DateTime.Now} [{ex.GetType().Name}] {ex.Message}");
                Console.ResetColor();
            }
        }
        public Student Get(Predicate<Student>? predicate)
        {
            try
            {
                if (predicate == null) throw new DataIsNullException("Predicate cannot be null");
                var result = AppDbContext<Student>.Datas.Find(predicate);
                if (result == null) throw new DataNotFoundException("Data not found!");
                return result;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{DateTime.Now} [{ex.GetType().Name}] {ex.Message}");
                Console.ResetColor();
                return null;
            }
        }
        public List<Student> GetAll()
        {
            try
            {
                return AppDbContext<Student>.Datas;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{DateTime.Now} [{ex.GetType().Name}] {ex.Message}");
                Console.ResetColor();
                return new List<Student>();
            }
        }
        public List<Student> GetAll(Predicate<Student>? predicate)
        {
            try
            {
                if (predicate == null) throw new DataIsNullException("Predicate cannot be null");
                return AppDbContext<Student>.Datas.FindAll(predicate);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{DateTime.Now} [{ex.GetType().Name}] {ex.Message}");
                Console.ResetColor();
                return new List<Student>();
            }
        }
    }
}