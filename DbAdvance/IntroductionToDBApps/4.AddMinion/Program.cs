using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.AddMinion
{
    using System.Data.SqlClient;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            string[] minionParts;
            string[] villainParts;
            while (true)
            {
                Console.Write("Enter minion info: ");
                var minionInfo = Console.ReadLine();
                minionParts = minionInfo.Split();
                if (minionParts.Length != 4)
                {
                    Console.WriteLine("Enter valid minion info");
                    continue;
                }

                Console.Write("Enter villain info: ");
                var villainInfo = Console.ReadLine();
                villainParts = villainInfo.Split();
                if (villainParts.Length != 2)
                {
                    Console.WriteLine("Enter valid villain info");
                    continue;
                }

                break;
            }

            var dbCon = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                var getTown = string.Format(File.ReadAllText("../../GetTown.sql"), minionParts[3]);
                SqlCommand commandGetTown = new SqlCommand(getTown, dbCon);
                int townId = (int?)commandGetTown.ExecuteScalar() ?? -1;
                if (townId < 1)
                {
                    var queryCreateTown = string.Format(File.ReadAllText("../../CreateTown.sql"), minionParts[3]);
                    SqlCommand commandGcreateTown = new SqlCommand(queryCreateTown, dbCon);
                    commandGcreateTown.ExecuteNonQuery();
                    Console.WriteLine($"Town {minionParts[3]} was added to the database.");
                    townId = (int)commandGetTown.ExecuteScalar();
                }

                var getVillain = string.Format(File.ReadAllText("../../GetVillain.sql"), villainParts[1]);
                SqlCommand commandGetVillain = new SqlCommand(getVillain, dbCon);
                int villainId = (int?)commandGetVillain.ExecuteScalar() ?? -1;
                if (villainId < 1)
                {
                    var queryCreateVillain = string.Format(File.ReadAllText("../../CreateVillain.sql"), villainParts[1]);
                    SqlCommand commandGreateVillain = new SqlCommand(queryCreateVillain, dbCon);
                    commandGreateVillain.ExecuteNonQuery();
                    Console.WriteLine($"Villain {villainParts[1]} was added to the database.");
                    villainId = (int)commandGetVillain.ExecuteScalar();
                }

                var newMinionIdQuery = File.ReadAllText("../../GetMinionId.sql");
                SqlCommand commandNewMinionIdQuery = new SqlCommand(newMinionIdQuery, dbCon);
                int newMinionId = (int)commandNewMinionIdQuery.ExecuteScalar();

                var queryCreateMinion = string.Format(File.ReadAllText("../../CreateMinion.sql"), newMinionId, minionParts[1], minionParts[2], townId);
                SqlCommand commandCreateMinion = new SqlCommand(queryCreateMinion, dbCon);
                commandCreateMinion.ExecuteNonQuery();

                var addMinionToVillainQuery = string.Format(File.ReadAllText("../../AddMinionToVillain.sql"), villainId, newMinionId);
                SqlCommand final = new SqlCommand(addMinionToVillainQuery, dbCon);
                final.ExecuteNonQuery();
                Console.WriteLine($"Successfully added {minionParts[1]} to be minion of {villainParts[1]}");
            }
        }
    }
}
