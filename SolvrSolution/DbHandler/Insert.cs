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
            //Models.UserInsert.InsertUsersIntoDB();

            Models.InsertHelper<Category>.InsertObjectsIntoDB();
            Models.InsertHelper<User>.InsertObjectsIntoDB();
            Models.InsertHelper<Post>.InsertObjectsIntoDB();
            Models.InsertHelper<PhysicalPost>.InsertObjectsIntoDB();
            Models.InsertHelper<Comment>.InsertObjectsIntoDB();
            Models.InsertHelper<SolvrComment>.InsertObjectsIntoDB();
            Models.InsertHelper<Vote>.InsertObjectsIntoDB();
            Models.InsertHelper<Report>.InsertObjectsIntoDB();


            //Models.CategoryInsert.InsertCategoriesIntoDb();
            //Models.PostInsert.InsertPostsIntoDb(context);
            //Models.CommentInsert.CommentInsertIntoDb(context);
            //Models.PhysicalPostInsert.InsertPhysicalPostIntoDb(context);
            //Models.SolvrCommentInsert.InsertSolvrCommentIntoDb(context);
            //Models.VoteInsert.InsertVoteIntoDb(context);
            //Models.ReportInsert.InsertReportIntoDb(context);
        }

        public void InserSimpleData()
        {
            Models.SimpleInsert.InsertDataIntoDB();
        }
    }
}
