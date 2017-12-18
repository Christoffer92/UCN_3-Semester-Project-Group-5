using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wcfConsoleApplication
{
    class Program
    {
        private static RemoteSolvrReference.ISolvrServices solvrProxy = new RemoteSolvrReference.SolvrServicesClient();
        static void Main(string[] args)
        {
            solvrProxy.GetReport(2);
            Console.ReadLine();
        }
}
}
