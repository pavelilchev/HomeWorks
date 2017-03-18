namespace _9.IncreaseAgeStoredProcedure
{
    using System;
    using System.Data.SqlClient;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter minion ID: ");
            int id = int.Parse(Console.ReadLine());

            var dbCon = new SqlConnection("Server=.;Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {

                var minionQuery = $@"use MinionsDB exec usp_GetOlder @id = {id}";
                SqlCommand minionQueryCommand = new SqlCommand(minionQuery, dbCon);
                minionQueryCommand.ExecuteNonQuery();


                var query = $@"use MinionsDB select Name, Age from Minions where Id = {id}";
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
