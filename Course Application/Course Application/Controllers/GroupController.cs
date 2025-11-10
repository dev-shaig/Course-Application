using Domain.Models;
using Service.Helpers;
using Service.Services.Implementations;

namespace Course_Application.Controllers
{
    public class GroupController
    {
        GroupService groupService = new();
        private GroupService _groupService;

        public void ShowMenu()
        {
            Console.Title = "📘 Group Management Console";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════════════════════════════════════╗");
            Console.WriteLine("║         GROUP MANAGEMENT MENU         ║");
            Console.WriteLine("╠═══════════════════════════════════════╣");
            Console.WriteLine("║ 1. Search groups by name              ║");
            Console.WriteLine("║ 2. Search groups by teacher           ║");
            Console.WriteLine("║ 3. Search groups by sssm              ║");
            Console.WriteLine("║ 3. Search groups by room              ║");
            Console.WriteLine("║ 0. Exit                               ║");
            Console.WriteLine("╚═══════════════════════════════════════╝");
            Console.ResetColor();
        }

        public void CreateGroup()
        {
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter Group Name: ");
            string createGrupName = Console.ReadLine();
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter Teacher: ");
            string createGroupTeacher = Console.ReadLine();
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter Room: ");
            int createGroupRoom = Convert.ToInt32(Console.ReadLine());

        CreateGroup:string groupId = Console.ReadLine();
            int groupIdNumber;
            bool isGroupIdNumber = int.TryParse(groupId, out groupIdNumber);

            if (isGroupIdNumber)
            {
                Group group = new Group
                {
                    Name = createGrupName,
                    Teacher = createGroupTeacher,
                    Room = createGroupRoom
                };

                var newGroup = groupService.Create(group);
                Console.WriteLine($"Group Created: Id: {newGroup.Id}, Name: {newGroup.Name}, Teacher: {newGroup.Teacher}, Room: {newGroup.Room}");
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Invalid Group Id. Please enter a valid number.");
                goto CreateGroup;
            }
        }

        public void Update()
        {
        UpdateGroup: string groupId = Console.ReadLine();
            int groupIdNumber;
            bool isGroupIdNumber = int.TryParse(groupId, out groupIdNumber);

            if (isGroupIdNumber)
            {

                Helper.WriteConsole(ConsoleColor.Cyan, "Enter Group Name: ");
                string updatedGrupName = Console.ReadLine();
                Helper.WriteConsole(ConsoleColor.Cyan, "Enter Teacher: ");
                string updatedGroupTeacher = Console.ReadLine();
                Helper.WriteConsole(ConsoleColor.Cyan, "Enter Room: ");
                int updatedGroupRoom = Convert.ToInt32(Console.ReadLine());

                Group group = new Group
                {
                    Name = updatedGrupName,
                    Teacher = updatedGroupTeacher,
                    Room = updatedGroupRoom
                };

                var updatedGroup = groupService.Create(group);
                Console.WriteLine($"Group Created: Id: {updatedGroup.Id}, Name: {updatedGroup.Name}, Teacher: {updatedGroup.Teacher}, Room: {updatedGroup.Room}");
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Invalid Group Id. Please enter a valid number.");
                goto UpdateGroup;
            }
        }

        public void Delete()
        {
        DeleteGroup: Console.WriteLine("Enter Group Id: ");
            string groupId = Console.ReadLine();
            int groupIdNumber;
            bool isGroupIdNumber = int.TryParse(groupId, out groupIdNumber);

            if (isGroupIdNumber)
            {
                groupService.Delete(groupIdNumber);
                Console.WriteLine("Group successfully deleted!");
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Invalid Group Id. Please enter a valid number.");
                goto DeleteGroup;
            }         
        }

        public void GetGroupById()
        {
            Console.WriteLine("Enter Group Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var group = groupService.GetGroupById(id);
            if (group != null)
            {
                Console.WriteLine($"Group Found: Id: {group.Id}, Name: {group.Name}, Teacher: {group.Teacher}, Room: {group.Room}");
            }
            else
            {
                Console.WriteLine("Group not found.");
            }
        }

        public void GetAllGroupsByName()
        {
            Console.Write("Enter group name: ");
            string name = Console.ReadLine();

            var groups = _groupService.GetAllGroupsByName(name);

            if (groups.Count == 0)
            {
                Console.WriteLine("No groups found with this name.");
                return;
            }

            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Id} - {group.Name} - {group.Teacher} - {group.Room}");
            }
        }

        public void GetAllGroupsByTeacher()
        {
            Console.Write("Enter teacher name: ");
            string teacher = Console.ReadLine();

            var groups = _groupService.GetAllGroupsByTeacher(teacher);

            if (groups.Count == 0)
            {
                Console.WriteLine("No groups found for this teacher.");
                return;
            }

            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Id} - {group.Name} - {group.Teacher} - {group.Room}");
            }
        }

        public void GetAllGroupsByRoom(int room)
        {
            var groups = _groupService.GetAllGroupsByRoom(room);

            if (groups.Count == 0)
            {
                Console.WriteLine("No groups found in this room.");
                return;
            }

            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Id} - {group.Name} - {group.Teacher} - {group.Room}");
            }



        }
    }
}
