using Course_Application.Controllers;
using Domain.Models;
using Service.Enums;
using Service.Helpers;
using Service.Services.Implementations;

namespace Course_Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GroupController groupController = new();
            StudentController studentController = new();
            GroupService groupService = new();
            StudentService studentService = new();
            bool appRunning = true;

            while (appRunning)
            {
            MainMenuInput: ShowMainMenu();
                Helper.WriteConsole(ConsoleColor.Blue, "Select Option: ");
                string input = Console.ReadLine();
                int number;
                bool isNumber = int.TryParse(input, out number);

                if (isNumber)
                {
                    switch (number)
                    {
                        case 1:
                            bool groupMenuRunning = true;
                            while (groupMenuRunning)
                            {
                                groupController.ShowMenu();
                            GroupMenuInput: string groupMenuInput = Console.ReadLine();
                                int numberGroup;
                                bool isNumberGroup = int.TryParse(groupMenuInput, out numberGroup);

                                if (isNumberGroup)
                                {
                                    switch (numberGroup)
                                    {
                                        case (int)GroupMethods.Create:
                                            groupController.Create();
                                            break;
                                        case (int)GroupMethods.Update:
                                            groupController.Update();
                                            break;
                                        case (int)GroupMethods.Delete:
                                            groupController.Delete();
                                            break;
                                        case (int)GroupMethods.GetById:
                                            groupController.GetGroupById();
                                            break;
                                        case (int)GroupMethods.GetAllByTeacher:
                                            groupController.GetAllGroupsByTeacher();
                                            break;
                                        case (int)GroupMethods.GetAllByRoom:
                                            groupController.GetAllGroupsByRoom();
                                            break;
                                        case (int)GroupMethods.GetAll:
                                            groupController.GetAllGroups();
                                            break;
                                        case (int)GroupMethods.GetAllByName:
                                            groupController.GetAllGroupsByName();
                                            break;
                                        case (int)GroupMethods.GoBackToMainMenu:
                                            groupMenuRunning = false;
                                            goto MainMenuInput;
                                            break;
                                        default:
                                            Helper.WriteConsole(ConsoleColor.Red, "Please enter a valid number between 1 and 9!");
                                            goto GroupMenuInput;
                                    }
                                }
                                else
                                {
                                    Helper.WriteConsole(ConsoleColor.Red, "Please enter a valid number!");
                                    goto GroupMenuInput;
                                }
                            }

                            break;
                        case 2:
                            bool studentMenuRunning = true;
                            while (studentMenuRunning)
                            {
                                studentController.ShowMenu();
                            GroupMenuInput: string groupMenuInput = Console.ReadLine();
                                int numberGroup;
                                bool isNumberGroup = int.TryParse(groupMenuInput, out numberGroup);

                                if (isNumberGroup)
                                {
                                    switch (numberGroup)
                                    {
                                        case (int)StudentMethods.Create:
                                            studentController.Create();
                                            break;
                                        case (int)StudentMethods.Update:
                                            studentController.Update();
                                            break;
                                        case (int)StudentMethods.Delete:
                                            studentController.Delete();
                                            break;
                                        case (int)StudentMethods.GetById:
                                            studentController.GetStudentById();
                                            break;
                                        case (int)StudentMethods.GetAll:
                                            studentController.GetAllStudents();
                                            break;
                                        case (int)StudentMethods.GetAllByAge:
                                           studentController.GetStudentsByAge();
                                            break;
                                        case (int)StudentMethods.GetAllByGroupId:
                                            studentController.GetStudentsByGroupId();
                                            break;
                                        case (int)StudentMethods.GetAllByNameOrSurname:
                                            studentController.GetStudentsByNameOrSurname();
                                            break;
                                        case (int)StudentMethods.GoToMainMenu:
                                            groupMenuRunning = false;
                                            goto MainMenuInput;
                                        default:
                                            Helper.WriteConsole(ConsoleColor.Red, "Please enter a valid number between 1 and 8!");
                                            goto GroupMenuInput;
                                    }
                                }
                                else
                                {
                                    Helper.WriteConsole(ConsoleColor.Red, "Please enter a valid number!");
                                    goto GroupMenuInput;
                                }
                            }
                            break;
                        case 3:
                            appRunning = false;
                            break;
                        default:
                            Helper.WriteConsole(ConsoleColor.Red, "Please enter a valid number between 1 and 3!");
                            goto MainMenuInput;
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Please enter a valid number!");
                    goto MainMenuInput;
                }
            }
        }

        public static void ShowMainMenu()
        {
            Console.Title = "📘 Course Management Console";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║         COURSE MANAGEMENT MENU             ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine("║ 1. Group Methods                           ║");
            Console.WriteLine("║ 2. Student Methods                         ║");
            Console.WriteLine("║ 3. Exit                                    ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }
    }
}
