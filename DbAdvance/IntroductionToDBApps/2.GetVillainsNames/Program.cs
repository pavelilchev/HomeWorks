namespace _2.GetVillainsNames
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            var dbCon = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                var query = File.ReadAllText("../../Initial.sql");
                SqlCommand command = new SqlCommand(query, dbCon);
                var reader = command.ExecuteReader();
                using (reader)
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No villains with more than 3 minions");
                        return;
                    }

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]} {reader[1]}");
                    }
                }

            }
        }
    }
}
