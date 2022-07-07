using Persistence;
using DAL;

namespace BL
{
    public class OrderBL
    {
        private OrderDAL orderDAL;

        public OrderBL()
        {
            orderDAL = new OrderDAL();
        }
        public Order GetOrderByDates(DateTime date, int shop)
        {
            Order order = orderDAL.GetOrderByDates(date,shop);
            return order;
        }
    }
}
