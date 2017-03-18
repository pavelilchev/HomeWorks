namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Utilities;

    public class DeleteUser : Command
    {
        // DeleteUser <username>
        public override string Execute(string[] data)
        {
            if (data == null || data.Length != 1)
            {
                throw new InvalidOperationException($"Command {this.GetType().Name.Replace(Constants.CommandSufix, "")} not valid!");
            }

            string username = data[1];
            using (PhotoShareContext context = new PhotoShareContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);
                if (user == null)
                {
                    throw new ArgumentException($"User {username} not found!");
                }

                if (Engine.User == null || Engine.User.Username != user.Username)
                {
                    throw new InvalidOperationException("Invalid credentials!");
                }

                if (user.IsDeleted ?? false)
                {
                    return $"User {username} is already deleted!";
                }

                user.IsDeleted = true;
                context.SaveChanges();

                return $"User {username} was deleted successfully!";
            }
        }
    }
}
