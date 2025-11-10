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
                if (data is null) throw new Exception("data is not found");

                data.Id = _count++;
                AppDbContext<Student>.Datas.Add(data);

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Student Update(int id, Student data)
        {
            try
            {
                if (data == null)
                    throw new Exception("Data cannot be null");

                var exist = AppDbContext<Student>.Datas.Find(x => x.Id == id);

                if (exist == null)
                    throw new Exception("Student not found");

                exist.Name = data.Name;
                exist.Surname = data.Surname;
                exist.Age = data.Age;
                exist.Group = data.Group;
                return exist;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public void Delete(int id)
        {
            try
            {
                var exist = AppDbContext<Student>.Datas.Find(x => x.Id == id);

                if (exist == null) throw new Exception("Group not found");

                AppDbContext<Student>.Datas.Remove(exist);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Student Get(Predicate<Student>? predicate)
        {
            try
            {
                if (predicate == null) throw new Exception("Predicate cannot be null");

                var result = AppDbContext<Student>.Datas.Find(predicate);

                if (result == null) throw new Exception("Data not found!");

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                Console.WriteLine(ex.Message);
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
                Console.WriteLine(ex.Message);
                return new List<Student>();
            }
        }
    }
}
