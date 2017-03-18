namespace BankSystem.Models
{
    public class CheckingAccount : Account
    {
        public decimal Fee { get; set; }

        public decimal AddInterest()
        {
            this.Balance -= this.Fee;

            return this.Balance;
        }
    }
}
