using System.Data.SqlClient;

namespace Factory
{
    public class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=BOOK-ILYA;Initial Catalog=Factory;Integrated Security=True");

        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection getConnection() { return sqlConnection; }
    }
}