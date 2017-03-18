namespace _2.LocalStoreImprovement
{
    using System.Data.SqlClient;

    public class Program
    {
        public static void Main()
        {
            SqlConnection dbCon = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=LocalStore;Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand alterTableCommandQ = new SqlCommand(@"ALTER TABLE Products
                                                                ADD  
                                                                Quantity  int default (0)", dbCon);
                alterTableCommandQ.ExecuteNonQuery();

                SqlCommand alterTableCommandW = new SqlCommand(@"ALTER TABLE Products
                                                                ADD  
                                                                Weight float default (0)", dbCon);
                alterTableCommandW.ExecuteNonQuery();
            }
        }
    }
}