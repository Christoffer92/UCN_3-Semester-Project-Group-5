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
            /*Models.UserInsert.InsertUsersIntoDB(context);
            Models.CategoryInsert.InsertCategoriesIntoDb(context);
            Models.PostInsert.InsertPostsIntoDb(context);
            Models.CommentInsert.CommentInsertIntoDb(context);
            Models.PhysicalPostInsert.InsertPhysicalPostIntoDb(context);
            Models.SolvrCommentInsert.InsertSolvrCommentIntoDb(context);
            Models.VoteInsert.InsertVoteIntoDb(context);
            Models.ReportInsert.InsertReportIntoDb(context);*/
        }

        public void InserSimpleData()
        {
            Models.SimpleInsert.InsertDataIntoDB();
        }
    }
}
