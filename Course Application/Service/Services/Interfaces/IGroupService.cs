using Domain.Models;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        Group Create(Group group);
        Group Update(int id, Group group);
        Group GetById(int id);
        void Delete(int id);
        Group GetAllGroupsByName(Predicate<Group> predicate);
        Group GetAllGroupsByTeacher(Predicate<Group> predicate);
        Group GetAllGroupsByRoom(Predicate<Group> predicate);
        List<Group> GetAll(Predicate<Group> predicate);
    }
}
