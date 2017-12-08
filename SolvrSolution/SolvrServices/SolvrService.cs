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

        public Category GetCategory(int id)
        {
            return solvrDB.GetCategory(id);
        }

        public Category GetCategory(string name)
        {
            return solvrDB.GetCategory(name);
        }

        public Post CreatePost(Post post)
        {
            return solvrDB.CreatePost(post);
        }

        public PhysicalPost CreatePhysicalPost(PhysicalPost post)
        {
            return solvrDB.CreatePhysicalPost(post);
        }

        public PhysicalPost GetPhysicalPost(int id)
        {
            return solvrDB.GetPhysicalPost(id);
        }

        public Post GetPost(int id)
        {
            return solvrDB.GetPost(id);
        }

        public Post GetPost()
        {
            return solvrDB.GetPost();
        }

        public User GetUser()
        {
            return solvrDB.GetUser();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return solvrDB.GetAllCategories();
        }

        public IEnumerable<Comment> GetComments(int iD)
        {
            return solvrDB.GetComments(iD);
        }

        public Comment CreateComment(Comment c)
        {
            return solvrDB.CreateComment(c);
        }

        public SolvrComment CreateSolvrComment(SolvrComment sc)
        {
            return solvrDB.CreateSolvrComment(sc);
        }

        public void UpdatePost(Post p)
        {
            solvrDB.UpdatePost(p);
        }

        public void UpdateSolvrComment(SolvrComment sc)
        {
            solvrDB.UpdateSolvrComment(sc);
        }

        public void UpdatePhysicalPost(PhysicalPost post)
        {
            solvrDB.UpdatePhysicalPost(post);
        }

        public IEnumerable<Post> GetPostsByBumpTime(int loadCount)
        {
            return solvrDB.GetPostsByBumpTime(loadCount);
        }

        public User GetUser(string Username)
        {
            return solvrDB.GetUser(Username);
        }

        public void CreateUser(User user)
        {
            solvrDB.CreateUser(user);
        }

        public SolvrComment GetSolvrComment(int ID)
        {
            return solvrDB.GetComment<SolvrComment>(ID);
        }

        public Comment GetComment(int ID)
        {
            return solvrDB.GetComment<Comment>(ID);
        }
    }
}

//To use a transaction use the [OperationBehavior(TransactionScopeRequired=true)]
