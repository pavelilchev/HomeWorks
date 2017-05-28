namespace ProductShop.Client.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product()
        {
            this.Categories = new HashSet<Categorie>();
        }

        public int Id { get; set; }

        [MinLength(3, ErrorMessage = "{0} must be at least {1} characters long!")]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int SeilerId { get; set; }

        public int? BuyerId { get; set; }

        public virtual User Seller { get; set; }

        public virtual User Buyer { get; set; }

        public virtual ICollection<Categorie> Categories { get; set; }
    }
}
