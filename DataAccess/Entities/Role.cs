#nullable disable

using DataAccess.Records.Bases;

namespace DataAccess.Entities
{
    public class Role : Record
    {
        // Way 1: you should put nullable disable on top of the class
        //[Required]
        //public string Name { get; set; }

        // Way 2:
        public string Name { get; set; } = null!;

        public ICollection<User> Users { get; set; } // List
    }
}
