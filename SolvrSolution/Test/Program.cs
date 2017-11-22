using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolvrLibrary;
using SolvrWebClient;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ISolvrDB Db = new MockDB();

            var dbResult = Db.GetLastPost();

            Console.WriteLine("" + dbResult);

            Console.ReadLine();
        }
    }
}
