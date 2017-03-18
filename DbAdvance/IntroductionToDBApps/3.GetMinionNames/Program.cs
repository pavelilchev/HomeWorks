namespace _3.GetMinionNames
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Villain Id: ");
            int id = int.Parse(Console.ReadLine());
            var dbCon = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                var query = string.Format(File.ReadAllText("../../Initial.sql"), id);
                SqlCommand command = new SqlCommand(query, dbCon);

                var reader = command.ExecuteReader();
                using (reader)
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine($"No villain with ID {id} exists in the database.");
                        return;
                    }

                    reader.Read();
                    Console.WriteLine($"Villain: {reader[0]}");
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.WriteLine($"{i + 1}. {reader[1]} {reader[2]}");
                        reader.Read();
                    }
                }

            }
        }
    }
}
