using BL;
using Persistence;
using ConsoleTables;

namespace Presentation
{
    public class Menu
    {
        ManageOrder mo = new ManageOrder();
        ManagementRevenue mr = new ManagementRevenue();
        ManagementDish md = new ManagementDish();
        public void MainMenu(int shop)
        {
            Console.Clear();
            SalesmanBL salesmanBL = new SalesmanBL();
            List<Salesman> shopname = salesmanBL.GetShopName(shop);
            if(shopname != null)
            {
                foreach(Salesman s in shopname)
                {
                    if(shop == s.ShopID)
                    {
                        string? name = s.ShopName;
                        Console.WriteLine(name.ToUpper());
                        break;
                    }
                }
            }
            Console.WriteLine();
            while (true)
            {
                int choice;
                Console.WriteLine("------------------------");
                Console.WriteLine("|        MENU           |");
                Console.WriteLine("------------------------");
                Console.WriteLine("| 1. DISHES MANAGEMENT  |");
                Console.WriteLine("------------------------");
                Console.WriteLine("| 2. ORDERS MANAGEMENT  |");
                Console.WriteLine("------------------------");
                Console.WriteLine("| 3. REVENUE MANAGEMENT |");
                Console.WriteLine("------------------------");
                Console.Write("YOUR CHOICE : ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                       md.ManagementDishes(shop);
                       break;
                    case 2:
                       mo.ManagenmentOrder(shop); 
                       break;
                    case 3:
                       mr.ManagenmentRevenue(shop);
                        break;
                    default:
                      Console.WriteLine("Choose 1-3");
                      break;
                }
            }
            
        }
    }
}