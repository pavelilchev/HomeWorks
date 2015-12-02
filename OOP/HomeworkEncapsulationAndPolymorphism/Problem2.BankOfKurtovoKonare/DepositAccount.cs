
using System;

namespace Problem2.BankOfKurtovoKonare
{
	public class DepositAccount : Account
	{
		public DepositAccount(Customer customer, decimal balance, decimal interestRate)
			:base(customer, balance, interestRate)
		{			
		}
		
		public void WithDraw(decimal money)
		{
			if (money > this.Balance)
			{
				throw new ArgumentOutOfRangeException("No such money in account");
			}
			this.Balance -= money;
		}
		
		public override decimal CalculateInterest(int months)
		{
			decimal interest = 0m;
			if (this.Balance >= 1000) 
			{
				interest = base.CalculateInterest(months);
			}
			
			return interest;
		}
	}
}
