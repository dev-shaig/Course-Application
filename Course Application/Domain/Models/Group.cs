using Domain.Common;

namespace Domain.Models
{
    public class Group : BaseEntity
    {
        public string Teacher { get; set; }
        public int Room { get; set; }

    }
}
