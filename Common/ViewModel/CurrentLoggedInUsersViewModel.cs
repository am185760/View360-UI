namespace Common.ViewModel
{
    public class CurrentLoggedInUsersViewModel
    {
        public string? UserName { get; set; }

        public DateTime LoggedInAt { get; set; }

        public DateTime LastRequestAt { get; set; }

    }
}
