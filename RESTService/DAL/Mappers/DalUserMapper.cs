using System;
using DAL.Interfacies.DTO;
using ORM.Models;

namespace DAL.Mappers
{
    public static class DalUserMapper
    {
        public static DalUser ToDalUser(this User ormUser)
        {
            if (ormUser == null)
                throw new ArgumentNullException(nameof(ormUser));

            return new DalUser
            {
                Id = ormUser.Id,
                Nickname = ormUser.Nickname,
                Password = ormUser.Password
            };
        }

        public static User ToOrmUser(this DalUser dalUser)
        {
            if (dalUser == null)
                throw new ArgumentNullException(nameof(dalUser));

            return new User
            {
                Nickname = dalUser.Nickname,
                Password = dalUser.Password
            };
        }
    }
}
