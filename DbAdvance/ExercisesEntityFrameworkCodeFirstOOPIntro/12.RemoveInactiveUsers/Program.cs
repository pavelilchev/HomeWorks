namespace _12.RemoveInactiveUsers
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var ctx = new UsersContext();
            Console.Write("Enter date: ");
            var dateInfo = Console.ReadLine();
            var date = DateTime.Parse(dateInfo);

            var users = ctx.Users.Where(u => u.LastTimeLoggedIn < date).ToList();
            int count = users.Count;
            foreach (var user in users)
            {
                user.IsDeleted = true;
            }

            foreach (var user in users)
            {
                ctx.Users.Remove(user);
            }

            ctx.SaveChanges();

            if (count == 0)
            {
                Console.WriteLine("No users have been deleted");
            }
            else
            {
                Console.WriteLine($"{users.Count} user has been deleted");
            }
        }
    }
}
