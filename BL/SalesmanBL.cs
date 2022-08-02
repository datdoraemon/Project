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
        public List<Salesman> GetUserNAme(string username)
        {
            List<Salesman> sales = salesmanDAL.GetUserName(username);
            return sales;
        }
        public List<Salesman> GetPassword(string md5)
        {
            List<Salesman> password = salesmanDAL.GetPassword(md5);
            return password;
        }
        public List<Salesman> GetShopName(int shop)
        {
            List<Salesman> shopname = salesmanDAL.GetShopName(shop);
            return shopname;
        }
    }
}