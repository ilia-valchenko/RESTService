using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DAL.Interfacies.DTO;
using ORM.Models;
using DAL.Interfacies.Repository.ModelRepository;
using DAL.Mappers;
using DAL.Interfacies.Repository;

namespace DAL.Concrete.ModelRepository
{
    public class TaskRepository : ITaskRepository
    {
        public TaskRepository(DbContext context)
        {
            this.context = context;
            this.unitOfWork = new UnitOfWork(context);
        }

        public void Create(DalTask entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Task ormTask = entity.ToOrmTask();

            context?.Set<User>().FirstOrDefault(u => u.Id == entity.AuthorId)?.Tasks.Add(ormTask);

            unitOfWork.Commit();
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

            unitOfWork.Commit();
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

            unitOfWork.Commit();
        }

        public IEnumerable<DalTask> GetAll() => context?.Set<Task>().ToList().Select(t => t.ToDalTask());

        public DalTask GetById(int id) => context?.Set<Task>().FirstOrDefault(t => t.Id == id).ToDalTask();

        public IEnumerable<DalTask> GetTasksByAuthorNickname(string nickname) => context?.Set<Task>().Where(t => t.Author.Nickname == nickname).Select(t => t.ToDalTask());

        private readonly DbContext context;
        private readonly IUnitOfWork unitOfWork;
    }
}
