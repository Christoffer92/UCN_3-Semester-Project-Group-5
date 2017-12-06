using SolvrLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SolvrServices
{
    [ServiceContract]
    public interface ISolvrServices
    {
        [OperationContract]
        List<Report> GetAllReports();

        [OperationContract]
        Report GetReport(int id);

        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        bool IsConnectedToDatabase();

        [OperationContract]
        void SetReportToResolved(int reportId);

        [OperationContract]
        void UpdatePostText(int postId, string txt);

        [OperationContract]
        void DisablePost(int postId);

        [OperationContract]
        void UpdatePostTitle(int postId, string text);
    }
}