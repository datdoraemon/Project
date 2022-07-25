using Persistence;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class CategoryDAL : DishDAL
    {
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
    }
}