using Domain.Models;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        Group Create(Group group);
        Group Update(int id, Group group);
        Group GetGroupById(int id);
        void Delete(int id);
        List<Group> GetAllGroupsByName(string name);
        List<Group> GetAllGroupsByTeacher(string teacher);
        List<Group> GetAllGroupsByRoom(int room);
        List<Group> GetAll();
    }
}
