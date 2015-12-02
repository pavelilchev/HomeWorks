
using System;
using Problem1.Shapes.Interfaces;

namespace Problem1.Shapes
{
	public abstract class BasicShape : IShape
	{
			
		private double height;		
		private double width;
		
		protected BasicShape(double width, double height)
		{
			this.Width = width;
			this.Height = height;
		}
	
		public double Width 
		{
			get { return this.width; }
			private set
			{ 
				if (value < 0) 
				{
					throw new ArgumentNullException("Width cannot be negative");
				}
				this.width = value; 
			}
		}
		
		public double Height 
		{
			get { return this.height; }
			private set
			{ 
				if (value < 0) 
				{
					throw new ArgumentNullException("Width cannot be negative");
				}
				this.height = value;
			}
		}

		public abstract double CalculateArea();
		public abstract double CalculatePerimeter();
	}
}
