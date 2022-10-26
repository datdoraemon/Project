using BL;
using Persistence;
using System.Text;
using System.Text.RegularExpressions;

namespace Presentation
{
    public class SignIn
    {
        public void InputUserName()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====================");
                Console.WriteLine("SIGN IN");
                Console.WriteLine("====================");
                do
                {
                    Console.Write("UserName : ");
                    string? username = Convert.ToString(Console.ReadLine());
                    if(string.IsNullOrEmpty(username))
                    {
                        Console.WriteLine("Not null. Input again !");
                        continue;
                    }
                    else
                    {
                        bool check = false;
                        Salesman salesman = new Salesman();
                        SalesmanBL salesmanBL = new SalesmanBL();
                        List<Salesman> salesmenlist = salesmanBL.GetUserNAme(username);
                        foreach (Salesman sales in salesmenlist)
                        {
                            if(username == sales.Username)
                            {
                                check = true;
                                InputPassword(username);
                            }
                        }
                        if(check == false)
                        {
                            Console.WriteLine("Account don't exist. Input Again");
                        }
                    }
                } while (true);
            }
        }
        public void InputPassword(string username)
        {
            do
            {
                Console.Write("Password : ");
                string password = "";
                ConsoleKeyInfo info = Console.ReadKey(true);
                while(info.Key != ConsoleKey.Enter)
                {
                   if(info.Key != ConsoleKey.Spacebar && info.Key != ConsoleKey.Backspace)
                   {
                      password += info.KeyChar;
                      Console.Write("*");
                   }
                   info = Console.ReadKey(true);
                }
                Console.WriteLine();
                string? md5 = CreateMD5(password);
                if(string.IsNullOrEmpty(password))
                {
                    Console.WriteLine("Password not null. Input again !");
                    continue;
                }
                else
                {
                    bool check = false;
                    Salesman salesman = new Salesman();
                    SalesmanBL salesmanBL = new SalesmanBL();
                    List<Salesman> salesmenlist = salesmanBL.GetPassword(md5);
                    foreach (Salesman sales in salesmenlist)
                    {
                        if(sales.Password == md5 && username == sales.Username)
                        {
                            check = true;
                            Console.WriteLine("Sign in success !");
                            Thread.Sleep(1000);
                            int shop = sales.ShopID;
                            Menu menu = new Menu();
                            menu.MainMenu(shop); 
                            ManagementRevenue mr = new ManagementRevenue();
                            mr.ManagenmentRevenue(shop);
                            ManageOrder mo = new ManageOrder();
                            mo.ManagenmentOrder(shop);
                            ManagementDish md = new ManagementDish();
                            md.ManagementDishes(shop);
                        }
                    }
                    if(check == false)
                    {
                        Console.WriteLine("Account don't exist. Input Again");
                    }
                }
            } while (true);
        }
        public static string CreateMD5(string pass)
        {
            using(var provider = System.Security.Cryptography.MD5.Create())
            {
                StringBuilder builder = new StringBuilder();
                foreach(byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(pass)))
                builder.Append(b.ToString("x2").ToLower());
                return builder.ToString();
            }
        }
    }
}