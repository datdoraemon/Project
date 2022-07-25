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
                   table.AddRow("4. DISPLAY ALL CATEGORIES");
                   table.AddRow("5. BACK TO MAIN MENU");
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
                       DisplayAllCategory();
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
                   List<Dish> listdish = dishBL.GetDishID();
                   int x = random.Next(1 ,500);
                   foreach(Dish dish in listdish)
                   {
                       if(x == dish.DishID)
                       {
                           while(x == dish.DishID)
                           {
                               x = random.Next(1 ,500); 
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
                       dishBL.InsertDish(dishes);
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

                    Console.WriteLine("Do you want to add category ? (press 'y' to continue, 'n' to exit)");
                    char check = Convert.ToChar(Console.ReadLine());
                    if(check == 'n')
                    {
                        break;
                    }
                    else
                    {
                        InsertCate();
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
        public void InsertCate()
        {
            try
            {
                while(true)
                {
                   Console.Clear();
                   Random random = new Random();
                   Category category = new Category();
                   CategoryBL cateBL = new CategoryBL();
                   
                   Console.Write("Shop: ");
                   int shop = Convert.ToInt32(Console.ReadLine());
                   List<Category> catelist = cateBL.GetCateID();
                   int x = random.Next(1 ,50);
                   foreach(Category cate in catelist)
                   {
                       if(x == cate.CategoryID)
                       {
                           while(x == cate.CategoryID)
                           {
                               x = random.Next(1 ,500); 
                               if(x != cate.CategoryID)
                               {
                                  category.CategoryID = x;
                                   break;
                               }  
                           }
                       }
                       else
                       {
                          category.CategoryID = x;
                       }
                   }
                   Console.WriteLine("Category ID : "+ category.CategoryID);
                   Console.Write("Category Name: ");
                   category.CategoryName = Convert.ToString(Console.ReadLine());

                   Console.Write("Do you want to save this category ? (Input 'y' to save , 'n' to not save)");
                   char check = Convert.ToChar(Console.ReadLine());
                   if(check == 'y')
                   {
                       cateBL.InsertCate(category);
                       cateBL.SaveCate(category, shop);
                       Console.WriteLine("Add dish success");
                       Console.Write("Do you want to add else dish : ");
                       char key = Convert.ToChar(Console.ReadLine());
                       if(key == 'y')
                       {
                           InsertCate();
                       }  
                   }
                }
            }
            catch
            {

            }
        }
    }
}