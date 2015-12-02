
using System;

namespace Problem2.BankOfKurtovoKonare
{
	public class MortgageAccount : Account
	{
		public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
			:base(customer, balance, interestRate)
		{			
		}	
		
		public override decimal CalculateInterest(int months)
		{
			decimal interest = 0m;
			switch (this.Owner.GetType().Name) 
			{
				case "IndividualCustomer":
					if (months > 6) 
					{
						interest=	base.CalculateInterest(months - 6);
					}					
					break;
				case "CompanieCustomer":
					int halfrateMonths = months % 12;
					int normalrateMonths = months / 12;
					
					interest += this.Balance *(1 + (this.InterestRate/2)*halfrateMonths);
					interest += base.CalculateInterest(normalrateMonths);
					break;					
			}
			
			return interest;
		}
	}
}
