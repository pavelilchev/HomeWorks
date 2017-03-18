namespace _5.ChangeTownNamesCasing
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter Country name: ");
            string countryName = Console.ReadLine();

            var dbCon = new SqlConnection("Server=.;Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                string queryUpdateTowns = @"
                        use MinionsDB
                        update Towns
                        set Name = UPPER(Name)
                        Where Country = @countryName";
                SqlCommand commandUpdateTowns = new SqlCommand(queryUpdateTowns, dbCon);
                commandUpdateTowns.Parameters.AddWithValue("@countryName", countryName);
                int rowsAffected = commandUpdateTowns.ExecuteNonQuery();
                if (rowsAffected < 1)
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }

                Console.WriteLine($"{rowsAffected} town names were affected.");

                string queryGetNames = @"use MinionsDB
                        select Name from Towns
                        Where Country = @countryName";
                SqlCommand commandGetTowns = new SqlCommand(queryGetNames, dbCon);
                commandGetTowns.Parameters.AddWithValue("@countryName", countryName);
                var townsReader = commandGetTowns.ExecuteReader();
                var towns = new List<string>();
                using (townsReader)
                {
                    while (townsReader.Read())
                    {
                        towns.Add(townsReader[0].ToString());
                    }

                    Console.WriteLine("[" + string.Join(", ", towns) + "]");
                }
            }
        }
    }
}
