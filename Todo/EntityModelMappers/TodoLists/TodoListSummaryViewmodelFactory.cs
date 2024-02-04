using System.Linq;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoItems;
using Todo.Models.TodoLists;

namespace Todo.EntityModelMappers.TodoLists
{
    public static class TodoListSummaryViewmodelFactory
    {
        public static TodoListSummaryViewmodel Create(TodoList todoList, string avatarUrl)
        {
            var numberOfNotDoneItems = todoList.Items.Count(ti => !ti.IsDone);
            var owner = UserSummaryViewmodelFactory.Create(todoList.Owner, avatarUrl);
            return new TodoListSummaryViewmodel(todoList.TodoListId, todoList.Title, numberOfNotDoneItems, owner);
        }
    }
}