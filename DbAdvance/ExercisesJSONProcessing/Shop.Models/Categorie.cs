namespace Shop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Categorie
    {
        public Categorie()
        {
            this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [StringLength(15, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} characters long!")]
        public string  Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
