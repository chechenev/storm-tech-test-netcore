using Microsoft.AspNetCore.Identity;
using Todo.Models.TodoItems;

namespace Todo.EntityModelMappers.TodoItems
{
    public class UserSummaryViewmodelFactory
    {
        public static UserSummaryViewmodel Create(IdentityUser identityUser, string avatarUrl)
        {
            return new UserSummaryViewmodel(identityUser.UserName, identityUser.Email, avatarUrl);
        }
    }
}