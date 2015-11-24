
using System;
using Problem3.CompanyHierarchy.Interfaces;

namespace Problem3.CompanyHierarchy
{
    public class Customer : Person, ICustomer
    {
        private decimal purshaseAmount;

        public Customer(int id, string firstName, string lastName, decimal purshaseAmount) : base(id, firstName, lastName)
        {
            this.PurshaseAmount = purshaseAmount;
        }

        public decimal PurshaseAmount
        {
            get { return purshaseAmount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Purchase cannot be negative");
                }
                purshaseAmount = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + ", Purshase amount: " + this.PurshaseAmount;
        }
    }
}
