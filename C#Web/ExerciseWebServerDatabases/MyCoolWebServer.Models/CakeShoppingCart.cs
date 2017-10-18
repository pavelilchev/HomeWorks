namespace MyCoolWebServer.Models
{
    public class CakeShoppingCart
    {
        public int CakeId { get; set; }

        public Cake Cake { get; set; }

        public int ShopingCartId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
    }
}
