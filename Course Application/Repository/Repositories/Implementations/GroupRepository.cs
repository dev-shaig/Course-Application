using Domain.Models;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.Implementations
{
    public class GroupRepository : IRepository<Group> 
    {
        private static int _count = 1;

        public Group Create(Group data)
        {
            try
            {
                if (data is null) throw new Exception("data is not found");

                data.Id = _count++; 
                AppDbContext<Group>.Datas.Add(data);

                return data; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null; 
            }
        }

        public Group Update(int id, Group data)
        {
            try
            {
                var exist = AppDbContext<Group>.Datas.Find(x => x.Id == id);
                if (exist == null) throw new Exception("Group not found");

                exist.Name = data.Name;
                exist.Teacher = data.Teacher;
                exist.Room = data.Room;

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
                var exist = AppDbContext<Group>.Datas.Find(x => x.Id == id);

                if (exist == null) throw new Exception("Group not found");

                AppDbContext<Group>.Datas.Remove(exist);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public Group Get(Predicate<Group>? predicate)
        {
            try
            {
                if (predicate == null) throw new Exception("Predicate cannot be null");

                var result = AppDbContext<Group>.Datas.Find(predicate);

                if (result == null) throw new Exception("Data not found!");

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Group> GetAll()
        {
            try
            {
                return AppDbContext<Group>.Datas;
            }
            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Group>();
            }
        }

        public List<Group> GetAll(Predicate<Group>? predicate)
        {
            try
            {
                if (predicate == null) throw new DataIsNullException("Predicate cannot be null");
                return AppDbContext<Group>.Datas.FindAll(predicate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Group>();
            }
        }
    } 
}
