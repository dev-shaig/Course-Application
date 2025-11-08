using Domain.Common;

namespace Domain.Models
{
    public class Student : BaseEntity
    {
        public string Surname { get; set; }
        public int Age { get; set; }
        Group Group { get; set; }
    }
}
