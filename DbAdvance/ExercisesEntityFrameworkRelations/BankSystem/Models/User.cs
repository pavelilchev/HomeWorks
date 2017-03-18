namespace BankSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Attributes;

    public class User
    {
        public User()
        {
            this.Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }

        [Username(ErrorMessage = "Incorrect username")]
        public string Username { get; set; }

        [CustomPassword(ErrorMessage = "Incorrect password")]
        public string Password { get; set; }

        [EmailAddress(ErrorMessage = "Incorrect email")]
        public string Email { get; set; }

        public virtual  ICollection<Account> Accounts { get; set; }
    }
}
