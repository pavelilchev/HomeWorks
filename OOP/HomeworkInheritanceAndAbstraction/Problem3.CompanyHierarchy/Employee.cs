
using System;
using Problem3.CompanyHierarchy.Interfaces;
using System.Text;

namespace Problem3.CompanyHierarchy
{
	public enum Departament
	{
		Production,
		Accounting,
		Sales,
		Marketing
	}

	public abstract class Employee : Person, IEmployee
	{
		private decimal salary;
		private Departament departament;

		protected Employee(int id, string firstName, string lastName, decimal salary, string departament) 
			: base(id, firstName, lastName)
		{
			this.Salary = salary;
			this.Departament = GetDepartament(departament);
		}

		public decimal Salary
        {
			get { return this.salary; }
			set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Nobody will work without money!!!");
                }
                this.salary = value;
            }
		}

		public Departament Departament
        {
			get { return this.departament; }
			set { this.departament = value; }
		}

		private Departament GetDepartament(string departament)
		{
			Departament dep;
			bool isDepartament = Enum.TryParse(departament, out dep);

			if (!isDepartament) {
				throw new ArgumentOutOfRangeException("Invalid departament type");
			}

			return dep;
		}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine(string.Format("Salary: {0}, Departament: {1}", this.Salary, this.Departament.ToString()));

            return sb.ToString();
        }
    }
}
