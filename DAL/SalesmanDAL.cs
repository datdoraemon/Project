using Persistence;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class SalesmanDAL
    {
        public Salesman GetShop(MySqlDataReader reader)
        {
            Salesman salesman = new Salesman();
            salesman.ShopID = reader.GetInt32("shopID");
            salesman.ShopName = reader.GetString("shopname");
            return salesman;
        }
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
        public List<Salesman> GetPassword(string md5)
        {
            string query = @"select sm.pass,sm.shopID from Salesmans sm where sm.pass = '" + md5 +"'";
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
        public List<Salesman> GetShopName(int shop)
        {
            string query = @"select s.shopID,s.shopname from Shop s where s.shopID = " + shop;
            DBHelper.OpenConnection();
            MySqlDataReader reader = DBHelper.ExecQuery(query);
            Salesman salesman = null;
            List<Salesman> saleslist = new List<Salesman>();
            while(reader.Read())
            {
               salesman = GetShop(reader);
               saleslist.Add(salesman);
            }
            DBHelper.CloseConnection();
            return saleslist;
        }
    }
}