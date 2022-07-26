using BL;
using Persistence;
using ConsoleTables;

namespace Presentation
{
    public class ManagementRevenue
    {
        public void ManagenmentRevenue(int shop)
        {
            try
            {
               while(true)
               {
                   Console.Clear();
                   int choice;
                   var table = new ConsoleTable("REVENUE MANAGEMENT");
                   table.AddRow("1.REVENUE BY DAY");
                   table.AddRow("2.REVENUE BY MONTH");
                   table.AddRow("3.BACK TO MAIN MENU");
                   table.Write();
                   Console.WriteLine();

                   Console.Write("YOUR CHOICE : ");
                   choice = Convert.ToInt32(Console.ReadLine());
                   switch(choice)
                   {
                      case 1:
                       SearchRevenueDay(shop);
                       break;
                      case 2:
                       SearchRevenueMonth();
                       break;
                      case 3:
                      bool test = false;
                      if(test == false)
                      {
                         break;
                      }
                      break;
                      default:
                      Console.WriteLine("Choose 1-3");
                      break;
                   }
                   break;
               }
            }
            catch(Exception e)
            {
              Console.WriteLine(e.Message);
            }
        }
        public void SearchRevenueDay(int shop)
        {
            try
            {
                while(true)
                {
                    Console.WriteLine("Date: ");
                    DateTime dates = Convert.ToDateTime(Console.ReadLine());
                    RevenueBL revenueBL = new RevenueBL();
                    List<Revenue> revenues = revenueBL.GetRevenueByDates(dates,shop);
                    if(revenues != null)
                    {
                        var table = new ConsoleTable("DATE","AMOUNT ORDER IN DAY","TOTAL DISHES SOLD","REVENUE OF DAY");
                        foreach(Revenue revenue in revenues)
                        {
                           if(dates == revenue.Dates)
                           {
                              table.AddRow(revenue.Dates,revenue.Count,revenue.Sold,revenue.Sum_Revenue_Day);
                           }
                           else
                           {
                              Console.WriteLine("No result.");
                           }
                        }
                        table.Write();
                        Console.WriteLine();

                        Console.WriteLine("Do you want to continue ? (press 'y' to continue, 'n' to exit)");
                        char check = Convert.ToChar(Console.ReadLine());
                        if(check == 'n')
                        {
                           break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void SearchRevenueMonth()
        {
            try
            {
                while(true)
                {
                    Console.WriteLine("Shop: ");
                    int shop = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Month : ");
                    string month = Convert.ToString(Console.ReadLine());
                    if(month.Length == 1)
                    {
                        month = "0" + month;
                    }
                    RevenueBL revenueBL = new RevenueBL();
                    List<Revenue> revenues = revenueBL.GetRevenueByMonth(month,shop);
                    if(revenues != null)
                    {
                        var table = new ConsoleTable("MONTH","AMOUNT ORDER IN MONTH","TOTAL DISHES SOLD","REVENUE OF MONTH");
                        foreach(Revenue revenue in revenues)
                        {
                           if(month == revenue.Dates.ToString("yyyy-MM-dd").Substring(5,2))
                           {
                              table.AddRow(revenue.Dates,revenue.Count,revenue.Sold,revenue.Sum_Revenue_Month);
                           }
                           else
                           {
                              Console.WriteLine("No result.");
                           }
                        }
                        table.Write();
                        Console.WriteLine();
                        
                        Console.WriteLine("Do you want to continue ? (press 'y' to continue, 'n' to exit)");
                        char check = Convert.ToChar(Console.ReadLine());
                        if(check == 'n')
                        {
                           break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}