using Persistence;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class RevenueDAL : SalesmanDAL
    {
        public Revenue GetRevenueByDay(MySqlDataReader reader)
        {
            Revenue revenue = new Revenue();
            revenue.Dates = reader.GetDateTime("dates");
            revenue.Sold = reader.GetInt32("Amount");
            revenue.Count = reader.GetInt32("Total_order");
            revenue.Sum_Revenue_Day = reader.GetDouble("Revenue_of_day");
            return revenue;
        }
        public Revenue GetRevenueByMonth(MySqlDataReader reader)
        {
            Revenue revenue = new Revenue();
            revenue.Dates = reader.GetDateTime("dates");
            revenue.Sold = reader.GetInt32("Amount");
            revenue.Count = reader.GetInt32("Total_order");
            revenue.Sum_Revenue_Month = reader.GetDouble("Revenue_of_month");
            return revenue;
        }
        public List<Revenue> GetRevenueDay(DateTime dates, int shop)
        {
            string query = @"select ord.dates, count(ord.orderID) as 'Total_order', sum(ort.quantity) as 'Amount', sum(ort.quantity * ds.unit_price) as 'Revenue_of_day' from Dish ds
                             inner join OrderDetail ort on ds.dishID = ort.dishID
                             inner join Orders ord on ort.orderID = ord.orderID
                             inner join Salesmans sl on ord.salesmanID = sl.salesmanID
                             inner join Shop s on sl.salesmanID = s.shopID
                             where s.shopID = " + shop + " and ort.statuses = 'Da thanh toan' and ord.dates = '" + dates.ToString("yyyy-MM-dd") +
                             "' group by ort.quantity * ds.unit_price and ord.orderID order by Revenue_of_day and Total_order";
                    
            DBHelper.OpenConnection();
            MySqlDataReader reader = DBHelper.ExecQuery(query);
            Revenue revenue = null;
            List<Revenue> revenueList = new List<Revenue>();
            while(reader.Read())
            {
                revenue = GetRevenueByDay(reader);
                revenueList.Add(revenue);
            }
            DBHelper.CloseConnection();
            return revenueList;           
        }
        public List<Revenue> GetRevenueMonth(string month, int shop)
        {
            string query = @"select ord.dates, count(ord.orderID) as 'Total_order', sum(ort.quantity) as 'Amount', sum(ort.quantity * ds.unit_price) as 'Revenue_of_month' from Dish ds
                             inner join OrderDetail ort on ds.dishID = ort.dishID
                             inner join Orders ord on ort.orderID = ord.orderID
                             inner join Salesmans sl on ord.salesmanID = sl.salesmanID
                             inner join Shop s on sl.salesmanID = s.shopID
                             where s.shopID = " + shop + " and ort.statuses = 'Da thanh toan' and month(ord.dates) = '" + month +
                             "' group by ort.quantity * ds.unit_price and ord.orderID order by Revenue_of_month and Total_order";
                             
            DBHelper.OpenConnection();
            MySqlDataReader reader = DBHelper.ExecQuery(query);
            Revenue revenue = null;
            List<Revenue> revenueList = new List<Revenue>();
            while(reader.Read())
            {
                revenue = GetRevenueByMonth(reader);
                revenueList.Add(revenue);
            }
            DBHelper.CloseConnection();
            return revenueList;                   
        }
    }
}