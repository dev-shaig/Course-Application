using Domain.Models;
using Service.Helpers;
using Service.Services.Implementations;

namespace Course_Application.Controllers
{
    public class StudentController
    {
        StudentService studentService = new();

        public void ShowMenu()
        {
            Console.Title = "Student Management Console";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║           STUDENT MANAGEMENT MENU          ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine("║ 1. Create Student                          ║");
            Console.WriteLine("║ 2. Update Student                          ║");
            Console.WriteLine("║ 3. Delete Student                          ║");
            Console.WriteLine("║ 4. Search Student By Id                    ║");
            Console.WriteLine("║ 5. Get All Students                        ║");
            Console.WriteLine("║ 6. Get All Students By Age                 ║");
            Console.WriteLine("║ 7. Get All Students By Group Id            ║");
            Console.WriteLine("║ 8. Search Students By Name/Surname         ║");
            Console.WriteLine("║ 9. Go Back To Main Menu                    ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        private bool ContainsInvalidChars(string input)
        {
            char[] invalidChars = { '$', '@', '*', '=', '&', '%', '#', '!', '?', '/', '\\', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            foreach (char c in invalidChars)
            {
                if (input.Contains(c))
                    return true;
            }
            return false;
        }
        public void Create()
        {
            string name;
            string surname;
            int groupId;
            int age;

        EnterName:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter Student Name: ");
            name = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Name cannot be empty!");
                goto EnterName;
            }
            else if (ContainsInvalidChars(name))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Name contains invalid characters!");
                goto EnterName;
            }

        EnterSurname:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter Student Surname: ");
            surname = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(surname))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Surname cannot be empty!");
                goto EnterSurname;
            }
            else if (ContainsInvalidChars(surname))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Surname contains invalid characters!");
                goto EnterSurname;
            }

        EnterAge:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter Student Age: ");
            if (!int.TryParse(Console.ReadLine(), out age) || age < 6 || age > 100)
            {
                Helper.WriteConsole(ConsoleColor.Red, "Invalid Age! Must be between 6 and 100.");
                goto EnterAge;
            }

        EnterGroupId:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter Group Id: ");
            if (!int.TryParse(Console.ReadLine(), out groupId) || groupId <= 0)
            {
                Helper.WriteConsole(ConsoleColor.Red, "Invalid Group Id! Must be a positive number.");
                goto EnterGroupId;
            }

            Student student = new Student
            {
                Name = name,
                Surname = surname,
                Age = age,
                Group = new Group { Id = groupId }
            };

