
using System;
using System.Collections.Generic;
using Problem3.CompanyHierarchy.Interfaces;
using System.Text;

namespace Problem3.CompanyHierarchy
{
    public class SalesEmployee : RegularEmployee, ISalesEmployee
    {
        private List<Sale> sales;

        public SalesEmployee(int id, string firstName, string lastName, decimal salary, string departament)
            : base(id, firstName, lastName, salary, departament)
        {
            this.sales = new List<Sale>();
        }

        public IEnumerable<Sale> Sales
        {
            get { return this.sales; }
        }

        public void AddSale(Sale sale)
        {
            this.sales.Add(sale);
            Console.WriteLine("Sale added");
        }

        public void RemoveSale(Sale sale)
        {
            if (this.sales.Remove(sale))
            {
                Console.WriteLine("Sale removed");
            }
            else
            {
                Console.WriteLine("Whaaat? No sale like this!");
            }

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());

            foreach (var sale in this.Sales)
            {
                sb.AppendLine(sale.ToString());
            }

            return sb.ToString();
        }
    }
}
