using System;
using DAL.Interfacies.DTO;
using ORM.Models;

namespace DAL.Mappers
{
    public static class DalTaskMappers
    {
        public static DalTask ToDalTask(this Task ormTask)
        {
            if (ormTask == null)
                throw new ArgumentNullException(nameof(ormTask));

            return new DalTask
            {
                Id = ormTask.Id,
                Title = ormTask.Title,
                Description = ormTask.Description,
                PublishDate = ormTask.PublishDate,
                AuthorId = ormTask.Author.Id,
                AuthorNickname = ormTask.Author.Nickname
            };
        }

        public static Task ToOrmTask(this DalTask dalTask)
        {
            if (dalTask == null)
                throw new ArgumentNullException(nameof(dalTask));

            return new Task
            {
                Title = dalTask.Title,
                Description = dalTask.Description,
                PublishDate = dalTask.PublishDate
            };
        }
    }
}
