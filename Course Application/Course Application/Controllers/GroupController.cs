using Domain.Models;
using Repository.Data;
using Service.Helpers;
using Service.Services.Implementations;

namespace Course_Application.Controllers
{
    public class GroupController
    {
        GroupService groupService = new();
        List<Group> groupDatas = AppDbContext<Group>.Datas;
        public void ShowMenu()
        {
            Console.Title = "📘 Group Management Console";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║            GROUP MANAGEMENT MENU           ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine("║ 1. Create Group                            ║");
            Console.WriteLine("║ 2. Update Group                            ║");
            Console.WriteLine("║ 3. Delete Group                            ║");
            Console.WriteLine("║ 4. Search Group By Id                      ║");
            Console.WriteLine("║ 5. Get All Groups By Teacher               ║");
            Console.WriteLine("║ 6. Get All Groups By Room                  ║");
            Console.WriteLine("║ 7. Get All Groups                          ║");
            Console.WriteLine("║ 8. Search Groups By Name                   ║");
            Console.WriteLine("║ 9. Go Back To Main Menu                     ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        private bool ContainsInvalidChars(string input)
        {
            char[] invalidChars = { '*', '"', '-', ':', ';', '[', ']', '{', '}', '(', ')', '~', '+', '^', '$', '@', '*', '=', '&', '%', '#', '!', '?', '/', '\\' };
            foreach (char c in invalidChars)
            {
                if (input.Contains(c))
                    return true;
            }
            return false;
        }
        public void Create()
        {
            string name, teacher;
            int room;

        EnterGroupName:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter Group Name: ");
            name = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group name cannot be empty!");
                goto EnterGroupName;
            }
            else if (ContainsInvalidChars(name))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group name contains invalid characters! Try again.");
                goto EnterGroupName;
            }

        EnterTeacherName:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter Teacher Name: ");
            teacher = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(teacher))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Teacher name cannot be empty!");
                goto EnterTeacherName;
            }
            else if (ContainsInvalidChars(teacher))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Teacher name contains invalid characters! Try again.");
                goto EnterTeacherName;
            }

        EnterRoomNumber:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter Room Number: ");
            if (!int.TryParse(Console.ReadLine(), out room) || room <= 0)
            {
                Helper.WriteConsole(ConsoleColor.Red, "Invalid room number! Must be a positive number.");
                goto EnterRoomNumber;
            }

            Group group = new Group
            {
                Name = name,
                Teacher = teacher,
                Room = room
            };

            var newGroup = groupService.Create(group);
            Helper.WriteConsole(ConsoleColor.Green,
                $"Group Created: Id: {newGroup.Id}, Name: {newGroup.Name}, Teacher: {newGroup.Teacher}, Room: {newGroup.Room}");
        }
        public void Update()
        {
            if (groupDatas == null || groupDatas.Count == 0)
            {
                Helper.WriteConsole(ConsoleColor.Red, "There is Nothing to Update!");
                return;
            }

        EnterId:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter Group Id to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Helper.WriteConsole(ConsoleColor.Red, "Invalid Group Id! Please enter a positive number.");
                goto EnterId;
            }

            var existingGroup = groupDatas.FirstOrDefault(g => g.Id == id);
            if (existingGroup == null)
            {
                Helper.WriteConsole(ConsoleColor.Red, $"No group found with Id {id}. Please enter a valid Id.");
                goto EnterId;
            }

        EnterName:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter New Group Name: ");
            string name = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group name cannot be empty!");
                goto EnterName;
            }
            else if (ContainsInvalidChars(name))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group name contains invalid characters! Try again.");
                goto EnterName;
            }

        EnterTeacher:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter New Teacher: ");
            string teacher = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(teacher))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Teacher name cannot be empty!");
                goto EnterTeacher;
            }
            else if (ContainsInvalidChars(teacher))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Teacher name contains invalid characters! Try again.");
                goto EnterTeacher;
            }

        EnterRoom:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter New Room Number: ");
            if (!int.TryParse(Console.ReadLine(), out int room) || room <= 0)
            {
                Helper.WriteConsole(ConsoleColor.Red, "Invalid room number! Try again.");
                goto EnterRoom;
            }

            Group group = new Group
            {
                Name = name,
                Teacher = teacher,
                Room = room
            };

            var updatedGroup = groupService.Update(id, group);
            if (updatedGroup != null)
            {
                Helper.WriteConsole(ConsoleColor.Green,
                    $"Group Updated: Id: {updatedGroup.Id}, Name: {updatedGroup.Name}, Teacher: {updatedGroup.Teacher}, Room: {updatedGroup.Room}");
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group not found or could not be updated.");
            }
        }

        public void Delete()
        {
            if (groupDatas == null || groupDatas.Count == 0)
            {
                Helper.WriteConsole(ConsoleColor.Red, "There is Nothing to Delete!");
            }
            else
            {
            EnterId:
                Helper.WriteConsole(ConsoleColor.Cyan, "Enter Group Id to delete: ");
                if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Invalid Group Id! Try again.");
                    goto EnterId;
                }
                var isDeleted = groupService.GetGroupById(id);
                if (isDeleted != null)
                {
                    Helper.WriteConsole(ConsoleColor.Green, "Group successfully deleted!");
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Group not found! Deletion failed.");
                    goto EnterId;
                }
            }
        }

        public void GetGroupById()
        {
        EnterId:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter Group Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Helper.WriteConsole(ConsoleColor.Red, "Invalid Group Id! Try again.");
                goto EnterId;
            }

            var group = groupService.GetGroupById(id);
            if (group != null)
            {
                Helper.WriteConsole(ConsoleColor.Green,
                    $"Group Found: Id: {group.Id}, Name: {group.Name}, Teacher: {group.Teacher}, Room: {group.Room}");
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Yellow, "Group not found.");
            }
        }
        public void GetAllGroups()
        {
            var groups = groupService.GetAll();

            if (groups.Count == 0)
            {
                Helper.WriteConsole(ConsoleColor.Yellow, "No groups available.");
                return;
            }

            Console.WriteLine("All Groups:");
            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Id} - {group.Name} - {group.Teacher} - {group.Room}");
            }
        }
        public void GetAllGroupsByName()
        {
        EnterName:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter group name: ");
            string name = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group name cannot be empty!");
                goto EnterName;
            }
            else if (ContainsInvalidChars(name))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group name contains invalid characters! Try again.");
                goto EnterName;
            }

            var groups = groupService.GetAllGroupsByName(name);

            if (groups.Count == 0)
            {
                Helper.WriteConsole(ConsoleColor.Yellow, "No groups found with this name.");
                return;
            }

            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Id} - {group.Name} - {group.Teacher} - {group.Room}");
            }
        }
        public void GetAllGroupsByTeacher()
        {
        EnterTeacher:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter teacher name: ");
            string teacher = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(teacher))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Teacher name cannot be empty!");
                goto EnterTeacher;
            }
            else if (ContainsInvalidChars(teacher))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Teacher name contains invalid characters! Try again.");
                goto EnterTeacher;
            }

            var groups = groupService.GetAllGroupsByTeacher(teacher);

            if (groups.Count == 0)
            {
                Helper.WriteConsole(ConsoleColor.Yellow, "No groups found for this teacher.");
                return;
            }

            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Id} - {group.Name} - {group.Teacher} - {group.Room}");
            }
        }
        public void GetAllGroupsByRoom()
        {
        EnterRoom:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter room number: ");
            if (!int.TryParse(Console.ReadLine(), out int room) || room <= 0)
            {
                Helper.WriteConsole(ConsoleColor.Red, "Invalid room number. Try again.");
                goto EnterRoom;
            }

            var groups = groupService.GetAllGroupsByRoom(room);

            if (groups.Count == 0)
            {
                Helper.WriteConsole(ConsoleColor.Yellow, "No groups found in this room.");
                return;
            }

            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Id} - {group.Name} - {group.Teacher} - {group.Room}");
            }
        }
    }
}


