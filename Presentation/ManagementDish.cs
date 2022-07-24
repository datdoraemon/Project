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
                       DisplayAllDish();
                       break;
                      case 3:
                       
                       break;
                      case 4:
                       
                       break;
                      case 5:
                       DisplayAllCategory();
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
                   Random random = new Random();
                   Dish dishes = new Dish();
                   DishBL dishBL = new DishBL();
                   
                   Console.Write("Shop: ");
                   int shop = Convert.ToInt32(Console.ReadLine());
                   List<Dish> listdish = dishBL.GetDishID(shop);
                   int x = random.Next(25 ,500);
                   foreach(Dish dish in listdish)
                   {
                       if(x == dish.DishID)
                       {
                           while(x == dish.DishID)
                           {
                               x = random.Next(25 ,500); 
                               if(x != dish.DishID)
                               {
                                  dishes.DishID = x;
                                   break;
                               }  
                           }
                       }
                       else
                       {
                          dishes.DishID = x;
                       }
                   }
                
                   Console.WriteLine("Dish ID : "+ dishes.DishID);
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
                       dishBL.InsertDish(dishes,shop);
                       dishBL.SaveDish(dishes,shop);
                       Console.WriteLine("Add dish success");
                       Console.Write("Do you want to add else dish : ");
                       char key = Convert.ToChar(Console.ReadLine());
                       if(key == 'y')
                       {
                           InsertDish();
                       }
                       
                   }
                }
            }
            catch
            {

            }
        }
        public void DisplayAllDish()
        {
                while(true)
                {
                    Console.WriteLine("Shop: ");
                    int shop = Convert.ToInt32(Console.ReadLine());

                    DishBL dishBL = new DishBL();
                    List<Dish> dishes = dishBL.GetAllDish(shop);
                    if(dishes != null)
                    {
                        Console.Clear();
                        var table = new ConsoleTable("DISH ID","DISH NAME","AMOUNT","PRICE","DATE OF MANUFACTURE","EXPIRY");
                        foreach(Dish dish in dishes)
                        {
                            table.AddRow(dish.DishID, dish.DishName, dish.Amount, dish.Price, dish.DateofManufacture, dish.Expiry);  
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
        public void DisplayAllCategory()
        {
            while(true)
            {
                Console.WriteLine("Shop: ");
                int shop = Convert.ToInt32(Console.ReadLine());

                CategoryBL categoryBL = new CategoryBL();
                List<Category> categories = categoryBL.GetAllCategory(shop);
                if(categories != null)
                {
                    Console.Clear();
                    var table = new ConsoleTable("CATEGORY ID","CATEGORY NAME");
                    foreach(Category category in categories)
                    {
                        table.AddRow(category.CategoryID,category.CategoryName);  
                    }
                        
                    table.Write();
                    Console.WriteLine();

                    Console.WriteLine("Do you want to see dishes of category ? (press 'y' to continue, 'n' to exit)");
                    char check = Convert.ToChar(Console.ReadLine());
                    if(check == 'n')
                    {
                        break;
                    }
                    else
                    {
                        DisplayDishofCategory();
                    }
                }
            }
        }
        public void DisplayDishofCategory()
        {
            Console.WriteLine("Shop: ");
            int shop = Convert.ToInt32(Console.ReadLine());
            Console.Write("What do you want to see category ? (Input CategoryID) : ");
            int categoryID = Convert.ToInt32(Console.ReadLine());
            Category category = new Category();
            CategoryBL categoryBL = new CategoryBL();
            List<Category> categories = categoryBL.GetDishofCate(shop,categoryID);
            
            if(categories != null)
            {
                Console.Clear();

                var table = new ConsoleTable("CATEGORY ID","DISH ID","DISH NAME");
                foreach(Category categori in categories)
                {
                    if(categoryID == categori.CategoryID)
                    {
                        table.AddRow(categori.CategoryID ,categori.DishID, categori.DishName);  
                    }
                }
                        
                table.Write();
                Console.WriteLine();
            }
        }
    }
}