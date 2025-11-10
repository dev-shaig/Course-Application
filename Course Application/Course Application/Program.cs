using Course_Application.Controllers;
using Domain.Models;
using Service.Services.Implementations;

namespace Course_Application
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "📘 Group Management Console";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════════════════════════════════════╗");
            Console.WriteLine("║         GROUP MANAGEMENT MENU         ║");
            Console.WriteLine("╠═══════════════════════════════════════╣");
            Console.WriteLine("║ 1. Search groups by name              ║");
            Console.WriteLine("║ 2. Search groups by teacher           ║");
            Console.WriteLine("║ 3. Search groups by room              ║");
            Console.WriteLine("║ 0. Exit                               ║");
            Console.WriteLine("╚═══════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine("Select Option: ");
            
            GroupController groupController = new();
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
                            groupController.CreateGroup();
                            break;
                        case 2:
                            
                            groupController.GetAllGroupsByName();
                            break;
                        case 3:
                            groupController.GetGroupById();
                            break;
                        case 4:
                            groupController.GetAllGroupsByTeacher();
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
