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
            return salesman;
        }
        public Salesman GetSalesman(MySqlDataReader reader)
        {
            Salesman salesman = new Salesman();
            salesman.SaleID = reader.GetInt32("salesmanID");
            salesman.ShopID = reader.GetInt32("shopID");
            salesman.Username = reader.GetString("username");
            salesman.Password = reader.GetString("pass");
            salesman.ShopName = reader.GetString("shopname");
            return salesman;
        }
        public List<Salesman> GetSales(int shop)
        {
            string query = @"select sm.salesmanID,s.shopID,sm.username,sm.pass,s.shopname from Salesmans sm
                             inner join Shop s on sm.shopID = s.shopID where s.shopID = " + shop;
            DBHelper.OpenConnection();
            MySqlDataReader reader = DBHelper.ExecQuery(query);
            Salesman salesman = null;
            List<Salesman> saleslist = new List<Salesman>();
            while(reader.Read())
            {
               salesman = GetSalesman(reader);
               saleslist.Add(salesman);
            }
            DBHelper.CloseConnection();
            return saleslist;
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
            string query = @"select sm.pass from Salesmans sm";
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