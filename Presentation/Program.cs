using BL;
using Persistence;
using ConsoleTables;

namespace Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            SignIn signIn = new SignIn();
            signIn.InputUserName();
        }
    }   
}