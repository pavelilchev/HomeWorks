namespace MyCoolWebServer.Models
{
    using System.Collections.Generic;

    public class ShoppingCart
    {
        public const string SessionKey = "%^Current_Shopping_Cart^%";

        public int Id { get; set; }

        public List<CakeShoppingCart> Orders { get; private set; } = new List<CakeShoppingCart>();
    }
}
