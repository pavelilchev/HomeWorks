namespace MyCoolWebServer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Cake
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public List<CakeShoppingCart> Carts { get; private set; } = new List<CakeShoppingCart>();
    }
}
