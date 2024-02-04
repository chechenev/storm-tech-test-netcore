using System.Linq;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoItems;
using Todo.Models.TodoLists;

namespace Todo.EntityModelMappers.TodoLists
{
    public static class TodoListDetailViewmodelFactory
    {
        public static TodoListDetailViewmodel Create(TodoList todoList, bool orderByRank = false, string avatarUrl = "")
        {
            var orderedItems = orderByRank ? todoList.Items.OrderBy(t => t.Rank) : todoList.Items.OrderBy(t => t.Importance);

            var items = orderedItems.Select(ti => TodoItemSummaryViewmodelFactory.Create(ti, avatarUrl)).ToList();
            
            return new TodoListDetailViewmodel(todoList.TodoListId, todoList.Title, orderByRank, items);
        }
    }
}