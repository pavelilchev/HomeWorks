namespace BankSystem.Models
{
    using System;

    public class Account
    {
        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public decimal Deposi(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount can't be negative!");
            }

            this.Balance += amount;

            return this.Balance;
        }

        public decimal Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount can't be negative!");
            }

            this.Balance -= amount;

            return this.Balance;
        }
    }
}
