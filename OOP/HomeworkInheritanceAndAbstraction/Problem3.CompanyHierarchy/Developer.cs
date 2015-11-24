
using System;
using System.Collections.Generic;
using Problem3.CompanyHierarchy.Interfaces;
using System.Text;

namespace Problem3.CompanyHierarchy
{
	public class Developer : RegularEmployee, IDeveloper
	{
		private List<Project> projects;

		public Developer(int id, string firstName, string lastName, decimal salary, string departament)
			: base(id, firstName, lastName,salary,departament)
		{
			projects = new List<Project>();
		}
     
        public IEnumerable<Project> Projects
        {
            get { return this.projects; }           
        }


        public void AddProject(Project pr)
		{
            if (pr == null)
            {
                throw new ArgumentNullException("Project cannot be null");
            }
            Console.WriteLine("Project added");
			this.projects.Add(pr);
		}

		public void RemoveProject(Project pr)
		{
            if (this.projects.Remove(pr))
            {
                Console.WriteLine("Project removed");
            }
            else
            {
                Console.WriteLine("No such project");
            }
          
		}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());

            foreach (var project in this.Projects)
            {
                sb.Append(project.ToString());
            }

            return sb.ToString();
        }
    }
}
