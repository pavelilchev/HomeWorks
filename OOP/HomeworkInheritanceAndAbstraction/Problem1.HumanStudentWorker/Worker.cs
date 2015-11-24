
using System;

namespace Problem1.HumanStudentWorker
{
	public class Worker : Human
	{
		private const int DayPerWeek = 5;
		private decimal weekSalary;
		private decimal workHoursPerDay;
		
		public Worker(string firstName, string lastName, decimal weekSalary , decimal workHoursPerDay)
			: base(firstName, lastName)
		{
			this.WeekSalary = weekSalary;
			this.WorkHoursPerDay = workHoursPerDay;
		}
		
		
		
		public decimal WeekSalary {
			get { return this.weekSalary; }
			set { this.weekSalary = value; }
		}		
	
		
		public decimal WorkHoursPerDay {
			get { return this.workHoursPerDay; }
			set { this.workHoursPerDay = value; }
		}
		
		public decimal	MoneyPerHour()
		{
			return this.WeekSalary / Worker.DayPerWeek / this.WorkHoursPerDay;
		}
		
		public override string ToString()
		{
			return base.ToString() + string.Format(", Money per hour {0:F2} lv.", this.MoneyPerHour());
		}
 
	}
}
