using Persistence;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class SalesmanDAL
    {
        public Salesman GetUser(MySqlDataReader reader)
        {
            Salesman salesman = new Salesman();
            salesman.Username = reader.GetString("username");
            return salesman;
        }
        public Salesman GetPass(MySqlDataReader reader)
        {
            Salesman salesman = new Salesman();
            salesman.Password = reader.GetString("pass");
            salesman.ShopID = reader.GetInt32("shopID");
            return salesman;
        }
        
        public List<Salesman> GetUserName(string username)
        {
            string query = @"select sm.username from Salesmans sm where sm.username = '" + username +"'";
            DBHelper.OpenConnection();
            MySqlDataReader reader = DBHelper.ExecQuery(query);
            Salesman salesman = null;
            List<Salesman> saleslist = new List<Salesman>();
            while(reader.Read())
            {
               salesman = GetUser(reader);
               saleslist.Add(salesman);
            }
            DBHelper.CloseConnection();
            return saleslist;
        }
        public List<Salesman> GetPassword()
        {
            string query = @"select sm.pass,sm.shopID from Salesmans sm";
            DBHelper.OpenConnection();
            MySqlDataReader reader = DBHelper.ExecQuery(query);
            Salesman salesman = null;
            List<Salesman> saleslist = new List<Salesman>();
            while(reader.Read())
            {
               salesman = GetPass(reader);
               saleslist.Add(salesman);
            }
            DBHelper.CloseConnection();
            return saleslist;
        }
    }
}