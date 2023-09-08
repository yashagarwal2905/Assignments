using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string uid = "mohini";
            string pwd = "MOHINI123";


            Console.WriteLine("Enter username: ");
            string uid1 = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            string pwd1 = Console.ReadLine();


            if (uid1 == uid && pwd1 == pwd)
            {
                Console.WriteLine("Welcome to Admin");
            }
            else
            {
                Console.WriteLine("Invalid User Id or Password");
            }

            Console.ReadLine();
        }
    }
}