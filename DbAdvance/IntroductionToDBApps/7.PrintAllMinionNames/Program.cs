namespace _7.PrintAllMinionNames
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    class Program
    {
        static void Main(string[] args)
        {
            var dbCon = new SqlConnection("Server=.;Integrated Security=true");
            dbCon.Open();
            var names = new List<string>();
            using (dbCon)
            {
                var minionQuery = @"use MinionsDB select Name from Minions";
                SqlCommand minionQueryCommand = new SqlCommand(minionQuery, dbCon);
                var nameReader = minionQueryCommand.ExecuteReader();
                using (nameReader)
                {
                    while (nameReader.Read())
                    {
                        names.Add(nameReader[0].ToString());
                    }
                }
            }


            for (int i = 0; i < names.Count / 2; i++)
            {
                Console.WriteLine(names[i]);
                Console.WriteLine(names[names.Count - i - 1]);
            }
        }
    }
}
