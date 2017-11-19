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
            SolvrDB context = new SolvrDB(@"Data Source=X1CARBON\SQLEXPRESS;Initial Catalog=SolvrDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            
            Models.UserInsert.InsertUsersIntoDB(context);
            Models.CategoryInsert.InsertCategoriesIntoDb(context);
            Models.PostInsert.InsertPostsIntoDb(context);
            Models.CommentInsert.CommentInsertIntoDb(context);
            Models.PhysicalPostInsert.InsertPhysicalPostIntoDb(context);
            Models.SolvrCommentInsert.InsertSolvrCommentIntoDb(context);
            Models.VoteInsert.InsertVoteIntoDb(context);
            Models.ReportInsert.InsertReportIntoDb(context);
        }

        public void InserSimpleData()
        {
            SolvrDB context = new SolvrDB(@"Data Source=CHRISLAPTOP\SQLEXPRESS;Initial Catalog=SolvrDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            Models.SimpleInsert.InsertDataIntoDB(context);
        }

    }
}
