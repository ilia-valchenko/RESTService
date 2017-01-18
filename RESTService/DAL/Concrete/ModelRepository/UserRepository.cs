using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository.ModelRepository;
using System.Data.Entity;
using ORM.Models;
using DAL.Mappers;

namespace DAL.Concrete.ModelRepository
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(DalUser entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            User ormUser = entity.ToOrmUser();

            context?.Set<User>().Add(ormUser);
        }

        public void Update(DalUser entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            User ormUser = context?.Set<User>().FirstOrDefault(u => u.Id == entity.Id);

            if(ormUser != null)
            {
                ormUser.Nickname = entity.Nickname;
                ormUser.Password = entity.Password;
            }
        }

        public void Delete(DalUser entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            User ormUser = context?.Set<User>().FirstOrDefault(u => u.Id == entity.Id);

            if (ormUser != null)
                context?.Set<User>().Remove(ormUser);
        }

        public IEnumerable<DalUser> GetAll() => context?.Set<User>().Select(u => u.ToDalUser());

        public DalUser GetById(int id) => context?.Set<User>().FirstOrDefault(u => u.Id == id)?.ToDalUser();

        public DalUser GetUserByNickname(string nickname) => context?.Set<User>().FirstOrDefault(u => u.Nickname == nickname)?.ToDalUser();

        public readonly DbContext context;
    }
}
