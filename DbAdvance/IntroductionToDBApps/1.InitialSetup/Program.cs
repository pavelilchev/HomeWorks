namespace _1.InitialSetup
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    class Program
    {
        static void Main()
        {
            var dbCon = new SqlConnection("Server=.;Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                var createDb = File.ReadAllText("../../CreateDatabase.sql");
                SqlCommand create = new SqlCommand(createDb, dbCon);
                create.ExecuteNonQuery();

                var fill = File.ReadAllText("../../Initial.sql");
                SqlCommand command = new SqlCommand(fill, dbCon);
                int rows = (int)command.ExecuteNonQuery();

                Console.WriteLine($"Rows affected: {rows}");
            }
        }
    }
}
