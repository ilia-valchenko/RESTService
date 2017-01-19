using System.Web.Http;
using DAL.Interfacies.Repository.ModelRepository;
using DAL.Concrete.ModelRepository;
using ORM;

namespace RESTService.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            return Json(userRepository?.GetAll());
        }

        private IUserRepository userRepository = new UserRepository(new TodoListDbContext());
    }
}
