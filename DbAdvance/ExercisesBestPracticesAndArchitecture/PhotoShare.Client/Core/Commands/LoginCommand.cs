namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Utilities;

    public class LoginCommand : Command
    {
        public override string Execute(string[] data)
        {
            if (data == null || data.Length != 2)
            {
                throw new InvalidOperationException($"Command {this.GetType().Name.Replace(Constants.CommandSufix, "")} not valid!");
            }

            if (Engine.User != null)
            {
                throw new ArgumentException("You should logout first!");
            }

            string username = data[0];
            string password = data[1];

            using (var ctx = new PhotoShareContext())
            {
                var user = ctx.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                if (user == null)
                {
                    throw new ArgumentException("Invalid username or password!");
                }

                Engine.User = user;
                return $"User {username} successfully logged in!";
            }
        }
    }
}
