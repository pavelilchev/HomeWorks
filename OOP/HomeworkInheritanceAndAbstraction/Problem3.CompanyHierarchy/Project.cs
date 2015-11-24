
using System;
using Problem3.CompanyHierarchy.Interfaces;
using System.Text;

namespace Problem3.CompanyHierarchy
{
	public class Project : IProject
	{
		private bool isOpen;
		private string deatails;
		private DateTime startDate;
		private string name;

		public Project(string name, DateTime startDate, string deatails = null)
		{
			this.isOpen = true;
			this.Deatails = deatails;
			this.StartDate = startDate;
			this.Name = name;
		}

		public string Name
        {
			get { return this.name; }
			set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null");
                }
                this.name = value;
            }
		}

		public DateTime StartDate
        {
			get { return this.startDate; }
			set { this.startDate = value; }
		}

		public string Deatails
        {
			get { return this.deatails; }
			set { this.deatails = value; }
		}

		public void CloseProject()
		{
			if (!this.isOpen)
            {
				throw new ArgumentException("Project is closed");
			}

			this.isOpen = false;
		}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Project name: {0}, start at {1}.{2}.{3}", this.Name, this.StartDate.Day, this.StartDate.Month, this.StartDate.Year));
            if (this.isOpen)
            {
                sb.AppendLine("Project is open");
            }
            else
            {
                sb.AppendLine("Project is closed");
            }
           
              sb.AppendLine("Details: " + this.Deatails??"none");
            

            return sb.ToString();
        }
    }
}
