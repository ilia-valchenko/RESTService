﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using RESTService.App_Code;
using System.Web.OData;

namespace RESTService.Controllers
{
    public class WebApiController : ApiController /*ODataController*/
    {
        List<Task> todoList = new List<Task>() {
            new Task("Master-slave replication", "Complete master-slave replication task which. Send the link to github project to Alexander.", "Ilia Valchenko"),
            new Task("Codewars", "Get 4 kyu on codewars.com", "Ilia Valchenko")
        };

        [HttpGet]
        //[EnableQuery]
        public IHttpActionResult ShowTodoList()
        {
            return Json(todoList);
        }

        [HttpPost]
        public IHttpActionResult AddNewItem(Task task)
        {
            Task newTask = new Task(task.Title, task.Description, task.Author);
            todoList.Add(newTask);
            return Json(newTask);
        }
    }
}