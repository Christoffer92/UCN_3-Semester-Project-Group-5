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
        private ISolvrServices proxy;
        public DesktopController(bool useMockDB = false)
        {
            proxy = new SolvrService(useMockDB);
        }

        public Report GetReport(int id)
        {
            return proxy.GetReport(id);
        }

        public List<Report> GetAllReports()
        {
            return proxy.GetAllReports();
        }

        public int[] GetReportCounts()
        {
            int[] counts = new int[12];
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

                if (report.ReportType.Equals("post") && report.IsResolved == false)
                {
                    counts[3]++;
                }
                if (report.ReportType.Equals("post") && report.IsResolved == true)
                {
                    counts[4]++;
                }
                if (report.ReportType.Equals("post"))
                {
                    counts[5]++;
                }
                if (report.ReportType.Equals("comment") && report.IsResolved == false)
                {
                    counts[6]++;
                }
                if (report.ReportType.Equals("comment") && report.IsResolved == true)
                {
                    counts[7]++;
                }
                if (report.ReportType.Equals("comment"))
                {
                    counts[8]++;
                }
                if (report.ReportType.Equals("user") && report.IsResolved == false)
                {
                    counts[9]++;
                }
                if (report.ReportType.Equals("user") && report.IsResolved == true)
                {
                    counts[10]++;
                }
                if (report.ReportType.Equals("user"))
                {
                    counts[11]++;
                }
            }
            return counts;
        }

        public User GetUser(int id)
        {
            return proxy.GetUser(id);
        }

        public void SetReportToResolved(int reportId)
        {
            proxy.SetReportToResolved(reportId);
        }

        public void UpdatePostText(int reportId, string txt)
        {
            proxy.UpdatePostText(reportId, txt);
        }

        public void DisablePost(int postId)
        {
            proxy.DisablePost(postId);
        }

        public void UpdatePostTitle(int postId, string text)
        {
            proxy.UpdatePostTitle(postId, text);
        }
    }
}
