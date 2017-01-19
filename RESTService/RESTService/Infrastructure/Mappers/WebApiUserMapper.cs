using System;
using DAL.Interfacies.DTO;
using RESTService.Models;

namespace RESTService.Infrastructure.Mappers
{
    public static class WebApiUserMapper
    {
        public static UserViewModel ToUserViewModel(this DalUser dalUser)
        {
            if (dalUser == null)
                throw new ArgumentNullException(nameof(dalUser));

            return new UserViewModel
            {
                Id = dalUser.Id,
                Nickname = dalUser.Nickname
            };
        }
    }
}