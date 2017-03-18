namespace _7.GringottsDatabase
{
    using System;
    using Models;

    public class Program
    {
        public static void Main()
        {
            var ctx = new GringottsContext();
            ctx.WizardDeposits.Add(new WizardDeposits()
            {
                FirstName = "Albus",
                LastName = "Dumbeldore",
                Age = 150,
                MagicWandCreator = "Nqkoi si",
                MagicWandSize = 15,
                DepositStartDate = new DateTime(2016,10,20),
                DepositExpirationDate = new DateTime(2020,10,20),
                DepositAmount = 20000.24m,
                DepositCharge = 0.2,
                IsDepositExpired = false
            });

            ctx.WizardDeposits.Add(new WizardDeposits()
            {
                FirstName = "Malbus",
                LastName = "Rumbeldore",
                Age = 450,
                MagicWandCreator = "Nqkoi drug",
                MagicWandSize = 21,
                DepositStartDate = new DateTime(2015, 10, 20),
                DepositExpirationDate = new DateTime(2050, 10, 20),
                DepositAmount = 199.99m,
                DepositCharge = 1.2,
                IsDepositExpired = false,
                DepositGroup = "Troll",
                DepositInterest = 1.5
            });

            ctx.SaveChanges();
        }
    }
}
