
using System;

namespace Problem2.BankOfKurtovoKonare.Contracts
{
	public interface IAccount
	{
		Customer Owner { get; }
		decimal Balance { get; }
		decimal InterestRate { get;}		
		
		void Deposit(decimal money);
		decimal CalculateInterest(int months);
	}
}
