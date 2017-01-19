using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository.ModelRepository
{
    public interface IUserRepository : IRepository<DalUser>
    {
        DalUser GetUserByNickname(string nickname);
    }
}
