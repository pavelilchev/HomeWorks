
using System;
using Problem2.BankOfKurtovoKonare.Contracts;

namespace Problem2.BankOfKurtovoKonare
{
	public abstract class Account : IAccount
	{
		private Customer owner;
		private decimal balance;
		private decimal interestRate;
		
		protected Account(Customer owner, decimal balance, decimal interestRate)
		{
			this.Owner = owner;
			this.Balance = balance;
			this.InterestRate = interestRate;			
		}

		public Customer Owner 
		{ 
			get
			{
				return this.owner;
			}
			private set
			{
				if (value == null) 
				{
					throw new ArgumentNullException("Owner cannot be null");
				}
				this.owner = value;
			}
		}
		
		public decimal Balance 
		{ 
			get
			{
				return this.balance;
			}
			protected set
			{
				if (value< 0)
				{
					throw new ArgumentNullException("Balance cannot be negative");
				}
				this.balance = value;
			}
		}
		
		public decimal InterestRate
		{ 
			get
			{
				return this.interestRate;
			}
			private set
			{
				if (value< 0)
				{
					throw new ArgumentNullException("InterestRate cannot be negative");
				}
				this.interestRate = value;
			}
		}	
		
		public virtual void Deposit(decimal money)
		{
			if (money < 0) {
				throw new ArgumentOutOfRangeException("Deposite money cannot be negative");
			}
			this.Balance += money;
		}		
		
		public virtual decimal CalculateInterest(int months)
		{
			return this.Balance *(1 + this.InterestRate*months);
		}

		public override string ToString()
		{
			return string.Format("Owner: {0}, Balance: {1}, InterestRate: {2}"
			                     , this.Owner.Name, this.Balance, this.InterestRate);
		}


	}
}
