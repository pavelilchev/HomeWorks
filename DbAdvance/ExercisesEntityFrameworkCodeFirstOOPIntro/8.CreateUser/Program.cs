namespace _8.CreateUser
{
    using System;
    using Models;

    public class Program
    {
        public static void Main()
        {
            var ctx = new UsersContext();
            ctx.Users.Add(new User()
            {
               Username = "Peter",
                Password = "XXa!XO4ND",
                Email = "test@gmail.com",
                RegisteredOn = new DateTime(2008,10,12),
                LastTimeLoggedIn = new DateTime(2016, 10, 12),
                Age = 86,
                IsDeleted = false
            });

            ctx.SaveChanges();
        }
    }
}
