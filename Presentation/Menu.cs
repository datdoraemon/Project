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
                var table = new ConsoleTable("MENU");
                table.AddRow("1. Management Dishes");
                table.AddRow("2. Management Orders");
                table.AddRow("3. Revenue Management");
                table.Write();
                Console.WriteLine();
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