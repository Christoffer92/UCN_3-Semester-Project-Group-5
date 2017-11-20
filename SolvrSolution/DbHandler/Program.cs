using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolvrLibrary;

namespace DbHandler
{
   public class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Populating db...");
            //new Insert().SimpleData();
            new Insert().InsertData();
            Console.WriteLine("db populated");
            Console.ReadLine();


        }
    }
}
