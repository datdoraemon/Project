using Persistence;
using DAL;

namespace BL
{
    public class RevenueBL
    {
        private RevenueDAL revenueDAL;

        public RevenueBL()
        {
            revenueDAL = new RevenueDAL();
        }
        public List<Revenue> GetRevenueByDates(DateTime date, int shop)
        {
           List<Revenue> revenue = revenueDAL.GetRevenueDay(date,shop);
            return revenue;
        }
        public List<Revenue> GetRevenueByMonth(string month, int shop)
        {
           List<Revenue> revenue = revenueDAL.GetRevenueMonth(month,shop);
            return revenue;
        }
    }
}