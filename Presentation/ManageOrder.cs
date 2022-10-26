using BL;
using Persistence;
using ConsoleTables;
using static System.Math;

namespace Presentation
{
    public class ManageOrder
    {
        public void ManagenmentOrder(int shop)
        {
            while(true)
            {
                Console.Clear();
                int choice;
      
                var table = new ConsoleTable("MANAGEMENT ORDER");
                table.AddRow("1. SEARCH ORDERS BY DATE");
                table.AddRow("2. SEARCH ORDERS BY DISH NAME");
                table.AddRow("3. SEARCH ORDER BY STATUS");
                table.AddRow("4. BACK TO MAIN MENU.");
                table.Write();
                Console.WriteLine();
                Console.Write("YOUR CHOICE : ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                       SearchbyDate(shop);
                       break;
                    case 2:
                      SearchbyDishName(shop);
                      break;
                    case 3:
                      FillStatus(shop);
                      break;
                    case 4:
                      Menu m = new Menu();
                      m.MainMenu(shop);
                      break;
                    default:
                      Console.WriteLine("Choose 1-5");
                      break;
                }
                break;
            }
        }
        public void SearchbyDate(int shop)
        {
            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Date : ");
                    DateTime date;
                    string? input = Console.ReadLine();
                    if(String.IsNullOrEmpty(input) || input.Length != 10)
                    {
                        SearchbyDate(shop);
                    }
                    else
                    {
                        DateTime.TryParse(input,out date);
                        OrderBL orderBL = new OrderBL();
                        List<Order> orders = orderBL.GetOrderByDates(date,shop);
                        bool result = false;
                        if(orders != null)
                        {
                          var table = new ConsoleTable("ORDER ID","DATE","CUSTOMER NAME","SELLER","STATUS");
                          foreach(Order order in orders)
                          {
                            if(date == order.Dates)
                            {
                                result = true;
                                table.AddRow(order.OrderId,order.Dates.ToString("yyyy-MM-dd"),order.Customer_Name,order.Salesman_Name,order.Status);
                            }
                          }
                          table.Write();
                          Console.WriteLine();
                          if(result == false)
                          {
                              Console.WriteLine("Not found result !");
                          }

                          Console.WriteLine("Do you want to see order detail ? (press 'y' to continue, 'n' to exit)");
                          char check = Convert.ToChar(Console.ReadLine());
                          if(check == 'n')
                          {
                             Console.Write("Do yo want to continue searching");
                             ManagenmentOrder(shop);
                          }
                          else
                          {
                             OrderDetail(shop);
                          }
                        }
                    } 
                } while(true);               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void SearchbyDishName(int shop)
        {
            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Dish Name: ");
                    string? dish = Convert.ToString(Console.ReadLine());
                    OrderBL orderBL = new OrderBL();
                    List<Order> orders = orderBL.GetOrderByDishes(dish,shop);
                    bool result = false;
                    if (String.IsNullOrEmpty(dish))
                    {
                        SearchbyDishName(shop);
                    }
                    else
                    {
                        if(orders != null)
                        {
                            var table = new ConsoleTable("ORDER ID","DATE","CUSTOMER NAME","SELLER","STATUS");
                            foreach(Order order in orders)
                            {
                                if(dish == order.Dish_Name || order.Dish_Name.ToString().ToUpper().Contains(dish.ToUpper()))
                                {
                                    result = true;
                                    table.AddRow(order.OrderId,order.Dates.ToString("yyyy-MM-dd"),order.Customer_Name,order.Salesman_Name,order.Status);
                                }
                            } 
                            table.Write();
                            Console.WriteLine();
                            if(result == false)
                            {
                                Console.WriteLine("Not found result");
                            }
                            Console.WriteLine("Do you want to see order detail ? (press 'y' to continue, 'n' to exit)");
                            char check = Convert.ToChar(Console.ReadLine());
                            if(check == 'n')
                            {
                               Console.Write("Do yo want to continue searching");
                                ManagenmentOrder(shop);
                            }
                            else
                            {
                               OrderDetail(shop);
                            }
                        }   
                    }    
                } while(true);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void FillStatus(int shop)
        {
            try
            {
                while(true)
                {
                    Console.Clear();
                    string key;
                    Console.WriteLine("Do you want to see status of orders ? ");
                    Console.WriteLine("(press '1' to see status 'Da thanh toan'");
                    Console.WriteLine("       '2' to see status 'Dang giao'");
                    Console.WriteLine("       '3' to see status 'Don hang moi'");
                    Console.WriteLine("YOUR CHOICE : ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        Console.Write("abc");
                        key = "Da thanh toan";
                        SearchbyStatus(key,shop);
                        break;
                    }
                    if(choice == 2)
                    {
                        key = "Dang giao";
                        SearchbyStatus(key,shop);
                        break;
                    }
                    if(choice == 3)
                    {
                        key = "Don hang moi";
                        SearchbyStatus(key,shop);
                        break;
                    }
                }
            }
            catch (Exception e)
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
                    bool result = false;
                    if(orders != null)
                    {
                        var table = new ConsoleTable("ORDER ID","DATE","CUSTOMER NAME","SELLER","STATUS");
                        foreach(Order order in orders)
                        {
                            if(order.Status.ToString().ToUpper().Contains(status.ToUpper()))
                            {
                                result = true;
                                table.AddRow(order.OrderId,order.Dates.ToString("yyyy-MM-dd"),order.Customer_Name,order.Salesman_Name,order.Status);
                            }
                        }
                        table.Write();
                        Console.WriteLine();
                        if(result == false)
                        {
                            Console.WriteLine("Not found result");
                        }

                        Console.WriteLine("Do you want to see order detail ? (press 'y' to continue, 'n' to exit)");
                        char check = Convert.ToChar(Console.ReadLine());
                        if(check == 'n')
                        {
                            ManagenmentOrder(shop);
                        }
                        else
                        {
                            OrderDetail(shop);
                        }
                    } 
                }
             }
             catch(Exception e)
             {
                 Console.WriteLine(e.Message);
             }
        }
        public void OrderDetail(int shop)
        {
            while (true)
            {
                Console.Write("Input order ID : ");
                int orderid = Convert.ToInt32(Console.ReadLine());
                Order order = new Order();
                OrderBL orderBL = new OrderBL();
                List<Order> orders = orderBL.GetOrderDetail(orderid,shop);
                foreach(Order ord in orders)
                {
                    if(orderid == ord.OrderId)
                    {
                         Console.WriteLine();
                         Console.WriteLine("============================");
                         Console.WriteLine("       Order Detail         ");
                         Console.WriteLine("============================");
                         Console.WriteLine("Date : " + ord.Dates.ToString("yyyy-MM-dd"));
                         Console.WriteLine("Customer Name : " + ord.Customer_Name);
                         Console.WriteLine("Salesman : " + ord.Salesman_Name);
                         Console.WriteLine("Payment Method : " + ord.Payment_Method);
                         int j = 0 , i = 0;
                         double sum = 0;
                         double[] values = new double[20];
                         var table = new ConsoleTable("DISH NAME","AMOUNT","PRICE OF DISH ($)");
                         foreach(Order o in orders)
                         {
                            if(orderid == o.OrderId)
                            {
                                table.AddRow(o.Dish_Name,o.Quantity,o.Price);
                                values[i] = o.Price * o.Quantity;
                                i++;
                            }
                         }
                         table.Write();
                         Console.WriteLine();
                         for (j=0;j<i;j++)
                         {
                            sum = sum + values[j];
                         }
                         Console.WriteLine("Total : " + sum);
                         Console.WriteLine("Status : " + ord.Status);
                         Console.WriteLine("==============================");
                         break;
                    }
                }
                
                Console.Write("Do you want to change status ? (y / n) : ");
                char check = Convert.ToChar(Console.ReadLine());
                if(check == 'n')
                {
                    ManagenmentOrder(shop);
                }
                else
                {
                    UpdateStatus(orderid);
                    ManagenmentOrder(shop);
                }
            }
        }
        public void UpdateStatus(int orderid)
        {
            Order order = new Order();
            OrderBL orderBL = new OrderBL();
            Console.WriteLine("Input '1' - Dang giao , Input '2' - Da thanh toan");
            int choose = Convert.ToInt32(Console.ReadLine());
            if(choose == 1)
            {
                string status = "Dang giao";
                orderBL.UpdateStatus(status,orderid);
                Console.WriteLine("Update success !");
                Thread.Sleep(1000);
            }
            if(choose == 2)
            {
                string status = "Da thanh toan";
                orderBL.UpdateStatus(status,orderid);
                Console.WriteLine("Update success !");
                Thread.Sleep(1000);
            }
        }
    } 
}