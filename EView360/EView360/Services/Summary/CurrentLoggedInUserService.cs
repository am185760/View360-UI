using Common.ViewModel;
namespace EView360.Services.Summary
{
    public static class CurrentLoggedInUserService
    {
        private static List<CurrentLoggedInUsersViewModel>? activeUsers = new();
        
        public static void RemoveActiveUser(string userName)
        {
            activeUsers?.Remove(activeUsers.Where(x=>x.UserName.Equals(userName)).FirstOrDefault());
        }

        public static void AddActiveUser(CurrentLoggedInUsersViewModel user)
        {
            activeUsers?.Add(user);
        }

        public static List<CurrentLoggedInUsersViewModel>? GetActiveUsers()
        {
            return activeUsers;
        }
    }
}
