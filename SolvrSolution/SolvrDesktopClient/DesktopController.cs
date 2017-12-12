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
        private static RemoteSolvrReference.ISolvrServices solvrProxy = new RemoteSolvrReference.SolvrServicesClient();

        public DesktopController(bool useMockDB = false)
        {
            //TODO ...use the mockDB bool somehow.
        }

        public Report GetReport(int id)
        {
            return solvrProxy.GetReport(id);
        }

        public List<Report> GetAllReports(bool onlyNotResolved)
        {
            return solvrProxy.GetReportList(onlyNotResolved).ToList();
        }

        public int[] GetReportCounts(bool onlyNotResolved)
        {
            int[] counts = new int[12];
            List<Report> reports = GetAllReports(onlyNotResolved);

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

        internal Post GetPost(int postId)
        {
            return solvrProxy.GetPost(postId, false, false, true);
        }

        public User GetUser(int id)
        {
            return solvrProxy.GetUser(id, null);
        }

        public Post UpdatePost(Post post)
        {
            return solvrProxy.UpdatePost(post);
        }

        public Report UpdateReport(Report report)
        {
            return solvrProxy.UpdateReport(report);
        }

        public bool IsConnectedToDb()
        {
            return solvrProxy.IsConnectedToDatabase();
        }
    }
}
