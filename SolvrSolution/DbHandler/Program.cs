using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolvrLibrary;
using System.IO;

namespace DbHandler
{
   public class Program
    {
        public static void Main(string[] args)
        {
            PopulateDB();
        }

        public static void PopulateDB()
        {
            Console.WriteLine("Populating db...");
            new Insert().InsertData();
            //new Insert().InserSimpleData();
            Console.WriteLine("db populated");
            Console.ReadLine();
        }
    }
}
