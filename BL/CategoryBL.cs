using Persistence;
using DAL;

namespace BL
{
    public class CategoryBL : DishBL
    {
        private CategoryDAL categoryDAL;
        private DishDAL dishDAL;

        public CategoryBL()
        {
            categoryDAL = new CategoryDAL(); 
            dishDAL = new DishDAL();
        }
        public List<Category> GetAllCategory(int shop)
        {
            List<Category> categories = categoryDAL.GetAllCategory(shop);
            return categories;
        }
        public List<Category> GetDishofCate(int shop, int categoryID)
        {
            List<Category> categories = categoryDAL.GetAllDishofCate(shop,categoryID);
            return categories;
        }
    }
}