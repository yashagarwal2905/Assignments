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
            StreamReader streamReader = new StreamReader(@"C:\FileData\ApplicationLogs.txt", true);
            while (streamReader.EndOfStream == false)
            {
                Console.WriteLine(streamReader.ReadLine());
            }
            streamReader.Close();
            Console.ReadLine();
        }
    }
}