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
        bool IsConnectedToDatabase();

        #region Get Methods
        [OperationContract]
        User GetUser(int id, string username);

        [OperationContract]
        Post GetPost(int id, bool withUsers, bool withComments, bool notDisabled);

        [OperationContract]
        Comment GetComment(int id, bool withUser, bool withVotes);

        [OperationContract]
        Category GetCategory(int id);

        [OperationContract]
        Report GetReport(int id);

        [OperationContract]
        List<Post> GetPostList(int offSet, int loadCount, bool withUsers, bool withComments);

        [OperationContract]
        List<Comment> GetCommentList(int postId, bool withUsers);

        [OperationContract]
        List<Category> GetCategoryList();

        [OperationContract]
        List<Report> GetReportList(bool notResolved);

        [OperationContract]
        List<Vote> GetVoteList(int commentId);
        #endregion

        #region Create Methods
        [OperationContract]
        User CreateUser(User user);
       
        [OperationContract]
        Post CreatePost(Post post);

        [OperationContract]
        Comment CreateComment(Comment comment);

        [OperationContract]
        Report CreateReport(Report report);
        #endregion

        #region UpdateReport
        [OperationContract]
        Post UpdatePost(Post post);

        [OperationContract]
        Comment UpdateComment(Comment comment);

        [OperationContract]
        Report UpdateReport(Report report);
        #endregion
    }
}