namespace Task_03_Projection
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public string ManagerLastName { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} {this.Salary} – Manager: {this.ManagerLastName}";
        }
    }
}
