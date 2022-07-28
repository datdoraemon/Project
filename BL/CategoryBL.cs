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
        public void InsertCate(Category category)
        {
            categoryDAL.InsertCate(category);
        }
        public void SaveCate(Category cate, int shop)
        {
            categoryDAL.SaveCate(cate,shop);
        }
        public List<Category> GetCateID()
        {
            List<Category> categories = categoryDAL.GetCateID();
            return categories;
        }
        public void EditCate(string newname, int cateID)
        {
            categoryDAL.EditCate(newname,cateID);
        }
        public List<Category> DisplayDetailDishofCate(int shop, int key)
        {
            List<Category> categories = categoryDAL.DisplayDetailDish(shop ,key);
            return categories;
        }
        public void UpdateName(string check ,int key)
        {
            categoryDAL.UpdateDishAtDishName(check ,key);
        }
        public void UpdateAmount(int check,int key)
        {
            categoryDAL.UpdateDishAtAmount(check, key);
        }
        public void UpdatePrice(double check, int key)
        {
            categoryDAL.UpdateDishAtPrice(check,key);
        }
        public void UpdateManufacture(DateTime date,int key)
        {
            categoryDAL.UpdateDishAtManufacture(date,key);
        }
        public void UpdateExpiry(DateTime date,int key)
        {
            categoryDAL.UpdateDishAtExpiry(date,key);
        }
        public void InsertDishofCate(int dishID, int cateID)
        {
            categoryDAL.InsertDishToCate(dishID,cateID);
        }
    }
}