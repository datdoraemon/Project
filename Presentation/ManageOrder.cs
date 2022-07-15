using BL;
using Persistence;
using ConsoleTables;

namespace Presentation
{
    public class ManageOrder
    {
        public void ManagenmentOrder()
        {
            while(true)
            {
                Console.Clear();
                int choice;
      
                var table = new ConsoleTable("MANAGEMENT ORDER");
                table.AddRow("1. DISPLAY RECENTLY ORDER");
                table.AddRow("2. SEARCH ORDERS BY DATE");
                table.AddRow("3. SEARCH ORDERS BY DISH NAME");
                table.AddRow("4. SEARCH ORDER BY STATUS");
                table.AddRow("5. BACK TO MAIN MENU.");
                table.Write();
                Console.WriteLine();
                Console.Write("YOUR CHOICE : ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                       
                       break;
                    case 2:
                       SearchbyDate();
                       break;
                    case 3:
                      SearchbyDishName();
                      break;
                    case 4:
                      FillStatus();
                      break;
                    case 5:
                      bool test = false;
                      if(test == false)
                      {
                         break;
                      }
                      break;
                    default:
                      Console.WriteLine("Choose 1-5");
                      break;
                }
                break;
            }
        }
        public void SearchbyDate()
        {
            try
            {
                while(true)
                {
                    Console.WriteLine("Shop: ");
                    int shop = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Date: ");
                    DateTime date = Convert.ToDateTime(Console.ReadLine());
                    OrderBL orderBL = new OrderBL();
                    List<Order> orders = orderBL.GetOrderByDates(date,shop);
                    if(orders != null)
                    {
                        Console.Clear();
                        var table = new ConsoleTable("ORDER ID","DATE","CUSTOMER NAME","SELLER","DISH","AMOUNT","TOTAL","STATUS");
                        foreach(Order order in orders)
                        {
                            if(date == order.Dates)
                            {
                                table.AddRow(order.OrderId,order.Dates,order.Customer_Name,order.Salesman_Name,order.Dish_Name,order.Quantity,order.Total,order.Status);
                            }
                            else
                            {
                               Console.WriteLine("No Result.");
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
        public void SearchbyDishName()
        {
            try
             {
                while(true)
                {
                    Console.WriteLine("Shop: ");
                    int shop = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Dish Name: ");
                    string dish = Convert.ToString(Console.ReadLine());
                    OrderBL orderBL = new OrderBL();
                    List<Order> orders = orderBL.GetOrderByDishes(dish,shop);
                
                    if(orders != null)
                    {
                        Console.Clear();
                        var table = new ConsoleTable("ORDER ID","DATE","CUSTOMER NAME","SELLER","DISH","AMOUNT","TOTAL","STATUS");
                        foreach(Order order in orders)
                        {
                           if(dish == order.Dish_Name || order.Dish_Name.ToString().ToUpper().Contains(dish.ToUpper()))
                           {
                                table.AddRow(order.OrderId,order.Dates,order.Customer_Name,order.Salesman_Name,order.Dish_Name,order.Quantity,order.Total,order.Status);
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
             catch(Exception e)
             {
                 Console.WriteLine(e.Message);
             }
        }
        public void SearchbyStatus(string status ,int shop)
        {
            try
             {
                while(true)
                {
                    OrderBL orderBL = new OrderBL();
                    List<Order> orders = orderBL.GetOrderByStatus(status,shop);
                    if(orders != null)
                    {
                        var table = new ConsoleTable("ORDER ID","DATE","CUSTOMER NAME","SELLER","DISH","AMOUNT","TOTAL","STATUS");
                        foreach(Order order in orders)
                        {
                            if(order.Status.ToString().ToUpper().Contains(status.ToUpper()))
                            {
                                table.AddRow(order.OrderId,order.Dates,order.Customer_Name,order.Salesman_Name,order.Dish_Name,order.Quantity,order.Total,order.Status);
                            }
                            else
                            {
                               Console.WriteLine("No Result.");
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
                        else
                        {
                            FillStatus();
                        }
                    } 
                }
             }
             catch(Exception e)
             {
                 Console.WriteLine(e.Message);
             }
        }
        public void FillStatus()
        {
            try
            {
                while(true)
                {
                    string key;
                    Console.WriteLine("Shop: ");
                    int shop = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Do you want to see status of orders ? ");
                    Console.WriteLine("(press '1' to see status 'Da thanh toan', '2' to see status 'Dang giao') ");
                    Console.WriteLine("YOUR CHOICE : ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    
                    if (choice == 1)
                    {
                        key = "Da thanh toan";
                        SearchbyStatus(key,shop);
                    }
                    if(choice == 2)
                    {
                        key = "Dang giao";
                        SearchbyStatus(key,shop);
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