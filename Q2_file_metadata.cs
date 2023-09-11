﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"C:\\Users\\yashagarwal\\source\\repos\\Program.cs";
            FileInfo file = new FileInfo(filepath);

            Console.WriteLine("File Name:{0}\nFile Size:{1}\nCreation Time:{2}", file.Name, file.Length, file.CreationTime);
            //Console.WriteLine(File.GetCreationTime(@"C:\\Users\\yashagarwal\\source\\repos\\Program.cs"));

            Console.ReadLine();
        }
    }
}