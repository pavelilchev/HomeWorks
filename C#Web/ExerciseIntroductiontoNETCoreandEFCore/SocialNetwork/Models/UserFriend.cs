namespace SocialNetwork.Models
{
    public class UserFriend
    {
        public int UserFirstId { get; set; }

        public User UserFirst { get; set; }

        public int UserSecondId { get; set; }

        public User UserSecond { get; set; }
    }
}
