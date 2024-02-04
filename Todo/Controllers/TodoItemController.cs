using System.Threading.Tasks;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoItems;
using Todo.Models.TodoItems;
using Todo.Services;

namespace Todo.Controllers
{
    [Authorize]
    public class TodoItemController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public TodoItemController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Create(int todoListId)
        {
            var todoList = _dbContext.SingleTodoList(todoListId);
            var fields = TodoItemCreateFieldsFactory.Create(todoList, User.Id());
            return View(fields);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TodoItemCreateFields fields)
        {
            if (!ModelState.IsValid) { return View(fields); }

            var item = new TodoItem(fields.TodoListId, fields.ResponsiblePartyId, fields.Title, fields.Importance);

            await _dbContext.AddAsync(item);
            await _dbContext.SaveChangesAsync();

            return RedirectToListDetail(fields.TodoListId);
        }

        [HttpGet]
        public IActionResult Edit(int todoItemId)
        {
            var todoItem = _dbContext.SingleTodoItem(todoItemId);
            var fields = TodoItemEditFieldsFactory.Create(todoItem);
            return View(fields);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TodoItemEditFields fields)
        {
            if (!ModelState.IsValid) { return View(fields); }

            var todoItem = _dbContext.SingleTodoItem(fields.TodoItemId);

            TodoItemEditFieldsFactory.Update(fields, todoItem);

            _dbContext.Update(todoItem);
            await _dbContext.SaveChangesAsync();

            return RedirectToListDetail(todoItem.TodoListId);
        }

        private RedirectToActionResult RedirectToListDetail(int fieldsTodoListId)
        {
            return RedirectToAction("Detail", "TodoList", new { todoListId = fieldsTodoListId });
        }
    }

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemApiController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public TodoItemApiController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST: api/TodoItemApi
        [HttpPost]
        public async Task<IActionResult> CreateTodoItem([FromBody] TodoItemCreateFields fields)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = new TodoItem(fields.TodoListId, fields.ResponsiblePartyId, fields.Title, fields.Importance);

            await _dbContext.AddAsync(item);
            await _dbContext.SaveChangesAsync();

           return Ok(item);

        }

     
    }
}
