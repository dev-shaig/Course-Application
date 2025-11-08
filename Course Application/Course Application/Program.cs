using Domain.Models;
using Service.Services.Implementations;

namespace Course_Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Option: ");
            GroupService groupService = new();
            StudentService studentService = new();
            while (true)
            {
            CreateInput: string input = Console.ReadLine();
                int number;
                bool isNumber = int.TryParse(input, out number);

                if (isNumber)
                {
                    switch (number)
                    {
                        case 1:

                            string name = Console.ReadLine();
                            string teacher = Console.ReadLine();
                            int room = Convert.ToInt32(Console.ReadLine());

                            Group group = new Group
                            {
                                Name = name,
                                Teacher = teacher,
                                Room = room
                            };

                            var newGroup = groupService.Create(group);
                            Console.WriteLine($"Group Created: Id: {newGroup.Id}, Name: {newGroup.Name}, Teacher: {newGroup.Teacher}, Room: {newGroup.Room}");

                            break;
                        case 2:
                            Console.WriteLine("Update Group");
                            break;
                        case 3:
                            Console.WriteLine("Get Group By Id");
                            break;
                        case 4:
                            Console.WriteLine("Get All Groups");
                            break;
                        case 5:
                            Console.WriteLine("Delete Group");
                            break;
                        default:
                            Console.WriteLine("Please enter a valid number between 1 and 5");
                            goto CreateInput;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                    goto CreateInput;
                }

            }
        }
    }
}
