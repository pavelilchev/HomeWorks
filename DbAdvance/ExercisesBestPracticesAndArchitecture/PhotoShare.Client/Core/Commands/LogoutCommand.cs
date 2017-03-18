namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Utilities;

    public class LogoutCommand : Command
    {
        public override string Execute(string[] data)
        {
            if (Engine.User == null)
            {
                throw new InvalidOperationException("You should log in first in order to logout.");
            }

            string result = $"User {Engine.User.Username} successfully logged out!";
            Engine.User = null;

            return result;
        }
    }
}
