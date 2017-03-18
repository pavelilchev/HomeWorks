namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Utilities;

    public class ListFriendsCommand : Command
    {
        // PrintFriendsList <username>
        public override string Execute(string[] data)
        {
            if (data == null || data.Length != 1)
            {
                throw new InvalidOperationException($"Command {this.GetType().Name.Replace(Constants.CommandSufix, "")} not valid!");
            }

            string username = data[0];

            using (PhotoShareContext context = new PhotoShareContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);
                if (user == null)
                {
                    throw new ArgumentException($"User {username} not found!");
                }

                if (user.Friends.Count == 0)
                {
                    return "No friends for this user. :(";
                }

                string result = "Friends:" + Environment.NewLine + "-";
                result += string.Join(Environment.NewLine + "-", user.Friends.Select(u=>u.Username));

                return result;
            }
        }
    }
}
