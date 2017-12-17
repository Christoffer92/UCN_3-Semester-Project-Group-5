using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolvrLibrary;
using System.ServiceModel;
using DataAccesLayer;

namespace SolvrServices
{
    //[ServiceBehavior]
    public class SolvrService : ISolvrServices
    {
        private readonly DataAccesController dbCtr = new DataAccesController(false);

        public SolvrService()
        {
           // dbCtr = new DataAccesController(false);
        }

        public SolvrService(bool useMockDB = false)
        {
            dbCtr = new DataAccesController(useMockDB);
        }

        public bool IsConnectedToDatabase()
        {
            return dbCtr.DatabaseExists();
        }

        #region Get Methods
        public User GetUser(int id = 0, string username = "")
        {
            return dbCtr.GetUser(id, username);
        }

        public Post GetPost(int id, bool withUsers = false, bool withComments = false, bool notDisabled = true)
        {
            return dbCtr.GetPost(id, withUsers, withComments, notDisabled);
        }

        public Comment GetComment(int id, bool withUser = false, bool withVotes = false)
        {
            return dbCtr.GetComment(id, withUser, withVotes);
        }

        public Category GetCategory(int id)
        {
            return dbCtr.GetCategory(id);
        }

        public Report GetReport(int id)
        {
            return dbCtr.GetReport(id);
        }

        public List<Post> GetPostList(int offSet, int loadCount, bool withUsers = false, bool withComments = false)
        {
            return dbCtr.GetPostList(offSet, loadCount, withUsers, withComments);
        }

        public List<Comment> GetCommentList(int postId, bool withUsers  = false)
        {
            return dbCtr.GetCommentList(postId, withUsers);
        }

        public List<Category> GetCategoryList()
        {
            return dbCtr.GetCategoryList();
        }

        public List<Report> GetReportList(bool onlyNotResolved = false)
        {
            return dbCtr.GetReportList(onlyNotResolved);
        }

        public List<Vote> GetVoteList(int commentId)
        {
            return dbCtr.GetVoteList(commentId);
        }
        #endregion

        #region Create Methods
        public Post CreatePost(Post post)
        {
            return dbCtr.CreatePost(post);
        }

        public User CreateUser(User user)
        {
            return dbCtr.CreateUser(user);
        }

        public Comment CreateComment(Comment comment)
        {
            return dbCtr.CreateComment(comment);
        }

        public Report CreateReport(Report report)
        {
            return dbCtr.CreateReport(report);
        }
        #endregion

        #region Update Methods
        public Comment UpdateComment(Comment comment)
        {
            return dbCtr.UpdateComment(comment);
        }

        public Post UpdatePost(Post post)
        {
            return dbCtr.UpdatePost(post);
        }

        public Report UpdateReport(Report report)
        {
            return dbCtr.UpdateReport(report);
        }
        #endregion
    }
}

//To use a transaction use the [OperationBehavior(TransactionScopeRequired=true)]
