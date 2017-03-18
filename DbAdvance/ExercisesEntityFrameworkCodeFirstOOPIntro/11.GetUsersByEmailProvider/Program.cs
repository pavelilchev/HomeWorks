namespace _11.GetUsersByEmailProvider
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var ctx = new UsersContext();
            Console.Write("Enter provider: ");
            string provider = Console.ReadLine();
           var users = ctx.Users.Where(u => u.Email.Contains(provider));
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Username} {user.Email}");
            }
        }
    }
}
