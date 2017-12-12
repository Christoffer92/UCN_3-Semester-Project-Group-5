using DataAccesLayer.DAL;
using SolvrLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class DataAccesController
    {
        private ISolvrDB db;
        public DataAccesController(bool useMockDb = false)
        {
            if (useMockDb)
                db = new MockDB();
            else
                db = new SolvrDB();
        }

        public bool DatabaseExists()
        {
            return db.DatabaseExists();
        }

        #region Get Methods
        public User GetUser(int id = 0, string username = "")
        {
            User user = null;
            if (id > 0)
            {
                user = db.GetUser(id);
            }
            else if (!username.Equals(""))
            {
                user = db.GetUser(username);
            }
            else
            {
                throw new ArgumentException();
            }
            return user;
        }

        public Post GetPost(int id, bool withUser = false, bool withComments = false, bool notDisabled = true)
        {
            Post post = null;
            if (id > 0)
            {
                post = db.GetPost(id);
                post.Category = GetCategory(post.CategoryId);
            }
            else
            {
                throw new ArgumentException();
            }

            if (withUser)
            {
                post.User = GetUser(post.UserId);
            }

            if (withComments)
            {
                post.Comments = GetCommentList(post.Id);
            }


            return post;
        }

        public Comment GetComment(int id, bool withUser = false, bool withVotes = false)
        {
            Comment comment = null;
            if (id > 0)
            {
                comment = db.GetComment(id);
            }
            else
            {
                throw new ArgumentException();
            }

            if (withUser)
            {
                comment.User = GetUser(comment.Id);
            }
            
            if (withVotes)
            {
                comment.Votes = GetVoteList(comment.Id);
            }

            return comment;
        }

        public Category GetCategory(int id)
        {
            Category category = null;

            if (id > 0)
            {
                category = db.GetCategory(id);
            }
            else
            {
                throw new ArgumentException();
            }

            return category;
        }

        public Report GetReport(int id)
        {
            Report report = null;
            if (id > 0)
            {
                report = db.GetReport(id);
            }
            else
            {
                throw new ArgumentException();
            }

            return report;
        }

        public List<Post> GetPostList(int offSet, int loadCount, bool withUsers = false,
                                      bool withComments = false)
        {
            try
            {
                List<Post> posts = new List<Post>();
                if (offSet >= 0 && loadCount > 0)
                {
                    posts = db.GetPostList(offSet, loadCount);
                }
                else
                {
                    throw new NotImplementedException();
                }

                foreach (Post item in posts)
                {
                    item.Category = GetCategory(item.CategoryId);

                    if (withUsers)
                        item.User = GetUser(item.UserId);
                    
                    if (withComments)
                        item.Comments = GetCommentList(item.Id);

                }
                

                return posts;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            
        }

        public List<Vote> GetVoteList(int commentId)
        {
            List<Vote> votes = new List<Vote>();
            if (commentId > 0)
            {
                votes = db.GetVoteList(commentId);
            }
            return votes;
        }

        /// <summary>
        /// Returns a list of comments, if postId is set it will returns its comments, and the same for userId.
        /// Note! If you want to get the comments of a user you need to send arguments postId to 0 and userId
        /// to the user.
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="userId"></param>
        public List<Comment> GetCommentList(int postId = 0, bool withUsers = false)
        {
            List<Comment> comments = new List<Comment>();
            if (postId > 0)
            {
                comments = db.GetCommentList(postId);
            }
            else
            {
                throw new NotImplementedException();
            }

            if (withUsers)
            {
                foreach (Comment item in comments)
                {
                    item.User = GetUser(item.UserId);
                }
            }

            return comments;
        }

        public List<Report> GetReportList(bool onlyNotResolved = false)
        {
            return db.GetReportList(onlyNotResolved);            
        }

        public List<Category> GetCategoryList()
        {
            return db.GetCategoryList();
        }
        #endregion

        #region Create Methods
        public Post CreatePost(Post post)
        {
            if (post != null)
            {
                post = db.InsertPost(post);
            }
            else
            {
                throw new ArgumentNullException();
            }

            return post;
        }
        public User CreateUser(User user)
        {
            if (user != null)
            {
                user = db.InsertUser(user);
            }
            else
            {
                throw new ArgumentNullException();
            }

            return user;
        }
        public Comment CreateComment(Comment comment)
        {
            if (comment != null)
            {
                comment = db.InsertComment(comment);
            }
            else
            {
                throw new ArgumentNullException();
            }

            return comment;
        }
        public Report CreateReport(Report report)
        {
            if (report != null)
            {
                report = db.InsertReport(report);
            }
            else
            {
                throw new ArgumentNullException();
            }

            return report;
        }
        #endregion

        #region Update Methods
        public Post UpdatePost(Post post)
        {
            if (post != null)
            {
                post = db.UpdatePost(post);
            }
            else
            {
                throw new ArgumentNullException();
            }

            return post;
        }
        public Comment UpdateComment(Comment comment)
        {
            if (comment != null)
            {
                comment = db.UpdateComment(comment);
            }
            else
            {
                throw new ArgumentNullException();
            }

            return comment;
        }
        public Report UpdateReport(Report report)
        {
            if (report != null)
            {
                report = db.UpdateReport(report);
            }
            else
            {
                throw new ArgumentNullException();
            }

            return report;
        }
        #endregion
    }
}
