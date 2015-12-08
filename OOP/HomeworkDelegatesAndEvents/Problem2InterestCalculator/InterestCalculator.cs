using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2InterestCalculator
{
    public class InterestCalculator
    {
        Func<decimal, decimal, int, decimal> balance;

        public InterestCalculator(decimal money, decimal interest, int years, Func<decimal, decimal, int, decimal> balance)
       {
            this.Money = money;
            this.Interest = interest;
            this.Years = years;
            this.balance = balance;
       }

       public decimal Money { get; set; }

       public decimal Interest { get; set; }

       public int Years { get; set; }

        public decimal Balance
        {
            get
            {
                return this.balance(this.Money, this.Interest, this.Years);
            }
        }
    }
}
