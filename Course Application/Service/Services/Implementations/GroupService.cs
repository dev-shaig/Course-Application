using Domain.Models;
using Repository.Repositories.Implementations;
using Service.Services.Interfaces;

namespace Service.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private GroupRepository _groupRepository;

        public GroupService()
        {
            _groupRepository = new();
        }

        public Group Create(Group group)
        {
            return _groupRepository.Create(group);
         
        }

        public void Delete(int id)
        {
            _groupRepository.Delete(id);
        }

        public List<Group> GetAll()
        {
            List<Group> allGroups = _groupRepository.GetAll();
            return allGroups;
        }


        public Group GetGroupById(int id)
        {
            Group existData = _groupRepository.Get(x => x.Id == id);

            if (existData != null)
            {
                return existData;
            }
            return null;
        }

        public Group Update(int id, Group group)
        {
            return _groupRepository.Update(id, group);       
        }


        public List<Group> GetAllGroupsByName(string name)
        {
           List<Group> groups = _groupRepository.GetAll(g => g.Name.Trim().ToLower().StartsWith(name.Trim().ToLower()));
            return groups;
        }

        public List<Group> GetAllGroupsByTeacher(string teacher)
        {
            List<Group> groups = _groupRepository.GetAll(g => g.Teacher.Trim().ToLower().StartsWith(teacher.Trim().ToLower()));
            return groups;
        }


        public List<Group> GetAllGroupsByRoom(int room)
        {
            List<Group> groups = _groupRepository.GetAll(g => g.Room == room);
            return groups;
        }
    }
}
