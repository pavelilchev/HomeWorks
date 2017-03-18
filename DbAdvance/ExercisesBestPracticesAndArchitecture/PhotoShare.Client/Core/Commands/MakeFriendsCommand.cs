namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Utilities;

    public class MakeFriendsCommand : Command
    {
        // MakeFriends <username1> <username2>
        public override string Execute(string[] data)
        {
            if (data == null || data.Length != 2)
            {
                throw new InvalidOperationException($"Command {this.GetType().Name.Replace(Constants.CommandSufix, "")} not valid!");
            }

            string username1 = data[0];
            string username2 = data[1];

            using (var ctx = new PhotoShareContext())
            {
                var user1 = ctx.Users.FirstOrDefault(u => u.Username == username1);

                var user2 = ctx.Users.FirstOrDefault(u => u.Username == username2);

                if (user1 == null || user2 == null)
                {
                    var misingUser = user1 == null ? username1 : username2;
                    throw new ArgumentException($"{misingUser} not found!");
                }

                if (Engine.User == null || Engine.User.Username != user1.Username)
                {
                    throw new InvalidOperationException("Invalid credentials!");
                }

                if (user1.Friends.Contains(user2))
                {
                    throw new InvalidOperationException($"{username2} is already a friend to {username1}");
                }

                user1.Friends.Add(user2);
                ctx.SaveChanges();
            }

            return $"Friend {username2} added to {username1}";
        }
    }
}
