namespace BankSystem
{
    using System;
    using System.Data.Entity.Validation;
    using System.Linq;
    using Data;
    using Models;

    public class Startup
    {
        private static User CurrentUser = null;
        private static BankSystemContext ctx = new BankSystemContext();
        public static void Main()
        {
            var command = Console.ReadLine();
            while (command != "End")
            {
                string result = string.Empty;
                var commandArgs = command.Split();
                switch (commandArgs[0])
                {
                    case "Register":
                        result = RegisterUser(commandArgs);
                        break;
                    case "Logout":
                        break;
                    case "Login":
                        break;
                    case "Add":
                        break;
                    case "Deposit":
                        break;
                    case "Withdraw":
                        break;
                    case "AddInterest":
                        break;
                    case "DeductFee":
                        break;
                    case "ListAccounts":
                        break;
                    default:
                        result = "Unknown command";
                        break;
                }


                Console.WriteLine(result);
                command = Console.ReadLine();
            }
        }

        private static string RegisterUser(string[] commandArgs)
        {
            var username = commandArgs[1];
            var pass = commandArgs[2];
            var mail = commandArgs[3];
            string result = string.Empty;
            var user = new User()
            {
                Username = username,
                Password = pass,
                Email = mail
            };

            ctx.Users.Add(user);

            try
            {
                ctx.SaveChanges();
                result = $"{username} was registered in the system";
            }
            catch (DbEntityValidationException ex)
            {
                ctx.Users.Remove(user);
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                result = string.Join(", ", errorMessages);
            }

            return result;
        }
    }
}
