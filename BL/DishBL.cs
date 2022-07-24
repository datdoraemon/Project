using Persistence;
using DAL;

namespace BL
{
    public class DishBL
    {
        private DishDAL dishDAL;

        public DishBL()
        {
            dishDAL = new DishDAL();
        }
        public List<Dish> GetAllDish(int shop)
        {
            List<Dish> dishes = dishDAL.GetAllDish(shop);
            return dishes;
        }
        public void InsertDish(Dish dish, int shop)
        {
            dishDAL.InsertDish(dish,shop);
        }
        public void SaveDish(Dish dish, int shop)
        {
            dishDAL.SaveDish(dish,shop);
        }
        public List<Dish> GetDishID(int shop)
        {
            List<Dish> dishes = dishDAL.GetDishID(shop);
            return dishes;
        }
    }
}