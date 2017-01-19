using System;
using DAL.Interfacies.DTO;
using RESTService.Models;

namespace RESTService.Infrastructure.Mappers
{
    public static class WebApiTaskMapper
    {
        public static TaskViewModel ToTaskViewModel(this DalTask dalTask)
        {
            if (dalTask == null)
                throw new ArgumentNullException(nameof(dalTask));

            return new TaskViewModel
            {
                Id = dalTask.Id,
                Title = dalTask.Title,
                Description = dalTask.Description,
                PublishDate = dalTask.PublishDate.ToShortDateString() + $" {dalTask.PublishDate.Hour} : {dalTask.PublishDate.Minute}",
                AuthorId = dalTask.AuthorId,
                AuthorNickname = dalTask.AuthorNickname
            };
        }

        public static DalTask ToDalTask(this CreateTaskViewModel createTaskViewModel)
        {
            if (createTaskViewModel == null)
                throw new ArgumentNullException(nameof(createTaskViewModel));

            return new DalTask
            {
                Title = createTaskViewModel.Title,
                Description = createTaskViewModel.Description
            };
        }
    }
}