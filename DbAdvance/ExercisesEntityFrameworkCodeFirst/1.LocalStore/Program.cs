namespace _1.LocalStore
{
    using Models;

    public class Program
    {
        public static void Main()
        {
            var ctx = new StoreContext();
           var product1 = new Product()
           {
               Name = "Bonbon",
               Description = "Just a Magic",
               DistributorName = "Unufri",
               Price = 1.75m
           };

            var product2 = new Product()
            {
                Name = "Jele",
                Description = "Lepne zdravo",
                DistributorName = "Haralambi",
                Price = 0.99m
            };

            var product3 = new Product()
            {
                Name = "Piron",
                Description = "Chukai go zdravo",
                DistributorName = "Jelqzko",
                Price = 0.05m
            };

            ctx.Products.Add(product1);
            ctx.Products.Add(product2);
            ctx.Products.Add(product3);

            ctx.SaveChanges();
        }
    }
}
