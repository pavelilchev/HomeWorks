namespace ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class ShoppingCenter
    {
        private readonly Dictionary<string, Bag<Product>> productsByProducer;
        private readonly Dictionary<string, Bag<Product>> productsByName;
        private readonly Dictionary<Tuple<string, string>, Bag<Product>> productsByNameAndProducer;
        private readonly OrderedMultiDictionary<decimal, Product> productsByPrice;

        public ShoppingCenter()
        {
            this.productsByProducer = new Dictionary<string, Bag<Product>>();
            this.productsByName = new Dictionary<string, Bag<Product>>();
            this.productsByNameAndProducer = new Dictionary<Tuple<string, string>, Bag<Product>>();
            this.productsByPrice = new OrderedMultiDictionary<decimal, Product>(true);
        }

        public string ProcessCommand(string commandLine)
        {
            int spaceIndex = commandLine.IndexOf(' ');
            string commandName = commandLine.Substring(0, spaceIndex);
            string[] args = commandLine.Substring(spaceIndex + 1).Split(';');
            string output = String.Empty;
            switch (commandName)
            {
                case "AddProduct":
                    output = this.AddProduct(args[0], decimal.Parse(args[1]), args[2]);
                    break;
                case "DeleteProducts":
                    if (args.Length == 1)
                    {
                        output = this.DeleteProducts(args[0]);
                    }
                    else
                    {
                        output = this.DeleteProducts(args[0], args[1]);
                    }
                    break;
                case "FindProductsByName":
                    output = this.FindProductsByName(args[0]);
                    break;
                case "FindProductsByProducer":
                    output = this.FindProductsByProducer(args[0]);
                    break;
                case "FindProductsByPriceRange":
                    output = this.FindProductsByPriceRange(decimal.Parse(args[0]), decimal.Parse(args[1]));
                    break;
                default: throw new InvalidOperationException("Invalid command.");
            }

            return output;
        }

        private string AddProduct(string name, decimal price, string producer)
        {
            var product = new Product(name, price, producer);
            if (!this.productsByProducer.ContainsKey(producer))
            {
                this.productsByProducer.Add(producer, new Bag<Product>());
            }

            this.productsByProducer[producer].Add(product);
            if (!this.productsByName.ContainsKey(name))
            {
                this.productsByName.Add(name, new Bag<Product>());
            }

            this.productsByName[name].Add(product);
            var tuple = new Tuple<string, string>(name, producer);
            if (!this.productsByNameAndProducer.ContainsKey(tuple))
            {
                this.productsByNameAndProducer.Add(tuple, new Bag<Product>());
            }

            this.productsByNameAndProducer[tuple].Add(product);

            this.productsByPrice.Add(price, product);

            return "Product added";
        }

        private string DeleteProducts(string producer)
        {
            if (!this.productsByProducer.ContainsKey(producer))
            {
                return "No products found";
            }

            var deleted = this.productsByProducer[producer];
            int count = deleted.Count;
            foreach (var product in deleted)
            {
                this.productsByName[product.Name].Remove(product);
                this.productsByNameAndProducer[new Tuple<string, string>(product.Name, product.Producer)].Remove(product);
                this.productsByPrice[product.Price].Remove(product);
            }

            this.productsByProducer.Remove(producer);

            return count + " products deleted";
        }

        private string DeleteProducts(string name, string producer)
        {
            var tuple = new Tuple<string, string>(name, producer);
            if (!this.productsByNameAndProducer.ContainsKey(tuple))
            {
                return "No products found";
            }

            var deleted = this.productsByNameAndProducer[tuple];
            int count = deleted.Count;
            foreach (var product in deleted)
            {
                this.productsByName[name].Remove(product);
                this.productsByProducer[producer].Remove(product);
                this.productsByPrice[product.Price].Remove(product);
            }

            this.productsByNameAndProducer.Remove(tuple);

            return count + " products deleted";
        }

        private string FindProductsByName(string name)
        {
            if (!this.productsByName.ContainsKey(name) || this.productsByName[name].Count == 0)
            {
                return "No products found";
            }

            var products = this.productsByName[name].OrderBy(p => p);

            return string.Join(Environment.NewLine, products);
        }

        private string FindProductsByProducer(string producer)
        {
            if (!this.productsByProducer.ContainsKey(producer) || this.productsByProducer[producer].Count == 0)
            {
                return "No products found";
            }

            var products = this.productsByProducer[producer].OrderBy(p => p);

            return string.Join(Environment.NewLine, products);
        }

        private string FindProductsByPriceRange(decimal from, decimal to)
        {
            var range = this.productsByPrice.Range(from, true, to, true).Values.OrderBy(p => p);

            var result = new StringBuilder();
            foreach (var product in range)
            {
                result.AppendLine(product.ToString());
            }

            if (string.IsNullOrEmpty(result.ToString()))
            {
                return "No products found";
            }

            return result.ToString().Trim();
        }
    }
}