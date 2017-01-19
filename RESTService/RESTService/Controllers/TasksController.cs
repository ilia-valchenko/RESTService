﻿using System;
using System.Web.Http;
using DAL.Interfacies.Repository.ModelRepository;
using DAL.Concrete.ModelRepository;
using ORM;
using RESTService.Models;
using DAL.Interfacies.DTO;
using RESTService.Infrastructure.Mappers;

namespace RESTService.Controllers
{
    public class TasksController : ApiController 
    {
        [HttpGet]
        public IHttpActionResult ShowTodoList()
        {
            return Json(taskRepository?.GetAll());
        }

        [HttpPost]
        public IHttpActionResult AddNewItem(CreateTaskViewModel createTaskViewModel)
        {
            DalTask dalTask = createTaskViewModel.ToDalTask();
            dalTask.PublishDate = DateTime.Now;
            // take it from cookies
            dalTask.AuthorId = 1;
            dalTask.AuthorNickname = "Batman";            

            taskRepository?.Create(dalTask);

            return Json(dalTask.ToTaskViewModel());
        }

        private ITaskRepository taskRepository = new TaskRepository(new TodoListDbContext());
    }
}