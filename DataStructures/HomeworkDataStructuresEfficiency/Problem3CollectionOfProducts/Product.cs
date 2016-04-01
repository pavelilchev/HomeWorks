namespace Problem3CollectionOfProducts
{
    using System;

    public class Product : IComparable<Product>
    {
        public Product(int id, string title, string supplier, decimal price)
        {
            this.Id = id;
            this.Title = title;
            this.Supplier = supplier;
            this.Price = price;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Supplier { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Product other)
        {
            return this.Id.CompareTo(other.Id);
        }

        public override string ToString()
        {
            return string.Format("Product: {{id:{0}, title:{1}, supplier:{2}, price:{3:0.00}}}", this.Id, this.Title, this.Supplier, this.Price);
        }
    }
}
