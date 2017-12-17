using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolvrLibrary;
using System.ServiceModel;

namespace DataAccesLayer.DAL
{
    public class SolvrDB : ISolvrDB
    {
        public bool DatabaseExists()
        {
            using (var db = new SolvrContext())
            {
                return db.DatabaseExists();
            }
        }

        #region Get methods

        public Category GetCategory(int id)
        {
            //from post in DB.Posts orderby post.BumpTime descending select post).Skip(loadCount).Take(24
            using (var db = new SolvrContext())
            {
                return (from category in db.Categories where category.Id == id select category).First();               
            }
        }

        public Comment GetComment(int id)
        {
            using (var db = new SolvrContext())
            {
                return (from comment in db.Comments where comment.Id == id select comment).First();
            }
        }
    
        public Post GetPost(int id)
        {
            using (var db = new SolvrContext())
            {
                return (from post in db.Posts where post.Id == id select post).First();
            }
        }

        public Report GetReport(int id)
        {
            using (var db = new SolvrContext())
            {
                return (from report in db.Reports where report.Id == id select report).First();
            }
        }
        public User GetUser(string username)
        {
            using (var db = new SolvrContext())
            {
                return (from user in db.Users where user.Username == username select user).First();
            }
        }
        public User GetUser(int id)
        {
            using (var db = new SolvrContext())
            {
                return (from user in db.Users where user.Id == id select user).First();
            }
        }

        public List<Category> GetCategoryList()
        {
            List<Category> categoryList = new List<Category>();

            using (var db = new SolvrContext())
            {
                var Query = from category in db.Categories select category;
                foreach (Category item in Query)
                {
                    categoryList.Add(item);
                }
            }

            return categoryList;
        }
        public List<Comment> GetCommentList(int postId)
        {
            List<Comment> commentList = new List<Comment>();

            using (var db = new SolvrContext())
            {
                var Query = from comment in db.Comments where comment.PostId == postId select comment;
                foreach (Comment item in Query)
                {
                    commentList.Add(item);
                }
            }

            return commentList;
        }

        public List<Post> GetPostList(int offSet, int loadCount)
        {
            List<Post> postList = new List<Post>();

            using (var db = new SolvrContext())
            {
                var Query = from post in db.Posts.OrderByDescending(b => b.BumpTime).Skip(offSet).Take(loadCount) where post.IsDisabled == false select post;
                foreach (Post item in Query)
                {
                    postList.Add(item);
                }
            }

            return postList;
        }
        public List<Report> GetReportList(bool onlyNotResolved)
        {
            List<Report> reportList = new List<Report>();

            using (var db = new SolvrContext())
            {
                var Query = from report in db.Reports where report.IsResolved == false select report;

                foreach (Report item in Query)
                {
                    reportList.Add(item);
                }

                if (!onlyNotResolved)
                {
                    Query = from report in db.Reports where report.IsResolved == true select report;

                    foreach (Report item in Query)
                    {
                        reportList.Add(item);
                    }
                }
            }

            return reportList;
        }
        public List<Vote> GetVoteList(int commentId)
        {
            List<Vote> voteList = new List<Vote>();

            using (var db = new SolvrContext())
            {
                var Query = from vote in db.Votes select vote;
                foreach (Vote item in Query)
                {
                    voteList.Add(item);
                }
            }

            return voteList;
        }
        #endregion

        #region Insert methods

        public Comment InsertComment(Comment comment)
        {
            using (var db = new SolvrContext())
            {
               db.Comments.InsertOnSubmit(comment);
               db.SubmitChanges();
            }
            return comment;
        }

        public Post InsertPost(Post post)
        {
            using (var db = new SolvrContext())
            {
                db.Posts.InsertOnSubmit(post);
                db.SubmitChanges();
            }
            return post;
        }

        public Report InsertReport(Report report)
        {
            using (var db = new SolvrContext())
            {
                db.Reports.InsertOnSubmit(report);
                db.SubmitChanges();
            }
            return report;
        }

        public User InsertUser(User user)
        {
            using (var db = new SolvrContext())
            {
                db.Users.InsertOnSubmit(user);
                db.SubmitChanges();
            }
            return user;
        }

        #endregion

