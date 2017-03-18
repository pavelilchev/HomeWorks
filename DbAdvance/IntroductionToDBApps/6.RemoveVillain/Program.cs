namespace _6.RemoveVillain
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    class Program
    {
        static void Main()
        {
            Console.Write("Enter villain ID: ");
            int villainId = int.Parse(Console.ReadLine());

            var dbCon = new SqlConnection("Server=.;Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                var hasVillainQuery = @"use MinionsDB select Name from Villains where Id = @id";
                SqlCommand hasVillainCommand = new SqlCommand(hasVillainQuery, dbCon);
                hasVillainCommand.Parameters.AddWithValue("@id", villainId);
                var villainName = hasVillainCommand.ExecuteScalar();
                if (villainName == null)
                {
                    Console.WriteLine("No such villain was found");
                    return;
                }


                var deleteVillainQuery = @"use MinionsDB delete from Villains where Id = @id";
                SqlCommand deleteVillainCommand = new SqlCommand(deleteVillainQuery, dbCon);
                deleteVillainCommand.Parameters.AddWithValue("@id", villainId);
                deleteVillainCommand.ExecuteNonQuery();
                Console.WriteLine(villainName + " was deleted");


                var releaseMinionsQuery = @"use MinionsDB delete from VillainsMinions where VillainId = @id";
                SqlCommand releaseCommand = new SqlCommand(releaseMinionsQuery, dbCon);
                releaseCommand.Parameters.AddWithValue("@id", villainId);
                var released = releaseCommand.ExecuteNonQuery();
                Console.WriteLine(released + " minions released");

            }
        }
    }
}
