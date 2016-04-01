namespace Problem3CollectionOfProducts
{
    using System;
    using System.Diagnostics;

    public class CollectionOfProductsMain
    {
        public static void Main()
        {
            var data = new ProductsData();

            for (int i = 0; i < 10000; i++)
            {
                int id = i;
                string title = "title" + i % 10;
                string supplier = "supplier" + i % 10;
                decimal price = i + 0.25m;
                data.Add(id, title,supplier,price);
            }

            var sw = new Stopwatch();

            sw.Start();
            var productsInRange = data.FindProductsInPriceRange(10, 20);
            Console.WriteLine(string.Join(Environment.NewLine, productsInRange));
            Console.WriteLine(sw.Elapsed);

            sw.Restart();
            Console.WriteLine(new string('*', 20));
            var productsByTitleInRange = data.FindProductsByTitleAndPriceRange("title1", 1, 100);
            Console.WriteLine(string.Join(Environment.NewLine, productsByTitleInRange));
            Console.WriteLine(sw.Elapsed);

            sw.Restart();
            Console.WriteLine(new string('*', 20));
            var productsBySupplierInRange = data.FindProductsBySupplierAndPriceRange("supplier2", 35, 66);
            Console.WriteLine(string.Join(Environment.NewLine, productsBySupplierInRange));
            Console.WriteLine(sw.Elapsed);
        }
    }
}
