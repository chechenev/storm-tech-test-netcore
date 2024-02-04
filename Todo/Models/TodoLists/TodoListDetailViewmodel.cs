using System.Collections.Generic;
using Todo.Models.TodoItems;

namespace Todo.Models.TodoLists
{
    public class TodoListDetailViewmodel
    {
        public int TodoListId { get; }
        public string Title { get; }
        public bool OrderByRank { get; set; }
        public ICollection<TodoItemSummaryViewmodel> Items { get; }
        public TodoItemCreateFields TodoItemCreateFields { get; }

        public TodoListDetailViewmodel(int todoListId, string title, bool orderByRank, ICollection<TodoItemSummaryViewmodel> items, TodoItemCreateFields todoItemCreateFields)
        {
            Items = items;
            TodoListId = todoListId;
            Title = title;
            OrderByRank = orderByRank;
            TodoItemCreateFields = todoItemCreateFields;
        }
    }
}