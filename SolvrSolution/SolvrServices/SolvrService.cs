using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolvrLibrary;
using System.ServiceModel;

namespace SolvrServices
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class SolvrService : ISolvrServices, IDisposable
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

        public void Dispose()
        {
            solvrDB.Dispose();
        }
    }
}

//To use a transaction use the [OperationBehavior(TransactionScopeRequired=true)]
