using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gringotts
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new GringottsContext();
            var wizzards = data.WizzardDeposits.Where(d => d.DepositGroup == "Troll Chest").OrderBy(d=>d.FirstName).Select(d=> new
            {
              f = d.FirstName.Substring(0,1)
            }).Distinct();

            foreach (var w in wizzards)
            {
                Console.WriteLine(w.f);
            }

            Console.ReadKey();
        }
    }
}
