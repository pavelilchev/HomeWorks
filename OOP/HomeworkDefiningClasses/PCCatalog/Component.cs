
using System;
using System.Text;

namespace PCCatalog
{
	public class Component
	{
		private string name;
		private decimal price;
		private string details;
		
		public Component(string name, decimal price) :
			this(name, price, null)
		{			
		}
		
		public Component(string name, decimal price, string details)
		{
			this.Name = name;
			this.Price = price;
			this.Details = details;
		}
		
		public string Name
		{
			get { return name; }
			set {
				if (String.IsNullOrEmpty(value))
				    {
				    	throw new ArgumentOutOfRangeException("Name cannot be null or empthy");
				    }
			 	name = value; }
		}
		
		public decimal Price
		{
			get { return price; }
			set { 
				if (value < 0) 
					{
						throw new ArgumentOutOfRangeException("Price cannot be negative");
					}
				price = value; }
		}
		
		public string Details
		{
			get { return details; }
			set { details = value;}
		}
		
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(this.Name + " ");
			sb.Append(this.Price + " lv");
			
			return sb.ToString();
		}

	}
}
