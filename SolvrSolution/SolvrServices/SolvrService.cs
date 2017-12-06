using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolvrLibrary;
using System.ServiceModel;
using DataAccesLayer.DAL;

namespace SolvrServices
{
    //InstanceContextMode = InstanceContextMode.PerCall
    [ServiceBehavior]
    public class SolvrService : ISolvrServices//, IDisposable
    {
        readonly SolvrDB solvrDB = new SolvrDB();

        public List<Report> GetAllReports()
        {
            return solvrDB.GetAllReports();
        }

        public Report GetReport(int id)
        {
            return solvrDB.GetReport(id);
        }

        public User GetUser(int id)
        {
            return solvrDB.GetUser(id);
        }

        public bool IsConnectedToDatabase()
        {
            return solvrDB.DatabaseExists();
        }

        public void SetReportToResolved(int reportId)
        {
            solvrDB.SetReportToResolved(reportId);
        }

        public void UpdatePostText(int postId, string txt)
        {
            solvrDB.UpdatePostText(postId, txt);
        }

        public void DisablePost(int postId)
        {
            solvrDB.DisablePost(postId);
        }

        public void UpdatePostTitle(int postId, string text)
        {
            solvrDB.UpdatePostTilte(postId, text);
        }
    }
}

//To use a transaction use the [OperationBehavior(TransactionScopeRequired=true)]
