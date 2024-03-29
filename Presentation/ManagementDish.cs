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
                   Menu m = new Menu();
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
                       m.MainMenu(shop);
                       break;
                      default:
                      Console.WriteLine("Choose 1-5");
                      break;
                   }
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
                   Dish dishes = new Dish();
                   DishBL dishBL = new DishBL();
                   List<Dish> listdish = dishBL.GetDishID();
                   dishes.DishID = CreateID();
                   Console.WriteLine("No : "+ dishes.DishID);
                   do
                   {
                        Console.Write("Dish Name: ");
                        dishes.DishName = Convert.ToString(Console.ReadLine());
                        Console.Write("Amount: ");
                        string? amount = Console.ReadLine();
                        Console.Write("Price : ");
                        string? input = Console.ReadLine(); 
                        Console.Write("Date of manufacture (yyyy-MM-dd) : ");
                        string? manu = Convert.ToString(Console.ReadLine());
                        Console.Write("Expiry (yyyy-MM-dd): ");
                        string? ex = Convert.ToString(Console.ReadLine());
                        if(String.IsNullOrEmpty(dishes.DishName)  || string.IsNullOrEmpty(amount)
                        || String.IsNullOrEmpty(manu) || String.IsNullOrEmpty(ex) || (manu.Substring(4,1) != "-" || manu.Substring(7,1) != "-")
                        || (ex.Substring(4,1) != "-" || ex.Substring(7,1) != "-"))
                        {
                            Console.WriteLine("Not null or define not sure. Try again !");
                            Thread.Sleep(1000);
                            continue;
                        }
                        else
                        {
                            int num;
                            Int32.TryParse(amount ,out num);
                            dishes.Amount = num;
                            double price;
                            Double.TryParse(input, out price);
                            dishes.Price = price;
                            DateTime manufacture;
                            DateTime.TryParse(manu ,out manufacture);
                            dishes.DateofManufacture = manufacture;
                            DateTime expiry;
                            DateTime.TryParse(ex, out expiry);
                            dishes.Expiry = expiry;
                            if(DateTime.Compare(manufacture,DateTime.Now) > 0 || DateTime.Compare(manufacture,expiry) > 0)
                            {
                                Console.WriteLine("Input manufacture / expiry not sure. Input again");
                                Thread.Sleep(1000);
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                   } while (true);
                    Console.Write("Do you want to add this dish ? (y/n) : ");
                    string? check = Console.ReadLine();
                    if(check == "y")
                    {
                        dishBL.InsertDish(dishes);
                        dishBL.SaveDish(dishes,shop);
                        Console.WriteLine("Add dish success !");
                        Console.Write("Do you want to add another dish ? (y/n) : ");
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
                    else
                    {
                        ManagementDishes(shop);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DisplayAllDish(int shop, int page = 1)
        {
                while(true)
                {
                    DishBL dishBL = new DishBL();
                    List<Dish> dishes = dishBL.GetAllDish(shop);
                    int size = 5;
                    int pages = (int) Math.Ceiling((double)dishes.Count / size);
                    var list = dishes.Skip((page - 1) * size).Take(size).ToList();
                    if(dishes != null)
                    {
                        Console.Clear(); 
                        var table = new ConsoleTable("DISH ID","DISH NAME","AMOUNT","PRICE","DATE OF MANUFACTURE","EXPIRY");
                        foreach(Dish dish in list)
                        {
                            table.AddRow(dish.DishID, dish.DishName, dish.Amount, dish.Price, dish.DateofManufacture.ToString("yyyy-MM-dd"), dish.Expiry.ToString("yyyy-MM-dd"));  
                        }
                        table.Write();
                        Console.WriteLine();

                        Console.WriteLine("Do you want to see other results ? (press 'y' to continue, 'n' to exit)");
                        char check = Convert.ToChar(Console.ReadLine());
                        if(check == 'n')
                        {
                            ManagementDishes(shop);
                        }
                        else
                        {
                            page++;
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
                    Category cate = new Category();
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
                   do 
                   {
                       Console.Write("Category Name: ");
                       category.CategoryName = Convert.ToString(Console.ReadLine());
                       if(String.IsNullOrEmpty(category.CategoryName))
                       {
                           continue;
                       }
                       else
                       {
                           break;
                       }
                   } while (true);

                   Console.Write("Do you want to save this category ? (Input 'y' to save , 'n' to not save)");
                   char check = Convert.ToChar(Console.ReadLine());
                   if(check == 'y')
                   {
                       cateBL.InsertCate(category);
                       cateBL.SaveCate(category, shop);
                       Console.WriteLine("Add dish success");
                       Console.Write("Do you want to add another dish ? (y/n) : ");
                       char key = Convert.ToChar(Console.ReadLine());
                       if(key == 'n')
                       {
                          ManagementDishes(shop);
                       }  
                   }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
                   string? newname = Convert.ToString(Console.ReadLine());
                   Console.Write("Do you want to save this change ? (Input 'y' to save, 'n' to not save)");
                   char key = Convert.ToChar(Console.ReadLine());
                   if(key == 'y')
                   {
                       CategoryBL categoryBL = new CategoryBL();
                       List<Category> catlist = categoryBL.GetAllCategory(shop);
                       foreach(Category cat in catlist)
                       {
                           if(newname != cat.CategoryName)
                           {
                               categoryBL.EditCate(newname,cateID);
                               Console.WriteLine("Update success !");
                               break;
                           }
                           else
                           {
                               Console.Write("Name exist. Do you want to save ? (y/n) : ");
                               char check = Convert.ToChar(Console.ReadLine());
                               if(check == 'y')
                               {
                                   categoryBL.EditCate(newname,cateID);
                                   Console.WriteLine("Update success !");
                                   break;
                               }
                               else
                               {
                                   break;
                               }
                           }
                       }
                       
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
            Category category = new Category();
            CategoryBL categoryBL = new CategoryBL();
            
            do
            {
                Console.Write("Input dishID : ");
                int key = Convert.ToInt32(Console.ReadLine());
                List<Category> catelist = categoryBL.DisplayDetailDishofCate(shop,key);
                foreach(Category cat in catelist)
                {
                   if(key == cat.DishID)
                   {
                      Console.Clear();
                      Console.WriteLine("====================");
                      Console.WriteLine("DETAIL DISH");
                      Console.WriteLine("====================");
                      Console.WriteLine("1.Dish Name : " + cat.DishName);
                      Console.WriteLine("2.Amount : " + cat.Amount);
                      Console.WriteLine("3.Price : " + cat.Price);
                      Console.WriteLine("4.Date of manufacture : " + cat.DateofManufacture.ToString("yyyy-MM-dd"));
                      Console.WriteLine("5.Expiry : " + cat.Expiry.ToString("yyyy-MM-dd"));
                      Console.WriteLine("==========================");
                      Console.Write("Do you want to update information of dish ? (Input 'y' to update , 'n' to exit) : ");
                      char check = Convert.ToChar(Console.ReadLine());
                      if(check == 'y')
                      {
                         Update(category,key,shop);
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
        public void Update(Category category, int key,int shop)
        {
            do
            {
                CategoryBL cate = new CategoryBL();
                Console.Write("What do you want to change ? (Input 1-5) : ");
                int num = Convert.ToInt32(Console.ReadLine());
                if(num == 1)
                {
                    Console.Write("New dish name : ");
                    string check = UpdateString();   
                    cate.UpdateName(check,key);
                    Console.WriteLine("Update success !");
                }
                if(num == 2)
                {
                    do 
                    {
                        Console.Write("New Amount : ");
                        string? chain = Console.ReadLine();
                        if(String.IsNullOrEmpty(chain))
                        {
                            continue;
                        }
                        else
                        {
                            int check;
                            Int32.TryParse(chain, out check);
                            cate.UpdateAmount(check,key);
                            Console.WriteLine("Update success !");
                            break;
                        }
                    } while(true);
                }
                if(num == 3)
                {
                    do 
                    {
                       Console.Write("New Price : ");
                       string? chain = Console.ReadLine();
                       if(String.IsNullOrEmpty(chain))
                       {
                            continue;
                       }
                       else
                       {
                           double check;
                           Double.TryParse(chain, out check);
                           cate.UpdatePrice(check,key);
                           Console.WriteLine("Update success !");
                           break;
                       }
                    } while(true);
                }
                if(num == 4)
                {
                    do
                    {
                        Console.Write("Date of Manufacture : ");
                        string? chain = Console.ReadLine();
                        if(String.IsNullOrEmpty(chain))
                        {
                            continue;
                        }
                        else
                        {
                            DateTime date;
                            DateTime.TryParse(chain, out date);
                            cate.UpdateManufacture(date,key);
                            Console.WriteLine("Update success !");
                            break;
                        }
                    } while (true);
                }
                if(num == 5)
                {
                    do
                    {
                        Console.Write("Expiry : ");
                        string? chain = Console.ReadLine();
                        if(String.IsNullOrEmpty(chain))
                        {
                           continue;
                        }
                        else
                        {
                           DateTime date;
                           DateTime.TryParse(chain, out date);
                           cate.UpdateExpiry(date ,key);
                           Console.WriteLine("Update success !");
                           break;
                        }
                    } while(true);
                }
                 
                Console.Write("Do you want to continue ? (y/n) : ");
                char check1 = Convert.ToChar(Console.ReadLine());
                if(check1 == 'n')
                {
                    ManagementDishes(shop);
                }
                else
                {
                    continue;
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
                    string? name = Convert.ToString(Console.ReadLine());
                    if(String.IsNullOrEmpty(name))
                    {
                        Search(shop);
                    }
                    else
                    {
                        DishBL dishBL = new DishBL();
                        Dish dish = new Dish();
                        List<Dish> dishes = dishBL.GetSearchDish(shop,name);
                        bool result = false;
                        var table = new ConsoleTable("DISH ID","DISH NAME","AMOUNT","PRICE","DATE OF MANUFACTURE","EXPIRY");
                        foreach(Dish d in dishes)
                        {
                            if(name.ToUpper() == d.DishName.ToUpper() || d.DishName.ToString().ToUpper().Contains(name.ToUpper()))
                            {
                                result = true;
                                table.AddRow(d.DishID,d.DishName,d.Amount,d.Price,d.DateofManufacture,d.Expiry);  
                            }
                        }
                        table.Write();
                        Console.WriteLine();
                        if(result == false)
                        {
                            Console.WriteLine("Not found result !");
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
                    if(dishID != ds.DishID)
                    {
                        categoryBL.InsertDishofCate(dishID, cateID);
                        Console.WriteLine("Add success !");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Dish exsits or not found dish in list.");
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
        public string UpdateString()
        {
            do
            {
                string? key = Convert.ToString(Console.ReadLine());
                if(String.IsNullOrEmpty(key))
                {
                    Console.WriteLine("Not null.");
                    continue;
                }
                else
                {
                    return key;
                }
            } while (true);
        }
        public int CreateID()
        {
            int max = 1;
            DishBL dishBL = new DishBL();
            List<Dish> listdish = dishBL.GetDishID();
            if(listdish != null && listdish.Count > 0)
            {
                max = listdish[0].DishID;
                foreach(Dish ds in listdish)
                {
                    if(max < ds.DishID)
                    {
                        max = ds.DishID;
                    }
                }
                max++;
            }
            return max;
        }
    }
}