using BL;
using Persistence;
using ConsoleTables;

namespace Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
             Console.WriteLine("Shop: ");
             int shop = Convert.ToInt32(Console.ReadLine());
             Console.WriteLine("Date: ");
             DateTime date = Convert.ToDateTime(Console.ReadLine());
             OrderBL orderBL = new OrderBL();
             Order ord = orderBL.GetOrderByDates(date,shop);
             if(ord != null)
             {
                 var table = new ConsoleTable("ORDER ID","DATE","CUSTOMER NAME","SELLER","DISH","AMOUNT","TOTAL");
                 table.AddRow(ord.OrderId,ord.Dates,ord.Customer_Name,ord.Salesman_Name,ord.Dish_Name,ord.Quantity,ord.Total);
                 table.Write();
                 Console.WriteLine();

                 var row = Enumerable.Repeat(new OrderBL(), 30);
                 ConsoleTable.From<OrderBL>(row)
                             .Configure(o => o.NumberAlignment = Alignment.Right)
                             .Write(Format.Alternative);
                 Console.ReadKey();
             }
        }
    }   
}