namespace Problem3CollectionOfProducts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class ProductsData
    {
        private readonly Dictionary<int, Product> productsById;
        private readonly OrderedMultiDictionary<decimal, Product> productsByPrice;
        private readonly Dictionary<string, SortedSet<Product>> productsByTitle;
        private readonly Dictionary<Tuple<string, decimal>, SortedSet<Product>> productsByTitleAndPrice;
        private readonly Dictionary<string, OrderedMultiDictionary<decimal, Product>> productsByTitleInPriceRange;
        private readonly Dictionary<Tuple<string, decimal>, SortedSet<Product>> productsBySupplierAndPrice;
        private readonly Dictionary<string, OrderedMultiDictionary<decimal, Product>> productsBySupplierInPriceRange;

        public ProductsData()
        {
            this.productsById = new Dictionary<int, Product>();
            this.productsByPrice = new OrderedMultiDictionary<decimal, Product>(true);
            this.productsByTitle = new Dictionary<string, SortedSet<Product>>();
            this.productsByTitleAndPrice = new Dictionary<Tuple<string, decimal>, SortedSet<Product>>();
            this.productsByTitleInPriceRange = new Dictionary<string, OrderedMultiDictionary<decimal, Product>>();
            this.productsBySupplierAndPrice = new Dictionary<Tuple<string, decimal>, SortedSet<Product>>();
            this.productsBySupplierInPriceRange = new Dictionary<string, OrderedMultiDictionary<decimal, Product>>();
        }

        public void Add(int id, string title, string supplier, decimal price)
        {
            var product = new Product(id, title, supplier, price);
            this.productsById.Add(id, product);
            this.productsByPrice.Add(price, product);

            if (!this.productsByTitle.ContainsKey(title))
            {
                this.productsByTitle.Add(title, new SortedSet<Product>());
            }

            this.productsByTitle[title].Add(product);
            var titlePrice = new Tuple<string, decimal>(title, price);
            if (!this.productsByTitleAndPrice.ContainsKey(titlePrice))
            {
                this.productsByTitleAndPrice.Add(titlePrice, new SortedSet<Product>());
            }

            this.productsByTitleAndPrice[titlePrice].Add(product);
            if (!this.productsByTitleInPriceRange.ContainsKey(title))
            {
                this.productsByTitleInPriceRange.Add(title, new OrderedMultiDictionary<decimal, Product>(true));
            }

            this.productsByTitleInPriceRange[title].Add(price, product);
            var supplierPrice = new Tuple<string, decimal>(supplier, price);
            if (!this.productsBySupplierAndPrice.ContainsKey(supplierPrice))
            {
                this.productsBySupplierAndPrice.Add(supplierPrice, new SortedSet<Product>());
            }

            this.productsBySupplierAndPrice[supplierPrice].Add(product);
            if (!this.productsBySupplierInPriceRange.ContainsKey(supplier))
            {
                this.productsBySupplierInPriceRange.Add(supplier, new OrderedMultiDictionary<decimal, Product>(true));
            }

            this.productsBySupplierInPriceRange[supplier].Add(price, product);
        }

        public bool Remove(int id)
        {
            return false;
        }

        public IEnumerable<Product> FindProductsInPriceRange(decimal from, decimal to)
        {
            var result = this.productsByPrice.Range(from, true, to, true).Values;

            return result.OrderBy(x => x.Id);
        }

        public IEnumerable<Product> FindProductsByTitle(string title)
        {
            if (this.productsByTitle.ContainsKey(title))
            {
                var result = this.productsByTitle[title];
                return result;
            }

            return Enumerable.Empty<Product>();
        }

        public IEnumerable<Product> FindProductsByTitleAndPrice(string title, decimal price)
        {
            var titlePrice = new Tuple<string, decimal>(title, price);
            if (this.productsByTitleAndPrice.ContainsKey(titlePrice))
            {
                var result = this.productsByTitleAndPrice[titlePrice];
                return result;
            }

            return Enumerable.Empty<Product>();
        }

        public IEnumerable<Product> FindProductsByTitleAndPriceRange(string title, decimal from, decimal to)
        {
            if (!this.productsByTitleInPriceRange.ContainsKey(title))
            {
                return Enumerable.Empty<Product>();
            }

            var byTitle = this.productsByTitleInPriceRange[title];
            var range = byTitle.Range(from, true, to, true).Values;

            return range.OrderBy(x => x.Id);
        }

        public IEnumerable<Product> FindProductsBySupplierAndPrice(string supplier, decimal price)
        {
            var supplierPrice = new Tuple<string, decimal>(supplier, price);
            if (this.productsBySupplierAndPrice.ContainsKey(supplierPrice))
            {
                var result = this.productsBySupplierAndPrice[supplierPrice];
                return result;
            }

            return Enumerable.Empty<Product>();
        }

        public IEnumerable<Product> FindProductsBySupplierAndPriceRange(string supplier, decimal from, decimal to)
        {
            if (!this.productsBySupplierInPriceRange.ContainsKey(supplier))
            {
                return Enumerable.Empty<Product>();
            }

            var bySupplier = this.productsBySupplierInPriceRange[supplier];
            var range = bySupplier.Range(from, true, to, true).Values;

            return range.OrderBy(x => x.Id);
        }
    }
}
