namespace Gringotts
{
    using System;
    using System.Linq;
    using Data;

    public class Startup
    {
        public static void Main()
        {
            var ctx = new GringottsContext();

            //4. Deposits Sum for Ollivander Family
            GetTotalDepositByGroups(ctx);

            Console.WriteLine(new string('-', Console.WindowWidth));
            //5. Deposits Filter
            DepositFilter(ctx);
        }

        private static void DepositFilter(GringottsContext ctx)
        {
            var groups = ctx.WizzardDeposits
                .Where(g => g.MagicWandCreator == "Ollivander family")
                .GroupBy(g => g.DepositGroup)
                .Select(g => new {Group = g.Key, Total = g.Sum(d => d.DepositAmount)})
                .Where(g => g.Total < 150000)
                .OrderByDescending(g => g.Total)
                .ToList();

            foreach (var g in groups)
            {
                Console.WriteLine($"{g.Group} - {g.Total}");
            }
        }

        private static void GetTotalDepositByGroups(GringottsContext ctx)
        {
            var groups = ctx.WizzardDeposits
                .Where(g => g.MagicWandCreator == "Ollivander family")
                .GroupBy(g => g.DepositGroup)
                .Select(g => new {Group = g.Key, Total = g.Sum(d => d.DepositAmount)})
                .ToList();

            foreach (var g in groups)
            {
                Console.WriteLine($"{g.Group} - {g.Total}");
            }
        }
    }
}
