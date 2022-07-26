using Persistence;
using DAL;

namespace BL
{
    public class SalesmanBL
    {
        private SalesmanDAL salesmanDAL;

        public SalesmanBL()
        {
            salesmanDAL = new SalesmanDAL();
        }
        public List<Salesman> Salesmen(int shop)
        {
            List<Salesman> sales = salesmanDAL.GetSales(shop);
            return sales;
        }
        public List<Salesman> GetUserNAme(string username)
        {
            List<Salesman> sales = salesmanDAL.GetUserName(username);
            return sales;
        }
        public List<Salesman> GetPassword()
        {
            List<Salesman> password = salesmanDAL.GetPassword();
            return password;
        }
    }
}