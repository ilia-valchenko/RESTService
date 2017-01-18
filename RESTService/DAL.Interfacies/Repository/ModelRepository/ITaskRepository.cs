using System.Collections.Generic;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository.ModelRepository
{
    public interface ITaskRepository : IRepository<DalTask>
    {
        IEnumerable<DalTask> GetTasksByAuthorNickname(string nickname);
    }
}
