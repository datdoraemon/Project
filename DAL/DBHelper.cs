using MySql.Data.MySqlClient;

namespace DAL
{
    public class DBHelper
    {
       private static MySqlConnection connection;

       public static MySqlConnection GetConnection()
       {
           if(connection == null)
            {
               connection = new MySqlConnection
               {
                   ConnectionString = @"server=127.0.0.1;port=3306;user=root;database=Foodstore;password=562001;"
               };
            }
        return connection;
        }
        public static MySqlDataReader ExecQuery(string query)
        {
          MySqlCommand sqlCommand = new MySqlCommand(query, connection);
          return sqlCommand.ExecuteReader();
        }
        public static MySqlConnection OpenConnection()
        {
          if(connection == null)
          {
              GetConnection();
          }
          connection.Open();
          return connection;
        }
        public static void CloseConnection()
        {
           if (connection != null)
           {
                connection.Close();
           }
        }
    }
}