            var newStudent = studentService.Create(student);
            if (newStudent != null)
            {
                Helper.WriteConsole(ConsoleColor.Green,
                    $"Student Created: Id: {newStudent.Id}, Name: {newStudent.Name}, Surname: {newStudent.Surname}, Age: {newStudent.Age}, GroupId: {newStudent.Group.Id}");
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Failed to create student!");
            }
        }
        public void Update()
        {
        EnterId:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter Student Id to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Helper.WriteConsole(ConsoleColor.Red, "Invalid Id! Try again.");
                goto EnterId;
            }

        EnterName:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter New Name: ");
            string name = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Name cannot be empty!");
                goto EnterName;
            }
            else if (ContainsInvalidChars(name))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Invalid characters in name!");
                goto EnterName;
            }

        EnterSurname:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter New Surname: ");
            string surname = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(surname))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Surname cannot be empty!");
                goto EnterSurname;
            }
            else if (ContainsInvalidChars(surname))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Invalid characters in surname!");
                goto EnterSurname;
            }

        EnterAge:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter New Age: ");
            if (!int.TryParse(Console.ReadLine(), out int age) || age < 6 || age > 100)
            {
                Helper.WriteConsole(ConsoleColor.Red, "Invalid Age! Must be between 6 and 100.");
                goto EnterAge;
            }

        EnterGroupId:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter New Group Id: ");
            if (!int.TryParse(Console.ReadLine(), out int groupId) || groupId <= 0)
            {
                Helper.WriteConsole(ConsoleColor.Red, "Invalid Group Id!");
                goto EnterGroupId;
            }

            Student student = new Student
            {
                Name = name,
                Surname = surname,
                Age = age,
                Group = new Group { Id = groupId }
            };

            var updated = studentService.Update(id, student);
            if (updated != null)
            {
                Helper.WriteConsole(ConsoleColor.Green,
                    $"Student Updated: Id: {updated.Id}, Name: {updated.Name}, Surname: {updated.Surname}, Age: {updated.Age}, GroupId: {updated.Group.Id}");
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Student not found!");
            }
        }
        public void Delete()
        {
        EnterId:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter Student Id to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Helper.WriteConsole(ConsoleColor.Red, "Invalid Id! Try again.");
                goto EnterId;
            }

            studentService.Delete(id);
            Helper.WriteConsole(ConsoleColor.Green, "Student successfully deleted!");
        }
        public void GetStudentById()
        {
        EnterId:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter Student Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Helper.WriteConsole(ConsoleColor.Red, "Invalid Id! Try again.");
                goto EnterId;
            }

            var student = studentService.GetById(id);
            if (student != null)
            {
                Helper.WriteConsole(ConsoleColor.Green,
                    $"Student Found: Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}, GroupId: {student.Group.Id}");
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Yellow, "Student not found.");
            }
        }
        public void GetAllStudents()
        {
            var students = studentService.GetAll();

            if (students.Count == 0)
            {
                Helper.WriteConsole(ConsoleColor.Yellow, "No students found.");
                return;
            }

            foreach (var s in students)
            {
                Console.WriteLine($"{s.Id} - {s.Name} {s.Surname} - Age: {s.Age} - GroupId: {s.Group.Id}");
            }
        }
        public void GetStudentsByNameOrSurname()
        {
        EnterText:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter name or surname: ");
            string text = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(text))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Input cannot be empty!");
                goto EnterText;
            }

            var students = studentService.GetByNameOrSurname(text);

            if (students.Count == 0)
            {
                Helper.WriteConsole(ConsoleColor.Yellow, "No students found matching your search.");
                return;
            }

            foreach (var s in students)
            {
                Console.WriteLine($"Id: {s.Id} - Name: {s.Name} - Surname: {s.Surname} - Age: {s.Age} - GroupId: {s.Group.Id}");
            }
        }
        public void GetStudentsByGroupId()
        {
        EnterGroupId:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter Group Id: ");
            if (!int.TryParse(Console.ReadLine(), out int groupId) || groupId <= 0)
            {
                Helper.WriteConsole(ConsoleColor.Red, "Invalid Group Id! Try again.");
                goto EnterGroupId;
            }

            var students = studentService.GetAllByGroupId(groupId);

            if (students.Count == 0)
            {
                Helper.WriteConsole(ConsoleColor.Yellow, "No students found in this group.");
                return;
            }

            foreach (var s in students)
            {
                Console.WriteLine($"Id: {s.Id} - Name: {s.Name} - Surname: {s.Surname} - Age: {s.Age} - GroupId: {s.Group.Id}");
            }
        }
        public void GetStudentsByAge()
        {
        EnterAge:
            Helper.WriteConsole(ConsoleColor.Cyan, "Enter Age to search: ");
            if (!int.TryParse(Console.ReadLine(), out int age) || age < 6 || age > 100)
            {
                Helper.WriteConsole(ConsoleColor.Red, "Invalid Age! Must be between 6 and 100.");
                goto EnterAge;
            }

            var students = studentService.GetByAge(age);

            if (students.Count == 0)
            {
                Helper.WriteConsole(ConsoleColor.Yellow, "No students found with that age.");
                return;
            }

            foreach (var student in students)
            {
                Helper.WriteConsole(ConsoleColor.Green,
                    $"Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}, GroupId: {student.Group.Id}");
            }
        }
    }
}