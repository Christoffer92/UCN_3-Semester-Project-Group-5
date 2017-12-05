using SolvrServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolvrLibrary;

namespace SolvrDesktopClient
{
    public class DesktopController
    {

        private List<Report> reports;
        private ISolvrServices proxy;
        public DesktopController()
        {
            proxy = new SolvrService();
        }

        public void GetReport(int id)
        {
            proxy.GetReport(id);
        }

        public List<Report> GetAllReports()
        {
            return proxy.GetAllReports();
        }

        public int[] GetReportCounts()
        {
            int[] counts = new int[3];
            List<Report> reports = GetAllReports();

            counts[0] = reports.Count;
            foreach (Report report in reports)
            {
                switch (report.IsResolved)
                {
                    case true:
                        counts[1]++;
                        break;
                    case false:
                        counts[2]++;
                        break;
                    default:
                        break;
                }
            }

            return counts;
        }
    }
}
