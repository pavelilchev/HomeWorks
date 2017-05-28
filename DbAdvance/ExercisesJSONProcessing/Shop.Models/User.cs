namespace Shop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.SoldProducts = new HashSet<Product>();
            this.BoughtProducts = new HashSet<Product>();
            this.Friends = new HashSet<User>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        [MinLength(3, ErrorMessage = "{0} must be at least {1} characters long!")]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public virtual ICollection<Product> SoldProducts { get; set; }

        public virtual ICollection<Product> BoughtProducts { get; set; }

        public virtual ICollection<User> Friends { get; set; }
    }
}
