using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolvrLibrary;

namespace DataAccesLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var Context = new SolvrDB())
            {
                var Query = (from post in Context.Posts.OfType<PhysicalPost>() select post).First();
                Console.WriteLine(Query);
                Console.ReadLine();
            }
        }
    }
}
