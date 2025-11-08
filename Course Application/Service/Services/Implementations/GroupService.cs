using Domain.Models;
using Repository.Repositories.Implementations;
using Service.Services.Interfaces;

namespace Service.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private GroupRepository _groupRepository;
        public int count;

        public GroupService()
        {
            _groupRepository = new();
        }


        public Group Create(Group group)
        {
            group.Id = count;

            _groupRepository.Create(group);

            count++;
            return group;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAll(Predicate<Group> predicate)
        {
            throw new NotImplementedException();
        }

        public Group GetAllGroupsByName(Predicate<Group> predicate)
        {
            throw new NotImplementedException();
        }

        public Group GetAllGroupsByRoom(Predicate<Group> predicate)
        {
            throw new NotImplementedException();
        }

        public Group GetAllGroupsByTeacher(Predicate<Group> predicate)
        {
            throw new NotImplementedException();
        }

        public Group GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Group Update(int id, Group group)
        {
            throw new NotImplementedException();
        }
    }
}
