
using System;

namespace LaptopShop
{
	public class Battery
	{
		string type;
		
		int cells;
		
		int miliAmperHours;
		
		public Battery(string type, int cells, int miliAmperHours)
		{
			this.type = type;
			this.cells = cells;
			this.miliAmperHours = miliAmperHours;
		}
		
		public int MiliAmperHours {
			get {
				return miliAmperHours; }
			set { 
				 
				if (value < 0) 
			{
				throw new ArgumentOutOfRangeException("Cnanot be negative!");
			}
				miliAmperHours = value; }
		}
		
		public int Cells {
			get { return cells; }
			set { 
				
				if (value < 0) 
			{
				throw new ArgumentOutOfRangeException("Cnanot be negative!");
			}
				
				cells = value; }
		}
		
		public string Type {
			get {				return type; }
			set { 
				 
				if (String.IsNullOrEmpty(value)) 
				{
					throw new ArgumentOutOfRangeException("Cannot be null or empthy!");
				}
				type = value; }
		}
		
		public override string ToString()
		{
			return string.Format("Battery: {0}, {1}-cells, {2} mAh", type, cells, miliAmperHours);
		}

	}
}
