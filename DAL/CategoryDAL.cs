using Persistence;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class CategoryDAL : DishDAL
    {
        public Category GetDishofCategory(MySqlDataReader reader)
        {
            Category category = new Category();
            category.DishID = reader.GetInt32("dishID");
            category.DishName = reader.GetString("dishName");
            category.Amount = reader.GetInt32("amount");
            category.Price = reader.GetDouble("unit_price");
            category.DateofManufacture = reader.GetDateTime("date_of_manufacture");
            category.Expiry = reader.GetDateTime("expiry");
            return category;
        }
        public Category GetCateID(MySqlDataReader reader)
        {
           Category category = new Category();
           category.CategoryID = reader.GetInt32("categoryID");
           return category;
        }
        public Category GetCategory(MySqlDataReader reader)
        {
            Category category = new Category();
            category.CategoryID = reader.GetInt32("categoryID");
            category.CategoryName = reader.GetString("categoryName");
            return category;
        }
        public Category GetDishofCate(MySqlDataReader reader)
        {
            Category category = new Category();
            category.DishID = reader.GetInt32("dishID");
            category.DishName = reader.GetString("dishName");
            category.CategoryID = reader.GetInt32("categoryID");
            return category;
        }
        public List<Category> GetAllCategory(int shop)
        {
            string query = @"select c.categoryID, c.categoryName from Category c
                            inner join CateShop cs on c.categoryID = cs.categoryID
                            inner join Shop s on cs.shopID = s.shopID
                            where s.shopID = "+ shop;
            DBHelper.OpenConnection();
            MySqlDataReader reader = DBHelper.ExecQuery(query);
            Category category = null;
            List<Category> categories = new List<Category>();
            while(reader.Read())
            {
                category = GetCategory(reader);
                categories.Add(category);
            }
            DBHelper.CloseConnection();
            return categories;
        }
        public List<Category> GetAllDishofCate(int shop, int categoryID)
        {
            string query = @"select c.categoryID ,ds.dishID ,ds.dishName from Dish ds
                             inner join ShopDish sd on ds.dishID = sd.dishID
                             inner join CateDish cd on sd.dishID = cd.dishID
                             inner join Category c on cd.categoryID = c.categoryID
                             inner join CateShop cs on c.categoryID = cs.categoryID
                             inner join Shop s on cs.shopID = s.shopID
                             where s.shopID = " + shop + " and c.categoryID = "+ categoryID;
            DBHelper.OpenConnection();
            MySqlDataReader reader = DBHelper.ExecQuery(query);
            Category category = null;
            List<Category> categories = new List<Category>();
            while(reader.Read())
            {
                category = GetDishofCate(reader);
                categories.Add(category);
            }
            DBHelper.CloseConnection();
            return categories;
        }
        public void InsertCate(Category cate)
        {
          string query = $"insert Category(categoryID ,categoryName) values('{cate.CategoryID}','{cate.CategoryName}')";
          Console.WriteLine(query);
        
          DBHelper.OpenConnection();
          MySqlDataReader reader = DBHelper.ExecQuery(query);
          DBHelper.CloseConnection();
        }
        public void SaveCate(Category cate, int shop)
        {
           string query = $"insert CateShop(categoryID, shopID) values('{cate.CategoryID}','{shop}')";
        
           DBHelper.OpenConnection();
           MySqlDataReader reader = DBHelper.ExecQuery(query);
           DBHelper.CloseConnection();
        }
        public List<Category> GetCateID()
        {
           string query = @"select categoryID from Category";
        
           DBHelper.OpenConnection();
           MySqlDataReader reader = DBHelper.ExecQuery(query);
           Category categories = null;
           List<Category> catelist = new List<Category>();
           while(reader.Read())
           {
              categories = GetCateID(reader);
              catelist.Add(categories);
           }
           DBHelper.CloseConnection();
           return catelist;
        }
        public void EditCate(Category cate)
        {
           string query = $"update Category set categoryName = {cate.CategoryName} where categoryID = {cate.CategoryID}";
        
           DBHelper.OpenConnection();
           MySqlDataReader reader = DBHelper.ExecQuery(query);
           DBHelper.CloseConnection();
        }
        public List<Category> DisplayDetailDish(Category cate, int shop)
        {
            string query = @"select ds.dishID,ds.dishName ,ds.amount, ds.unit_price, ds.date_of_manufacture, ds.expiry from Dish ds
                             inner join CateDish cd on ds.dishID = cd.dishID
                             inner join Category c on cd.categoryID = c.categoryID
                             inner join CateShop cs on c.categoryID = cs.categoryID
                             inner join Shop s on cs.shopID = s.shopID
                             where s.shopID = " + shop +" and c.categoryName = " + cate.CategoryName;
           DBHelper.OpenConnection();
           MySqlDataReader reader = DBHelper.ExecQuery(query);
           Category categories = null;
           List<Category> catelist = new List<Category>();
           while(reader.Read())
           {
              categories = GetDishofCategory(reader);
              catelist.Add(categories);
           }
           DBHelper.CloseConnection();
           return catelist;               
        }
        public void UpdateDishAtDishName(Category cate)
        {
           string query = $"update Dish set dishName = {cate.DishName} where dishID = {cate.DishID}";
        
           DBHelper.OpenConnection();
           MySqlDataReader reader = DBHelper.ExecQuery(query);
           DBHelper.CloseConnection();
        }
        public void UpdateDishAtAmount(Category cate)
        {
           string query = $"update Dish set amount = {cate.Amount} where dishID = {cate.DishID}";
        
           DBHelper.OpenConnection();
           MySqlDataReader reader = DBHelper.ExecQuery(query);
           DBHelper.CloseConnection();
        }
        public void UpdateDishAtPrice(Category cate)
        {
           string query = $"update Dish set unit_price = {cate.Price} where dishID = {cate.DishID}";
        
           DBHelper.OpenConnection();
           MySqlDataReader reader = DBHelper.ExecQuery(query);
           DBHelper.CloseConnection();
        }
        public void UpdateDishAtManufacture(Category cate)
        {
           string query = $"update Dish set date_of_manufacture = {cate.DateofManufacture} where dishID = {cate.DishID}";
        
           DBHelper.OpenConnection();
           MySqlDataReader reader = DBHelper.ExecQuery(query);
           DBHelper.CloseConnection();
        }
        public void UpdateDishAtExpiry(Category cate)
        {
           string query = $"update Dish set expiry = {cate.Expiry} where dishID = {cate.DishID}";
        
           DBHelper.OpenConnection();
           MySqlDataReader reader = DBHelper.ExecQuery(query);
           DBHelper.CloseConnection();
        }
    }
}