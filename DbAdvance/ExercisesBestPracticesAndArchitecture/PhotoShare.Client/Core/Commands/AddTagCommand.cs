namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Models;

    using Utilities;

    public class AddTagCommand : Command
    {
        // AddTag <tag>
        public override string Execute(string[] data)
        {
            if (data == null || data.Length != 1)
            {
                throw new InvalidOperationException($"Command {this.GetType().Name.Replace(Constants.CommandSufix, "")} not valid!");
            }

            string tag = data[0].ValidateOrTransform();

            using (PhotoShareContext context = new PhotoShareContext())
            {
                if (Engine.User == null)
                {
                    throw new InvalidOperationException("Invalid credentials!");
                }

                if (context.Tags.Any(t => t.Name == tag))
                {
                    throw new ArgumentException($"Tag {tag} exists!");
                }

                context.Tags.Add(new Tag
                {
                    Name = tag
                });

                context.SaveChanges();
            }

            return $"Tag {tag} was added successfully!";
        }
    }
}
