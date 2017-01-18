using System.Data.Entity;
using ORM.Models;
using System.Web.Helpers;

namespace ORM
{
    public class DbInitializer : CreateDatabaseIfNotExists<TodoListDbContext>
    {
        protected override void Seed(TodoListDbContext context)
        {
            User ilia = new User
            {
                Nickname = "Ilia",
                Password = Crypto.HashPassword("qwerty")
            };

            User artsiom = new User
            {
                Nickname = "Artsiom",
                Password = Crypto.HashPassword("qwerty")
            };

            context.Users.Add(ilia);
            context.Users.Add(artsiom);
            context.SaveChanges();
        }
    }
}
