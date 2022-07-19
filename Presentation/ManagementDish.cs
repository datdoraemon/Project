using BL;
using Persistence;
using ConsoleTables;

namespace Presentation
{
    public class ManagementDish
    {
        public void ManagementDishes()
        {
            try
            {
               while(true)
               {
                   Console.Clear();
                   int choice;
                   var table = new ConsoleTable("MANAGEMENT DISH");
                   table.AddRow("1. CREATE DISH");
                   table.AddRow("2. DISPLAY ALL DISHES");
                   table.AddRow("3. SEARCH DISH");
                   table.AddRow("4. CREATE CATEGORY");
                   table.AddRow("5. DISPLAY ALL CATEGORIES");
                   table.AddRow("6. BACK TO MAIN MENU");
                   table.Write();
                   Console.WriteLine();

                   Console.Write("YOUR CHOICE : ");
                   choice = Convert.ToInt32(Console.ReadLine());
                   switch(choice)
                   {
                      case 1:
                       InsertDish();
                       break;
                      case 2:
                       
                       break;
                      case 3:
                       
                       break;
                      case 4:
                       
                       break;
                      case 5:
                       
                       break;
                      case 6:
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
        public void InsertDish()
        {
            try
            {
                while(true)
                {
                   Dish dishes = new Dish();
                   DishBL dishBL = null;
                   Console.Write("Dish Name: ");
                   dishes.DishName = Convert.ToString(Console.ReadLine());
                   Console.Write("Amount: ");
                   dishes.Amount = Convert.ToInt32(Console.ReadLine());
                   Console.Write("Price : ");
                   dishes.Price = Convert.ToDouble(Console.ReadLine());
                   Console.Write("Date of manufacture : ");
                   dishes.DateofManufacture = Convert.ToDateTime(Console.ReadLine());
                   Console.Write("Expiry : ");
                   dishes.Expiry = Convert.ToDateTime(Console.ReadLine());

                   Console.Write("Do you want to add this dish ?");
                   char check = Convert.ToChar(Console.ReadLine());
                   if(check == 'y')
                   {
                       dishes.DishID = dishBL.DishIDMax();
                       Console.Write("Dish ID : " + dishes.DishID);
                       Console.ReadKey();
                       dishBL.InsertDish(dishes);
                       Console.WriteLine("Add dish success");
                       Console.ReadKey();
                   }
                }
            }
            catch
            {

            }
        }
        
    }
}