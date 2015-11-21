
using System;
using System.Collections.Generic;
using System.Text;

namespace PCCatalog
{
	public class Computer
	{
		private string name;
		private decimal price;		
		private List<Component> components;

		
		public Computer(string name, params Component[] components)
		{
			this.components = new List<Component>();
			this.Name = name;				
			InizializeComponents(components);
			this.Price = CalculateComputerPrice();
		}				
		
		public string Name {
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
			set { price = value; }
		}
		
		private void InizializeComponents(Component[] components)
		{
			foreach (var component in components) {
				this.components.Add(component);
			}
		}
		
		private decimal CalculateComputerPrice()
		{
			decimal resultPrice = 0m;
			
			foreach (var component in this.components)
			{
				resultPrice += component.Price;
			}
			
			return resultPrice;
		}
		
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("Name: " + this.Name);
			sb.Append(Environment.NewLine);
			
			foreach (var component in this.components) 
			{
				sb.Append(component.ToString());
				sb.Append(Environment.NewLine);
			}
			
			sb.Append(this.Price);
			
			return sb.ToString();
		}


	}
}
