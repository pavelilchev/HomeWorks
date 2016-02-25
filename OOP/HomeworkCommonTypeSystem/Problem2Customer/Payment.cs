
using System;

namespace Problem2Customer
{
	public class Payment
	{
		private string productName;
		private decimal price;
		
		public Payment(string productName, decimal price)
		{
			this.ProductName = productName;
			this.Price = price;
			
		}
		
		public string ProductName 
			{
			get
			{
				return this.productName;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException("Invalid product name");
				}
				
				this.productName = value;
			}
			
		}
		
		public decimal Price
		{
			get
			{
				return this.price;
			}
			set
			{
				if (value <= 0)
				{
					throw new ArgumentOutOfRangeException("Price should be positive");
				}
				
				this.price = value;
			}
			
		}
		
		public override string ToString()
		{
			return string.Format("Product name: {0}, Price: {1}", this.ProductName, this.Price);
		}

	}
}
