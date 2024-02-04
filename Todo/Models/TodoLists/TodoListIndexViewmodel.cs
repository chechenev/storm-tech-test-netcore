using System.Collections.Generic;

namespace Todo.Models.TodoLists
{
    public class TodoListIndexViewmodel
    {
        public string UserName { get; set; }    
        public string Email { get; set; }    
        public string AvatarUrl { get; set; }    
        public ICollection<TodoListSummaryViewmodel> Lists { get; }

        public TodoListIndexViewmodel(ICollection<TodoListSummaryViewmodel> lists)
        {
            Lists = lists;
        }
    }
}