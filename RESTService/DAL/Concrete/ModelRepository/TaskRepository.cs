using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DAL.Interfacies.DTO;
using ORM.Models;
using DAL.Interfacies.Repository.ModelRepository;
using DAL.Mappers;

namespace DAL.Concrete.ModelRepository
{
    public class TaskRepository : ITaskRepository
    {
        public TaskRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(DalTask entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Task ormTask = entity.ToOrmTask();

            context?.Set<Task>().Add(ormTask);
        }

        public void Update(DalTask entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Task ormTask = context?.Set<Task>().FirstOrDefault(t => t.Id == entity.Id);

            if(ormTask != null)
            {
                ormTask.Title = entity.Title;
                ormTask.Description = entity.Description;
                ormTask.PublishDate = entity.PublishDate;
            }
        }

        public void Delete(DalTask entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Task ormTask = context?.Set<Task>().FirstOrDefault(t => t.Id == entity.Id);

            if(ormTask == null)
            {
                context?.Set<Task>().Remove(ormTask);
            }
        }

        public IEnumerable<DalTask> GetAll() => context?.Set<Task>().Select(t => t.ToDalTask());

        public DalTask GetById(int id) => context?.Set<Task>().FirstOrDefault(t => t.Id == id).ToDalTask();

        public IEnumerable<DalTask> GetTasksByAuthorNickname(string nickname) => context?.Set<User>().FirstOrDefault(u => u.Nickname == nickname)?.Tasks?.Select(t => t.ToDalTask());

        private readonly DbContext context;
    }
}
