
using System;

namespace LaptopShop
{	
	public class Laptop
	{
		private string model;
		private decimal price;
		private string manufacturer;
		private string processor;		
		private int ram;
		private string graphicsCard;
		private string hdd;
		private string screen;
		private double batteryLife;
		private Battery battery;
		
		public Laptop (string model, decimal price)
		{
			this.Model = model;
			this.Price = price;
		}
		
		public Laptop(string model, decimal price, string manufacturer, string processor, int ram, string graphicsCard, string hdd, string screen, double batteryLife, Battery battery)
		{
			this.Model = model;
			this.Price = price;
			this.Manufacturer = manufacturer;
			this.Processor = processor;
			this.RAM = ram;
			this.GraphicsCard = graphicsCard;
			this.HDD = hdd;
			this.Screen = screen;
			this.BatteryLife = batteryLife;
			this.Battery = battery;
		}
		
		public string Model {
			get {return model;
			}
			set { 
				 
				if (String.IsNullOrEmpty(value)) {
					throw new ArgumentOutOfRangeException("Cannot be null or empthy!");
				}
				
				model = value; }
		}		
		
		public decimal Price {			
			get {return price; }
			set { 
				 
				if (value < 0) 
			{
				throw new ArgumentOutOfRangeException("Cnanot be negative!");
			}
				
				price = value; }
		}	
		
		public Battery Battery {
			get { return battery; }
			set { battery = value; }
		}
		
		public string Manufacturer {
			get {return manufacturer; }
			set {

				if (String.IsNullOrEmpty(value)) 
				{
					throw new ArgumentOutOfRangeException("Cannot be null or empthy!");
				}
				
				manufacturer = value; }
		}
		
		
		public string Processor {
			get {return processor; }
			set { 
				 
				if (String.IsNullOrEmpty(value)) 
				{
					throw new ArgumentOutOfRangeException("Cannot be null or empthy!");
				}
				
				processor = value; }
		}
		
		public int RAM {
			get {return ram; }
			set { 
				 
				if (value < 0) 
			{
				throw new ArgumentOutOfRangeException("Cnanot be negative!");
			}
				
				ram = value; }
		}
		
		
		public string GraphicsCard {
			get {return graphicsCard; }
			set {
 
				if (String.IsNullOrEmpty(value)) 
				{
					throw new ArgumentOutOfRangeException("Cannot be null or empthy!");
				}
				
				graphicsCard = value; }
		}
		
		public string HDD {
			get { return hdd; }
			set {

				if (String.IsNullOrEmpty(value)) 
				{
					throw new ArgumentOutOfRangeException("Cannot be null or empthy!");
				}
				
				hdd = value; }
		}
		
		public string Screen {
			get {return screen; }
			set { 
				 
				if (String.IsNullOrEmpty(value)) 
				{
					throw new ArgumentOutOfRangeException("Cannot be null or empthy!");
				}
				
				screen = value; }
		}
		
		public double BatteryLife {
			get {return batteryLife; }
			set {
 
				if (value < 0) 
			{
				throw new ArgumentOutOfRangeException("Cnanot be negative!");
			}
				
				batteryLife = value; }
		}		
		
		
		public override string ToString()
		{
			String result = "Model: " + this.Model;
			
			if (!String.IsNullOrEmpty(this.Manufacturer)) {
				result += Environment.NewLine;
				result += "Manufacturer: " + this.Manufacturer;
			}
			
			if (!String.IsNullOrEmpty(this.Processor)) {
				result += Environment.NewLine;
				result += "Processor: " + this.Processor;
			}
			
			if (ram > 0) 
			{
				result += Environment.NewLine;
				result += "Ram: " + this.RAM + " GB";
			}
			
			if (!String.IsNullOrEmpty(this.GraphicsCard)) {
				result += Environment.NewLine;
				result += "Processor: " + this.GraphicsCard;
			}
			
			if (!String.IsNullOrEmpty(this.HDD)) {
				result += Environment.NewLine;
				result += "Hdd: " + this.HDD;
			}
			
			if (!String.IsNullOrEmpty(this.Screen)) {
				result += Environment.NewLine;
				result += "Screen: " + this.Screen;
			}
			
			if (this.Battery != null) {
				result += Environment.NewLine;
				result += this.Battery.ToString();
			}
			
			
			if (this.BatteryLife > 0)
			{
				result += Environment.NewLine;
				result += "BatteryLife: " + this.BatteryLife + " hours";
			}						
			
			result += Environment.NewLine;
			result += "Price: " + this.Price + " lv";
				
			return result;
		}		
	}
}
