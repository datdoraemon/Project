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
        public void InsertDish(Dish dish)
        {
            dishDAL.InsertDish(dish);
        }
        public int DishIDMax()
        {
            int maxid = dishDAL.DishIDMax();
            return maxid;
        }
    }
}