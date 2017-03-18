namespace BankSystem.Models
{
    public class SavingAccount : Account
    {
        public decimal InterestRate { get; set; }

        public decimal AddInterest()
        {
            this.Balance *= this.InterestRate;

            return this.Balance;
        }
    }
}
