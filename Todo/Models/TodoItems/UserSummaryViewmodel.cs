namespace Todo.Models.TodoItems
{
    public class UserSummaryViewmodel
    {
        public string UserName { get; }
        public string Email { get; }
        public string AvatarUrl { get; }

        public UserSummaryViewmodel(string userName, string email, string avatarUrl)
        {
            UserName = userName;
            Email = email;
            AvatarUrl = avatarUrl;
        }
    }
}