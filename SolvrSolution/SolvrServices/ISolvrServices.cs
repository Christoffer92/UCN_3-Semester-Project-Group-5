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
        bool IsConnectedToDatabase();
    }
}
