using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolvrLibrary;

namespace DbHandler
{
    public class Insert
    {
        public void InsertData()
        {
            Models.InsertHelper<Category>.InsertObjectsIntoDB();
            Models.InsertHelper<User>.InsertObjectsIntoDB();
            Models.InsertHelper<Post>.InsertObjectsIntoDB();
            Models.InsertHelper<PhysicalPost>.InsertObjectsIntoDB();
            Models.InsertHelper<Comment>.InsertObjectsIntoDB();
            Models.InsertHelper<SolvrComment>.InsertObjectsIntoDB();
            Models.InsertHelper<Vote>.InsertObjectsIntoDB();
            Models.InsertHelper<Report>.InsertObjectsIntoDB();
        }

        public void InserSimpleData()
        {
            Models.SimpleInsert.InsertDataIntoDB();
        }
    }
}
