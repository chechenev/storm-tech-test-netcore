﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoItems;
using Todo.EntityModelMappers.TodoLists;
using Todo.Models.TodoItems;
using Todo.Models.TodoLists;
using Todo.Services;

namespace Todo.Controllers
{
    [Authorize]
    public class TodoListController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IUserStore<IdentityUser> userStore;

        public TodoListController(ApplicationDbContext dbContext, IUserStore<IdentityUser> userStore)
        {
            this.dbContext = dbContext;
            this.userStore = userStore;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.Id();
            var todoLists = dbContext.RelevantTodoLists(userId);
            var viewmodel = TodoListIndexViewmodelFactory.Create(todoLists);
            var currentUser = await userStore.FindByIdAsync(userId, CancellationToken.None);

            var (name, avatarUrl) = await GravatarService.GetProfileInfo(currentUser.Email);

            viewmodel.UserName = name;
            viewmodel.Email = currentUser.Email;
            viewmodel.AvatarUrl = avatarUrl;

            return View(viewmodel);
        }

        public IActionResult Detail(int todoListId, bool orderByRank = false)
        {
            var todoList = dbContext.SingleTodoList(todoListId);
            var fields = TodoItemCreateFieldsFactory.Create(todoList, User.Id());
            var viewmodel = TodoListDetailViewmodelFactory.Create(todoList, fields, orderByRank);
            return View(viewmodel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new TodoListFields());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TodoListFields fields)
        {
            if (!ModelState.IsValid) { return View(fields); }

            var currentUser = await userStore.FindByIdAsync(User.Id(), CancellationToken.None);

            var todoList = new TodoList(currentUser, fields.Title);

            await dbContext.AddAsync(todoList);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Create", "TodoItem", new {todoList.TodoListId});
        }
    }
}