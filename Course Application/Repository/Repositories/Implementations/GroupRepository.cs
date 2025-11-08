using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.Implementations
{
    public class GroupRepository : IRepository<Group> 
    {
        public void Create(Group entity)
        {
            try
            {
                if (entity is null) { throw new Exception("data is not found"); }

                AppDbContext<Group>.Datas.Add(entity);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update(int id, Group entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Group Get(Predicate<Group>? predicate)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAll(Predicate<Group>? predicate)
        {
            throw new NotImplementedException();
        }

       
    }
}
