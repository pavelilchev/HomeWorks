
using System;
using Problem2.BankOfKurtovoKonare.Contracts;

namespace Problem2.BankOfKurtovoKonare
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Customer pavel = new IndividualCustomer("Pavel Ilchev", 12345);
			Customer natali = new IndividualCustomer("Natalka Nikolova", 12346);
			Customer nevi = new IndividualCustomer("Nevi Todorova", 12349);
			
			Customer firmata = new CompanieCustomer("Firmata", 12347);
			Customer sandbox = new CompanieCustomer("Sandbox", 12348);
			Customer capela = new CompanieCustomer("Capela", 12350);
			
			Account one = new DepositAccount(pavel, 5000m, 0.35m);
			Account two = new DepositAccount(firmata, 55000m, 0.72m);
			Account tree = new LoanAccount(natali, 4500m, 0.36m);
			Account four = new LoanAccount(sandbox, 45000m, 1.7m);
			Account five = new MortgageAccount(nevi, 1200m, 0.2m);
			Account six = new MortgageAccount(capela, 12000m, 1.7m);
			
			IAccount[] accounts =
			{
				one,
				two,
				tree,
				four,
				five,
				six
			};
			
			foreach (var account in accounts)
			{
				account.Deposit(270);			
			}
			
			foreach (var account in accounts)
			{
				Console.WriteLine(account);
				Console.WriteLine("Interested rate for 15 months " + account.CalculateInterest(15));
			
			}
			Console.ReadKey();
		}
	}
}