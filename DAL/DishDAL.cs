using Persistence;
using MySql.Data.MySqlClient;


namespace DAL;
public class DishDAL
{
    public Dish GetID(MySqlDataReader reader)
    {
        Dish dish = new Dish();
        dish.DishID = reader.GetInt32("dishID");
        return dish;
    }
    public Dish GetDish(MySqlDataReader reader)
    {
        Dish dish = new Dish();
        dish.DishID = reader.GetInt32("dishID");
        dish.DishName = reader.GetString("dishName");
        dish.Amount = reader.GetInt32("amount");
        dish.Price = reader.GetDouble("unit_price");
        dish.DateofManufacture = reader.GetDateTime("date_of_manufacture");
        dish.Expiry = reader.GetDateTime("expiry");
        return dish;
    }
    public List<Dish> GetAllDish(int shop)
    {
        string query = @"select ds.dishID,ds.dishName ,ds.amount, ds.unit_price, ds.date_of_manufacture, ds.expiry from Dish ds
                         inner join ShopDish sd on ds.dishID = sd.dishID
                         inner join Shop s on sd.shopID = s.shopID
                         where s.shopID = " + shop;
        DBHelper.OpenConnection();
        MySqlDataReader reader = DBHelper.ExecQuery(query);
        Dish dishes = null;
        List<Dish> dishlist = new List<Dish>();
            while(reader.Read())
            {
                dishes = GetDish(reader);
                dishlist.Add(dishes);
            }
            DBHelper.CloseConnection();
            return dishlist;
    }
    public void InsertDish(Dish ds, int shop)
    {
        string query = $"insert Dish(dishID, dishName,amount,unit_price,date_of_manufacture,expiry) values('{ds.DishID}','{ds.DishName}','{ds.Amount}','{ds.Price}','{ds.DateofManufacture}','{ds.Expiry}')";
        Console.WriteLine(query);
        
        DBHelper.OpenConnection();
        MySqlDataReader reader = DBHelper.ExecQuery(query);
        DBHelper.CloseConnection();
    }
    public void SaveDish(Dish ds, int shop)
    {
        string query = $"insert ShopDish(shopID, dishID) values('{shop}','{ds.DishID}')";
        
        DBHelper.OpenConnection();
        MySqlDataReader reader = DBHelper.ExecQuery(query);
        DBHelper.CloseConnection();
    }
    public List<Dish> GetDishID(int shop)
    {
        string query = @"select ds.dishID from Dish ds
                         inner join ShopDish sd on ds.dishID = sd.dishID";
        DBHelper.OpenConnection();
        MySqlDataReader reader = DBHelper.ExecQuery(query);
        Dish dishes = null;
        List<Dish> dishlist = new List<Dish>();
        while(reader.Read())
        {
            dishes = GetID(reader);
            dishlist.Add(dishes);
        }
        DBHelper.CloseConnection();
        return dishlist;
    }
}