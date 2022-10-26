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
                       SearchRevenueMonth(shop);
                       break;
                      case 3:
                      Menu m = new Menu();
                      m.MainMenu(shop);
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
                do
                {
                    Console.Clear();
                    Console.Write("Date: ");
                    DateTime dates;
                    string? input = Console.ReadLine(); 
                    if(String.IsNullOrEmpty(input.Trim()) || input.Length != 10)
                    {
                        SearchRevenueDay(shop);
                    }
                    else
                    {
                       DateTime.TryParse(input, out dates);
                       RevenueBL revenueBL = new RevenueBL();
                       List<Revenue> revenues = revenueBL.GetRevenueByDates(dates,shop);
                       bool result = false;
                       if(revenues != null)
                       {
                          foreach(Revenue revenue in revenues)
                          {
                            if(dates == revenue.Dates)
                            {
                                result = true;
                                var table = new ConsoleTable("DATE","TOTAL DISHES SOLD","REVENUE OF DAY");
                                table.AddRow(revenue.Dates.ToString("yyyy-MM-dd"),revenue.Sold,revenue.Sum_Revenue_Day);
                                table.Write();
                                Console.WriteLine();
                            }
                          }
                        
                          if(result == false)
                          {
                              Console.WriteLine("Not found result !");
                          }
                       }
                        Console.WriteLine("Do you want to continue ? (press 'y' to continue, 'n' to exit)");
                        char check = Convert.ToChar(Console.ReadLine());
                        if(check == 'n')
                        {
                            ManagenmentRevenue(shop);
                        }
                    }
                } while(true) ;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void SearchRevenueMonth(int shop)
        {
            try
            {
                do
                {
                    Console.Clear();
                    Console.Write("Month : ");
                    string? month = Convert.ToString(Console.ReadLine());
                    Console.Write("Year : ");
                    string? year = Convert.ToString(Console.ReadLine());
                    if(String.IsNullOrEmpty(month) || String.IsNullOrEmpty(year) || year.Length != 4)
                    {
                        Console.WriteLine("Not null / Define not sure. Try again");
                        Thread.Sleep(1000);
                        SearchRevenueMonth(shop);
                    }
                    else
                    {
                        if(month.Length == 1)
                        {
                            month = "0" + month;
                        }
                        bool result = false;
                        RevenueBL revenueBL = new RevenueBL();
                        List<Revenue> revenues = revenueBL.GetRevenueByMonth(month,shop,year);
                        if(revenues != null)
                        {
                            foreach(Revenue revenue in revenues)
                            {
                               var table = new ConsoleTable("MONTH","TOTAL DISHES SOLD","REVENUE OF MONTH");
                               if(month == revenue.Dates.ToString("yyyy-MM-dd").Substring(5,2))
                               {
                                   result = true;
                                   table.AddRow(revenue.Dates,revenue.Sold,revenue.Sum_Revenue_Month);
                                   table.Write();
                                   Console.WriteLine();
                               }                          
                            }
                            if(result == false)
                            {
                                Console.WriteLine("Not found result");
                            }
                        }
                        Console.WriteLine("Do you want to continue ? (press 'y' to continue, 'n' to exit)");
                        char check = Convert.ToChar(Console.ReadLine());
                        if(check == 'n')
                        {
                            ManagenmentRevenue(shop);
                        }
                    }
                } while (true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}