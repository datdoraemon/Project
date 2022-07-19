using Persistence;
using MySql.Data.MySqlClient;


namespace DAL;
public class DishDAL
{
    public void InsertDish(Dish ds)
    {
        string query = $"insert Dish(dishID, dishName,amount,unit_price,date_of_manufacture,expiry) values('{ds.DishID}','{ds.DishName}','{ds.Amount}','{ds.Price}','{ds.DateofManufacture}'.'{ds.Expiry}')";
        DBHelper.OpenConnection();
        MySqlDataReader reader = DBHelper.ExecQuery(query);
        DBHelper.CloseConnection();
    }
    public int DishIDMax()
    {
        string query = "select max(dishID) from Dish";
        DBHelper.OpenConnection();
        MySqlDataReader reader = DBHelper.ExecQuery(query);

        int maxid = 0;
        if(reader.Read())
        {
            maxid = reader.GetInt32("max(dishID)");
        }
        DBHelper.CloseConnection();
        return maxid;
    }
}