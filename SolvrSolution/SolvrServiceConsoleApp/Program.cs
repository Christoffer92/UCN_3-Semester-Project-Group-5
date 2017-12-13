using SolvrServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SolvrServiceConsoleApp
{
    public class Program
    {
        private static RemoteSolvrReference.ISolvrServices solvrProxy = new RemoteSolvrReference.SolvrServicesClient();
        private static Uri baseAddress = new Uri("http://localhost:2112/Solvr");

        public static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(SolvrService), baseAddress))
            {
                host.Open();

                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");

                Console.ReadLine();
                host.Close();
            }
        }
    }
}
