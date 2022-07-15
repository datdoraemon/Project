using Persistence;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DAL
{
    public class OrderDAL
    {
        public Order GetOrder(MySqlDataReader reader)
        {
            Order order = new Order();
            order.OrderId = reader.GetInt32("orderID");
            order.Dates = reader.GetDateTime("dates");
            order.Payment_Method = reader.GetString("payment_method");
            order.Customer_Name = reader.GetString("fullname");
            order.Salesman_Name = reader.GetString("salesmanName");
            order.Dish_Name = reader.GetString("dishName");
            order.Quantity = reader.GetInt32("quantity");
            order.Total = reader.GetDouble("total");
            order.Status = reader.GetString("statuses");
            return order;
        }
        public List<Order> GetOrderByDates(DateTime date, int shop)
        {
            
            string query = @"select ord.orderID, ord.dates, c.fullname,sl.salesmanName, ds.dishName,ds.unit_price, ort.quantity,ord.payment_method, ds.unit_price * ort.quantity as total, ort.statuses from Shop s
                             inner join Salesmans sl on s.shopID = sl.shopID
                             inner join Orders ord on sl.salesmanID = ord.salesmanID 
                             inner join Customers c on ord.customerID = c.customerId
                             inner join OrderDetail ort on ord.orderID = ort.orderID
                             inner join Dish ds on ort.dishID = ds.dishID 
                             where s.shopID = " + shop + " and ord.dates = '" + date.ToString("yyyy-MM-dd") + 
                             "' group by ord.orderID order by ds.unit_price * ort.quantity" ;

            DBHelper.OpenConnection();
            MySqlDataReader reader = DBHelper.ExecQuery(query);
            Order order = null;
            List<Order> oredrLisst = new List<Order>();
            while(reader.Read())
            {
                order = GetOrder(reader);
                oredrLisst.Add(order);
            }
            DBHelper.CloseConnection();
            return oredrLisst;
        }
        public List<Order> GetOrderByDish(string dishName, int shop)
        {
            
            string query = @"select ord.orderID, ord.dates, c.fullname,sl.salesmanName, ds.dishName,ds.unit_price, ort.quantity,ord.payment_method, ds.unit_price * ort.quantity as total, ort.statuses from Shop s
                             inner join Salesmans sl on s.shopID = sl.shopID
                             inner join Orders ord on sl.salesmanID = ord.salesmanID 
                             inner join Customers c on ord.customerID = c.customerId
                             inner join OrderDetail ort on ord.orderID = ort.orderID
                             inner join Dish ds on ort.dishID = ds.dishID 
                             where s.shopID = " + shop + " and ds.dishName like '%" + dishName + 
                             "%' group by ord.orderID order by ds.unit_price * ort.quantity" ;
            
            DBHelper.OpenConnection();
            MySqlDataReader reader = DBHelper.ExecQuery(query);
            Order order = null;
            List<Order> oredrLisst = new List<Order>();
            while(reader.Read())
            {
                order = GetOrder(reader);
                oredrLisst.Add(order);
            }
            DBHelper.CloseConnection();
            return oredrLisst;
        }
        public List<Order> GetOrderByStatus(string status, int shop)
        {
            
            string query = @"select ord.orderID, ord.dates, c.fullname,sl.salesmanName, ds.dishName,ds.unit_price, ort.quantity,ord.payment_method, ds.unit_price * ort.quantity as total, ort.statuses from Shop s
                             inner join Salesmans sl on s.shopID = sl.shopID
                             inner join Orders ord on sl.salesmanID = ord.salesmanID 
                             inner join Customers c on ord.customerID = c.customerId
                             inner join OrderDetail ort on ord.orderID = ort.orderID
                             inner join Dish ds on ort.dishID = ds.dishID 
                             where s.shopID = " + shop + " and ort.statuses = '" + status + "' group by ord.orderID order by ds.unit_price * ort.quantity" ; 
                                
            DBHelper.OpenConnection();
            MySqlDataReader reader = DBHelper.ExecQuery(query);
            Order order = null;
            List<Order> oredrLisst = new List<Order>();
            while(reader.Read())
            {
                order = GetOrder(reader);
                oredrLisst.Add(order);
            }
            DBHelper.CloseConnection();
            return oredrLisst;
        }
    }
}