        #region Update methods
        public Comment UpdateComment(Comment comment)
        {
            try
            {
                if (comment.CommentType.Equals("Comment"))
                {
                    using (var db = new SolvrContext())
                    {
                        var Query = (from comm in db.Comments where comm.Id == comment.Id && comm.LastEdited == comment.LastEdited select comm).First();
                        Query.Text = comment.Text;
                        Query.IsDisabled = comment.IsDisabled;
                        Query.LastEdited = DateTime.Now;
                        db.SubmitChanges();
                    }
                    return comment;
                }
                else
                {
                    SolvrComment solvrComment = (SolvrComment)comment;
                    using (var db = new SolvrContext())
                    {
                        var Query = (from solvrComm in db.Comments.OfType<SolvrComment>() where solvrComm.Id == comment.Id && solvrComm.LastEdited == comment.LastEdited select solvrComm).First();
                        Query.IsAccepted = solvrComment.IsAccepted;
                        Query.TimeAccepted = solvrComment.TimeAccepted;
                        Query.Text = solvrComment.Text;
                        Query.IsDisabled = solvrComment.IsDisabled;
                        Query.LastEdited = DateTime.Now;
                        db.SubmitChanges();
                    }
                    return solvrComment;
                }
            }
            catch (Exception e)
            {
                //if an exception occurs this checks if there even is a comment with the ID, if there is then ít has been changed from another place.
                using (var db = new SolvrContext())
                {
                    var Query = from comm in db.Comments where comm.Id == comment.Id select comm;

                    if (Query.Count() == 0)
                    {
                        //Concurrency error
                        throw new NotImplementedException();
                    }
                    else
                    {
                        //Standard error
                        throw new NotImplementedException();
                    }
                }
            }
        }

        public Post UpdatePost(Post post)
        {
            try
            {
                if (post.PostType.Equals("Post"))
                {
                    using (var db = new SolvrContext())
                    {
                        var Query = (from pos in db.Posts where pos.Id == post.Id && pos.LastEdited == post.LastEdited select pos).First();
                        Query.Title = post.Title;
                        Query.Description = post.Description;
                        Query.BumpTime = post.BumpTime;
                        Query.CategoryId = post.CategoryId;
                        Query.IsDisabled = post.IsDisabled;
                        //Somewhere in MVC, miliseconds gets erased, so here it is just removed entirely.
                        DateTime dt = DateTime.Now;
                        Query.LastEdited = dt.AddMilliseconds(-dt.Millisecond);
                        db.SubmitChanges();
                    }
                    return post;
                }
                else
                {
                    PhysicalPost physicalPost = (PhysicalPost)post;
                    using (var db = new SolvrContext())
                    {
                        var Query = (from physPost in db.Posts.OfType<PhysicalPost>() where physPost.Id == physicalPost.Id && physPost.LastEdited == post.LastEdited select physPost).First();
                        Query.Title = physicalPost.Title;
                        Query.Description = physicalPost.Description;
                        Query.BumpTime = physicalPost.BumpTime;
                        Query.CategoryId = physicalPost.CategoryId;
                        Query.IsDisabled = physicalPost.IsDisabled;
                        Query.IsLocked = physicalPost.IsLocked;
                        Query.AltDescription = physicalPost.AltDescription;
                        Query.Zipcode = physicalPost.Zipcode;
                        Query.Address = physicalPost.Address;
                        //Somewhere in MVC, miliseconds gets erased, so here it is just removed entirely.
                        DateTime dt = DateTime.Now;
                        Query.LastEdited = dt.AddMilliseconds(-dt.Millisecond);
                        db.SubmitChanges();
                    }
                    return physicalPost;
                }
            }
            catch (Exception)
            {
                //if an exception occurs this checks if there even is a comment with the ID, if there is then ít has been changed from another place.
                using (var db = new SolvrContext())
                {

                    var Query = from pos in db.Posts where pos.Id == post.Id select pos;

                    //Query is a form of collection so we can check how many objects that is returned.
                    if (Query.Count() > 0)
                    {
                        //Concurrency error
                        throw new FaultException("");
                    }
                }

                //Standard error
                throw new NotImplementedException();
            }
        }

        public Report UpdateReport(Report report)
        {
            using (var db = new SolvrContext())
            {
                var Query = (from rep in db.Reports where rep.Id == report.Id select rep).First();
                Query.Title = report.Title;
                Query.Description = report.Description;
                Query.IsResolved = report.IsResolved;
                db.SubmitChanges();
            }

            return report;
        }
        #endregion
    }
}