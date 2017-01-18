using System.Data.Entity;
using ORM.Models;

namespace ORM
{
    public class TodoListDbContext : DbContext
    {
        public TodoListDbContext() : base("TodoListDBContextConnectionString")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
    }
}
