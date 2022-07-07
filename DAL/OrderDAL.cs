using Persistence;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class OrderDAL
    {
        public Order GetOrder(MySqlDataReader reader)
        {
            Order orders = new Order();
            orders.OrderId = reader.GetInt32("orderID");
            orders.Dates = reader.GetDateTime("dates");
            orders.Payment_Method = reader.GetString("payment_method");
            orders.Customer_Name = reader.GetString("fullname");
            orders.Salesman_Name = reader.GetString("fullname");
            orders.Dish_Name = reader.GetString("dishName");
            orders.Quantity = reader.GetInt32("quantity");
            orders.Total = reader.GetDouble("total");
            return orders;
        }
        public Order GetOrderByDates(DateTime date, int shop)
        {
            string query = @"select ord.orderID, ord.dates, c.fullname,sl.fullname, ds.dishName,ds.unit_price, ort.quantity, sum(ds.unit_price * ort.quantity) as total from Shop s
                             inner join Salesmans sl on s.shopID = sl.shopID
                             inner join Orders ord on sl.salesmanID = ord.salesmanID 
                             inner join Customers c on ord.customerID = c.customerId
                             inner join OrderDetail ort on ord.orderID = ort.orderID
                             inner join Dish ds on ort.dishID = ds.dishID 
                             where s.shopID = " + shop + "and ord.dates = " + date + "group by ord.orderID order by sum(ds.unit_price * ort.quantity)" ;
                            
            DBHelper.OpenConnection();
            MySqlDataReader reader = DBHelper.ExecQuery(query);
            Order orders = null;
            if(reader.Read())
            {
                orders = GetOrder(reader);
            }
            DBHelper.CloseConnection();
            return orders;
        }
    }
}

