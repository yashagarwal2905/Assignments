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

            Console.WriteLine("Enter product details: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter product name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter product price: ");
            int price = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter quantity: ");
            int quant = Convert.ToInt32(Console.ReadLine());

            int total = price * quant;

            int discount = 0;

            if(quant < 10)
            {
                discount = 0;
            }
            else if(quant > 10)
            {
                discount = total / 10;
            }
            else if(quant > 30 && quant < 50)
            {
                discount = total / 5;  
            }
            else
            {
                discount = total / 2;
            }

            int final = total - discount;

            Console.WriteLine("------------------------------");
            Console.WriteLine("Product ID: " + id);
            Console.WriteLine("Product Name: " + name);
            Console.WriteLine("Unit Price: " + price);
            Console.WriteLine("Quantity: " + quant);
            Console.WriteLine("Total Amount: " + total);
            Console.WriteLine("Discount Amount: " + discount);
            Console.WriteLine("Final Amount: " + final);


            Console.ReadLine();

        }
    }
}