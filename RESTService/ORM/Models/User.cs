using System.Collections.Generic;

namespace ORM.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public ICollection<Task> Tasks { get; set; }

        public User()
        {
            Tasks = new HashSet<Task>();
        }
    }
}
