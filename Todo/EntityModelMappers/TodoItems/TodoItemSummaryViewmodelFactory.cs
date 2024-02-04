using Todo.Data.Entities;
using Todo.Models.TodoItems;

namespace Todo.EntityModelMappers.TodoItems
{
    public static class TodoItemSummaryViewmodelFactory
    {
        public static TodoItemSummaryViewmodel Create(TodoItem ti, string avatarUrl)
         {
            var responsibleParty = UserSummaryViewmodelFactory.Create(ti.ResponsibleParty, avatarUrl);
            return new TodoItemSummaryViewmodel(ti.TodoItemId, ti.Title, ti.IsDone, responsibleParty, ti.Importance, ti.Rank);
        }
    }
}