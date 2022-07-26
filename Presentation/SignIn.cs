using BL;
using Persistence;
using System.Text;

namespace Presentation
{
    public class SignIn
    {
        public void InputUserName()
        {
            Console.WriteLine("====================");
            Console.WriteLine("SIGN IN");
            Console.WriteLine("====================");
            while (true)
            {
                do
                {
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
                    SalesmanBL salesmanBL = new SalesmanBL();
                    List<Salesman> salesmenlist = salesmanBL.GetPassword();
                    foreach (Salesman sales in salesmenlist)
                    {
                        if(sales.Password == CreateMD5(password))
                        {
                            Console.WriteLine("Sign in success !");
                            Menu menu = new Menu();
                            menu.MainMenu();
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