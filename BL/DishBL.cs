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
        public void InsertDish(Dish dish)
        {
            dishDAL.InsertDish(dish);
        }
        public void SaveDish(Dish dish, int shop)
        {
            dishDAL.SaveDish(dish,shop);
        }
        public List<Dish> GetDishID()
        {
            List<Dish> dishes = dishDAL.GetDishID();
            return dishes;
        }
    }
}