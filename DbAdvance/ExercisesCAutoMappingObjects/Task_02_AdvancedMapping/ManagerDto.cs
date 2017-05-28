namespace Task_02_AdvancedMapping
{
    using System.Collections.Generic;

    public class ManagerDto
    {
        public ManagerDto()
        {
            this.Subordinates = new List<EmployeeDto>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<EmployeeDto> Subordinates { get; set; }

        public int SubordinatesCount { get; set; }
    }
}
