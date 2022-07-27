using BL;
using Persistence;
using System.Text;
using System.Threading;

namespace Presentation
{
    public class SignIn
    {
        public void InputUserName()
        {
            while (true)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("====================");
                    Console.WriteLine("SIGN IN");
                    Console.WriteLine("====================");
                    Console.Write("UserName : ");
                    string username = Convert.ToString(Console.ReadLine());
                    if(username == null)
                    {
                        Console.WriteLine("Not null . Input again !");
                    }
                    else
                    {
                        Salesman salesman = new Salesman();
                        SalesmanBL salesmanBL = new SalesmanBL();
                        List<Salesman> salesmenlist = salesmanBL.GetUserNAme(username);
                        foreach (Salesman sales in salesmenlist)
                        {
                            if(username == sales.Username)
                            {
                                InputPassword();
                            }
                            else
                            {
                                break;
                            }
                        }
                        Console.WriteLine("Account don't exist. Input Again");
                    }
                } while (true);
            }
        }
        public void InputPassword()
        {
            do
            {
                Console.Write("Password : ");
                string password = Convert.ToString(Console.ReadLine());
                if(password == null)
                {
                    continue;
                }
                else
                {
                    Salesman salesman = new Salesman();
                    SalesmanBL salesmanBL = new SalesmanBL();
                    List<Salesman> salesmenlist = salesmanBL.GetPassword();
                    foreach (Salesman sales in salesmenlist)
                    {
                        if(sales.Password == CreateMD5(password))
                        {
                            Console.WriteLine("Sign in success !");
                            Thread.Sleep(2000);
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
                        else
                        {
                            Console.WriteLine("Account/pasword don't exist. Input Again");
                            break;
                        }
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