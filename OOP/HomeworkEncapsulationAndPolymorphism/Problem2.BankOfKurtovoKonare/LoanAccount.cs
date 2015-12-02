
using System;

namespace Problem2.BankOfKurtovoKonare
{
	public class LoanAccount : Account
	{
		public LoanAccount(Customer customer, decimal balance, decimal interestRate)
			:base(customer, balance, interestRate)
		{			
		}		
		
		public override decimal CalculateInterest(int months)
		{
			decimal interest = 0m;
			switch (this.Owner.GetType().Name) 
			{
				case "IndividualCustomer":
					if (months > 3) 
					{
					interest =	base.CalculateInterest(months - 3);
					}					
					break;
				case "CompanieCustomer":
					if (months > 2) 
					{
					interest=	base.CalculateInterest(months - 2);
					}					
					break;
			}
			
			return interest;
		}
	}
}
