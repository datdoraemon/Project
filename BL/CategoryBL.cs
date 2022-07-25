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
        public void EditCate(Category cate)
        {
            categoryDAL.EditCate(cate);
        }
        public List<Category> DisplayDishofCate(Category cate,int shop)
        {
            List<Category> categories = categoryDAL.DisplayDetailDish(cate, shop);
            return categories;
        }
        public void UpdateName(Category cate)
        {
            categoryDAL.UpdateDishAtDishName(cate);
        }
        public void UpdateAmount(Category cate)
        {
            categoryDAL.UpdateDishAtAmount(cate);
        }
        public void UpdatePrice(Category cate)
        {
            categoryDAL.UpdateDishAtPrice(cate);
        }
        public void UpdateManufacture(Category cate)
        {
            categoryDAL.UpdateDishAtManufacture(cate);
        }
        public void UpdateExpiry(Category cate)
        {
            categoryDAL.UpdateDishAtExpiry(cate);
        }
    }
}