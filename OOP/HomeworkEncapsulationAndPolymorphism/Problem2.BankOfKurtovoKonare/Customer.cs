
using System;
using Problem2.BankOfKurtovoKonare.Contracts;

namespace Problem2.BankOfKurtovoKonare
{
	public abstract class Customer : ICustomer
	{
		private string name;
		private int id;

		protected Customer(string name, int id)
		{
			this.Name = name;
			this.ID = id;
		}

		public string Name {
			get { return this.name; }
			set { this.name = value; }
		}

		public int ID {
			get { return this.id; }
			set { this.id = value; }
		}
	}
}
