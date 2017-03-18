namespace _8.IncreaseMinionsAge
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter minions ID's separated with space: ");
            int[] ids = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var dbCon = new SqlConnection("Server=.;Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    var minionQuery = $@"use MinionsDB Update Minions set Age += 1 where Id = {ids[i]}";
                    SqlCommand minionQueryCommand = new SqlCommand(minionQuery, dbCon);
                    minionQueryCommand.ExecuteNonQuery();

                    var nameQuery = $@"use MinionsDB UPDATE Minions SET Name=UPPER(LEFT(Name,1))+LOWER(SUBSTRING(Name,2,LEN(Name))) where Id = {ids[i]}";
                    SqlCommand nameCommand = new SqlCommand(nameQuery, dbCon);
                    nameCommand.ExecuteNonQuery();
                }

                var query = @"use MinionsDB select Name, Age from Minions";
                SqlCommand queryCommand = new SqlCommand(query, dbCon);
                var reader = queryCommand.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]} {reader[1]}");
                    }
                }
            }
        }
    }
}
