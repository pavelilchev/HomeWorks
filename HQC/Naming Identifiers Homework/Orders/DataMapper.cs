namespace Orders
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Models;

    public class DataMapper
    {
        private const string DefaultCategoriesPath = "../../Data/categories.txt";
        private const string DefaultProductsPath = "../../Data/products.txt";
        private const string DefaultOrdersPath = "../../Data/orders.txt";

        private readonly string categoriesFileName;
        private readonly string productsFileName;
        private readonly string ordersFileName;

        public DataMapper(string categoriesFileName, string productsFileName, string ordersFileName)
        {
            this.categoriesFileName = categoriesFileName;
            this.productsFileName = productsFileName;
            this.ordersFileName = ordersFileName;
        }

        public DataMapper()
            : this(DefaultCategoriesPath, DefaultProductsPath, DefaultOrdersPath)
        {
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var categories = this.ReadFileLines(this.categoriesFileName, true);
            return categories
                .Select(c => c.Split(','))
                .Select(c => new Category
                {
                    Id = int.Parse(c[0]),
                    Name = c[1],
                    Description = c[2]
                });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var prod = this.ReadFileLines(this.productsFileName, true);
            var products = prod
                .Select(p => p.Split(','))
                .Select(p => new Product
                {
                    Id = int.Parse(p[0]),
                    Name = p[1],
                    CatId = int.Parse(p[2]),
                    UnitPrice = decimal.Parse(p[3]),
                    UnitsInStock = int.Parse(p[4]),
                });
            return products;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var ord = this.ReadFileLines(this.ordersFileName, true);
            return ord
                .Select(p => p.Split(','))
                .Select(p => new Order
                {
                    Id = int.Parse(p[0]),
                    ProductId = int.Parse(p[1]),
                    Quant = int.Parse(p[2]),
                    Discount = decimal.Parse(p[3]),
                });
        }

        private List<string> ReadFileLines(string filename, bool hasHeader)
        {
            var allLines = new List<string>();
            using (var reader = new StreamReader(filename))
            {
                string currentLine;
                if (hasHeader)
                {
                    reader.ReadLine();
                }

                while ((currentLine = reader.ReadLine()) != null)
                {
                    allLines.Add(currentLine);
                }
            }

            return allLines;
        }
    }
}
