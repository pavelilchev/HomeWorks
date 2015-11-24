
using System;
using Problem3.CompanyHierarchy.Interfaces;

namespace Problem3.CompanyHierarchy
{
	public class Sale : ISale
	{
		private string name;
		private decimal price;
		private DateTime date;

		public Sale(string name, decimal price, DateTime date)
		{
			this.Name = name;
			this.Price = price;
			this.Date = date;
		}

		public DateTime Date
        {
			get { return this.date; }
			set { this.date = value; }
		}

		public decimal Price
        {
			get { return this.price; }
			set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price should be positive");
                }
                this.price = value;
            }
		}

		public string Name
        {
			get { return this.name; }
			set { this.name = value; }
		}

        public override string ToString()
        {
            return string.Format("Sale name: {0}, Price: {1}, Date: {2}.{3}.{4}", this.Name, this.Price, this.Date.Day, this.Date.Month, this.Date.Year);          
        }
    }
}
