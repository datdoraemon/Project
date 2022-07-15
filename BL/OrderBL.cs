using Persistence;
using DAL;
using System.Collections.Generic;

namespace BL
{
    public class OrderBL
    {
        private OrderDAL orderDAL;

        public OrderBL()
        {
            orderDAL = new OrderDAL();
        }
        public List<Order> GetOrderByDates(DateTime date, int shop)
        {
           List<Order> orders = orderDAL.GetOrderByDates(date,shop);
            return orders;
        }
        public List<Order> GetOrderByDishes(string dishName, int shop)
        {
           List<Order> orders = orderDAL.GetOrderByDish(dishName,shop);
            return orders;
        }
        public List<Order> GetOrderByStatus(string status, int shop)
        {
           List<Order> orders = orderDAL.GetOrderByStatus(status,shop);
            return orders;
        }
    }
}
