using BL;
using Persistence;
using ConsoleTables;

namespace Presentation
{
    public class ManagementDish 
    {
        public void ManagementDishes(int shop)
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
                       InsertDish(shop);
                       break;
                      case 2:
                       DisplayAllDish(shop);
                       break;
                      case 3:
                       Search(shop);
                       break;
                      case 4:
                       DisplayAllCategory(shop);
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
        public void InsertDish(int shop)
        {
            try
            {
                while(true)
                {
                   Random random = new Random();
                   Dish dishes = new Dish();
                   DishBL dishBL = new DishBL();
                   
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
                           InsertDish(shop);
                       }
                       else
                       {
                           ManagementDishes(shop);
                       }
                   }
                }
            }
            catch
            {

            }
        }
        public void DisplayAllDish(int shop)
        {
                while(true)
                {
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
                            ManagementDishes(shop);
                        }
                    }
                }
        }
        public void DisplayAllCategory(int shop)
        {
            while(true)
            {
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

                    MenuCategory(shop);
                }
            }
        }
        public void MenuCategory(int shop)
        {
            int choice;
            Console.WriteLine("=====================");
            Console.WriteLine("1. ADD CATEGORY");
            Console.WriteLine("2. EDIT CATEGORY");
            Console.WriteLine("3. DISPLAY DISHES OF CATEGORY");
            Console.WriteLine("4. BACK");
            Console.Write("YOUR CHOICE : ");
            choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                InsertCate(shop);
                break;
                case 2:
                EditCate(shop);
                break;
                case 3:
                DisplayDishofCategory(shop);
                break;
                case 4:
                ManagementDishes(shop);
                break;
                default:
                break;
            }
        }
        public void DisplayDishofCategory(int shop)
        {
            do
            {
                Console.Write("What do you want to see dishes of category ? (Input CategoryID) : ");
                int cateID = Convert.ToInt32(Console.ReadLine());
                Category category = new Category();
                CategoryBL categoryBL = new CategoryBL();
                List<Category> categories = categoryBL.GetDishofCate(shop,cateID);
            
                if(categories != null)
                {
                   Console.Clear();

                   var table = new ConsoleTable("CATEGORY ID","DISH ID","DISH NAME");
                   foreach(Category categori in categories)
                   {
                      if(cateID == categori.CategoryID)
                      {
                          table.AddRow(categori.CategoryID ,categori.DishID, categori.DishName);  
                      }
                      else
                      {
                         Console.Write("Not found result !");
                         break;
                      }
                   }
                        
                    table.Write();
                    Console.WriteLine();
                }
                Console.WriteLine("====================");
                Console.WriteLine("1. ADD DISH TO CATEGORY");
                Console.WriteLine("2. DISPLAY INFORMATION DETAIL OF DISH");
                Console.WriteLine("3. BACK");
                Console.Write("YOUR CHOICE : ");
                int num = Convert.ToInt32(Console.ReadLine());
                switch(num)
                {
                    case 1:
                    InsertDishToCate(cateID,shop);
                    break;
                    case 2:
                    DisplayDetailDish(shop);
                    break;
                    case 3:
                    ManagementDishes(shop);
                    break;
                    default:
                    Console.Write("Input 1-3");
                    break;
                }
            } while(true);
        }
        public void InsertCate(int shop)
        {
            try
            {
                while(true)
                {
                   Console.Clear();
                   Random random = new Random();
                   Category category = new Category();
                   CategoryBL cateBL = new CategoryBL();
                   
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
                       if(key == 'n')
                       {
                          ManagementDishes(shop);
                       }  
                   }
                }
            }
            catch
            {

            }
        }
        public void EditCate(int shop)
        {
            try
            {
               while(true)
               {
                   Category category = new Category();
                   Console.WriteLine("What do you want to edit ? (Input categoryID)");
                   int cateID = Convert.ToInt32(Console.ReadLine());
                   Console.Write("New category name is : "); 
                   category.CategoryName = Convert.ToString(Console.ReadLine());
                   Console.Write("Do you want to save this change ? (Input 'y' to save, 'n' to not save)");
                   char key = Convert.ToChar(Console.ReadLine());
                   if(key == 'y')
                   {
                       CategoryBL categoryBL = new CategoryBL();
                       categoryBL.EditCate(category);
                       Console.WriteLine("Update success !");
                   }
                   Console.WriteLine("Do you want to continue ?(Input 'y' to save, 'n' to not save)");
                   char key1 = Convert.ToChar(Console.ReadLine());
                   if(key1 == 'n')
                   {
                       break;
                   }
               }
            }
            catch
            {

            }
        }
        public void DisplayDetailDish(int shop)
        {
            Console.Clear();
            Category category = new Category();
            CategoryBL categoryBL = new CategoryBL();
            List<Category> catelist = categoryBL.DisplayDishofCate(category,shop);
            do
            {
                Console.Write("Input dishID : ");
                int key = Convert.ToInt32(Console.ReadLine());
                foreach(Category cate in catelist)
                {
                   if(key == cate.CategoryID)
                   {
                      Console.WriteLine("====================");
                      Console.WriteLine("DETAIL DISH");
                      Console.WriteLine("====================");
                      Console.Write("1.Dish Name : " + cate.CategoryName);
                      Console.Write("2.Amount : " + cate.Amount);
                      Console.Write("3.Price : " + cate.Price);
                      Console.Write("4.Date of manufacture : " + cate.DateofManufacture);
                      Console.Write("5.Expiry : " + cate.Expiry);
                      Console.WriteLine("==========================");
                      Console.Write("Do you want to update information of dish ? (Input 'y' to update , 'n' to exit)");
                      char check = Convert.ToChar(Console.ReadLine());
                      if(check == 'y')
                      {
                         Update(category,key);
                      }
                      else
                      {
                         DisplayAllCategory(shop);
                      }
                   }
                   else
                   {
                      Console.Write("Not found result !");
                      break;
                   }
                }
            } while(true);
        }
        public void Update(Category category, int key)
        {
            do
            {
                CategoryBL cate = new CategoryBL();
                Console.Write("What do you want to change ? (Input 1-5) : ");
                int num = Convert.ToInt32(Console.ReadLine());
                if(num == 1)
                {
                    cate.UpdateName(category);
                }
                if(num == 2)
                {
                    cate.UpdateAmount(category);
                }
                if(num == 3)
                {
                    cate.UpdatePrice(category);
                }
                if(num == 4)
                {
                    cate.UpdateManufacture(category);
                }
                if(num == 5)
                {
                    cate.UpdateExpiry(category);
                }
                else
                {
                    Console.Write("Input 1 - 5");
                }  
            } while(true);
        }
        public void Search(int shop)
        {
            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Input dish name : ");
                    string name = Convert.ToString(Console.ReadLine());
                    if(String.IsNullOrEmpty(name))
                    {
                        Search(shop);
                    }
                    else
                    {
                        DishBL dishBL = new DishBL();
                        Dish dish = new Dish();
                        List<Dish> dishes = dishBL.GetSearchDish(shop,name);
                        foreach(Dish d in dishes)
                        {
                            var table = new ConsoleTable("DISH ID","DISH NAME","AMOUNT","PRICE","DATE OF MANUFACTURE","EXPIRY");
                   
                            if(name.ToUpper() == d.DishName.ToUpper() || d.DishName.ToString().ToUpper().Contains(name.ToUpper()))
                            {
                                table.AddRow(d.DishID,d.DishName,d.Amount,d.Price,d.DateofManufacture,d.Expiry);  
                            }
                            else
                            {
                                Console.Write("Not found result !");
                                break;
                            }

                           table.Write();
                           Console.WriteLine();
                        }
                        Console.Write("Do you want to continue ? (y/n)");
                        char check = Convert.ToChar(Console.ReadLine());
                        if(check == 'n')
                        {
                            ManagementDishes(shop);
                        }
                    }

                } while(true);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void InsertDishToCate(int cateID, int shop)
        {
            do
            {
                Category category = new Category();
                DishBL dishBL = new DishBL();
                CategoryBL categoryBL = new CategoryBL();
                List<Dish> dishlist = dishBL.GetAllDish(shop);
                Console.Write("Input Dish ID : ");
                int dishID = Convert.ToInt32(Console.ReadLine());
                foreach(Dish ds in dishlist)
                {
                    if(dishID == ds.DishID)
                    {
                        categoryBL.InsertDishofCate(cateID,dishID);
                        Console.WriteLine("Add success !");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not found");
                        break;
                    }
                }
                Console.Write("Do you want to cotinue ? (y/n)");
                char key = Convert.ToChar(Console.ReadLine());
                if(key == 'y')
                {
                    continue;
                }
                if(key == 'n')
                {
                    ManagementDishes(shop);
                }
            } while(true);
        }
    }
}