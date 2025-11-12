using Domain.Models;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repositories.Interfaces;

public class GroupRepository : IRepository<Group>
{
    private static int _count = 1;

    public Group Create(Group data)
    {
        try
        {
            if (data is null) throw new DataIsNullException("Data not found");

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
            if (data == null) throw new DataIsNullException("Predicate cannot be null");
            var exist = AppDbContext<Group>.Datas.Find(x => x.Id == id);
            if (exist == null) throw new DataNotFoundException("Group not found");
            exist.Name = data.Name;
            exist.Teacher = data.Teacher;
            exist.Room = data.Room;
            return exist;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            return null;
        }
    }
    public void Delete(int id)
    {
        try
        {
            var exist = AppDbContext<Group>.Datas.Find(x => x.Id == id);
            if (exist == null) throw new DataNotFoundException("Group not found");
            AppDbContext<Group>.Datas.Remove(exist);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
    }
    public Group Get(Predicate<Group>? predicate)
    {
        try
        {
            if (predicate == null) throw new DataIsNullException("Predicate cannot be null");
            var result = AppDbContext<Group>.Datas.Find(predicate);
            if (result == null) throw new DataNotFoundException("Data not found!");
            return result;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            return new List<Group>();
        }
    }

    public List<Group> GetAll(Predicate<Group>? predicate)
    {
        try
        {
            if (predicate == null) throw new DataIsNullException("Predicate cannot be null");
            var result = AppDbContext<Group>.Datas.FindAll(predicate);
            if (result == null || result.Count == 0) throw new DataNotFoundException("Data not found!");
            return result;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            return new List<Group>();
        }
    }
}