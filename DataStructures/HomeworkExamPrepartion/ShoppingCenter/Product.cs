namespace ShoppingCenter
{
    using System;
    public class Product : IComparable<Product>
    {
        public Product(string name, decimal price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public string Producer { get; private set; }

        public int CompareTo(Product other)
        {
            int name = this.Name.CompareTo(other.Name);

            if (name == 0)
            {
                int producer = this.Producer.CompareTo(other.Producer);
                if (producer == 0)
                {
                    return this.Price.CompareTo(other.Price);
                }

                return producer;
            }

            return name;
        }

        public override string ToString()
        {
            return string.Format("{{{0};{1};{2:0.00}}}", this.Name,this.Producer,this.Price);
        }
    }
}
