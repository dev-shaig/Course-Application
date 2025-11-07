namespace Domain.Models
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        Group Group { get; set; }
    }
}
