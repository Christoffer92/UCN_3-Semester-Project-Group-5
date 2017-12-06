using DataAccesLayer.ModelBuilds;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolvrLibrary;
using DataAccesLayer.DAL;

namespace SolvrLibrary
{
    public class SolvrDB :  ISolvrDB
    {

        //Queries
        //All regions follow order of: Create, Get, Update (CRU)
          

        #region Category

        public Category GetCategory(int id)
        {
            return new ModelBuilder().BuildCategory(id);
        }

        public Category GetCategory(string name)
        {
            throw new NotImplementedException();
        }

        public Report GetReport(int id)
        {
            return new ModelBuilder().BuildReport(id);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            using (var db = new SolvrContext())
            {
                return db.Categories.ToList<Category>();
            }
        }

        public void SetReportToResolved(int reportId)
        {
            using (var db = new SolvrContext())
            {
                // Query the database for the row to be updated.
                var Query =
                (from report
                in db.Reports.OfType<Report>()
                 where report.Id == reportId
                 select report
                ).First();

                Query.IsResolved = true;

                db.SubmitChanges();
            }
        }

        public void UpdatePostTilte(int postId, string text)
        {
            using (var db = new SolvrContext())
            {
                // Query the database for the row to be updated.
                var Query =
                    (from post
                     in db.Posts.OfType<Post>()
                     where post.Id == postId
                     select post
                      ).First();

                Query.Title = text;

                db.SubmitChanges();
            }
        }

        public void DisablePost(int postId)
        {
            using (var db = new SolvrContext())
            {
                // Query the database for the row to be updated.
                var Query =
                    (from post
                     in db.Posts.OfType<Post>()
                     where post.Id == postId
                     select post
                      ).First();

                Query.IsDisabled = true;
            }
        }

        public void UpdatePostText(int postId, string text)
        {
            using (var db = new SolvrContext())
            {
                // Query the database for the row to be updated.
                var Query =
                (from post
                in db.Posts.OfType<Post>()
                 where post.Id == postId
                 select post
                ).First();

                Query.Description = text;
                db.SubmitChanges();
            }
        }

        public bool DatabaseExists()
        {
            using (var db = new SolvrContext())
            {
                return db.DatabaseExists();
            }
        }
        #endregion

        #region User

        public User GetUser()
        {
            using (var db = new SolvrContext())
            {
                //TODO Improve
                int lastID = db.Users.Count();
                return new ModelBuilder().BuildUser(lastID);
            }
        }

        public User GetUser(int id)
        {
            return new ModelBuilder().BuildUser(id);
        }

        public User GetUser(string Username)
        {
            using (var DB = new SolvrContext())
            {
                var Query = (from user in DB.Users where user.Username == Username select user).First();
                return new ModelBuilder().BuildUser(Query.Id);
            }

        }

        #endregion

        #region General Post

        public Post CreatePost(Post post)
        {
            using (var db = new SolvrContext())
            {
                db.Posts.InsertOnSubmit(post);
                db.SubmitChanges();
            }

            return new ModelBuilder().BuildPost<Post>(post.Id);
        }

        public Post GetPost()
        {
            using (var db = new SolvrContext())
            {
                return db.Posts.OfType<Post>().Last();
            }
        }

        public Post GetPost(int id)
        {
            return new ModelBuilder().BuildPost<Post>(id);
        }

        public void UpdatePost(Post p)
        {
            using (var db = new SolvrContext())
            {
                // Query the database for the row to be updated.
                var Query =
                    (from post
                    in db.Posts.OfType<Post>()
                     where post.Id == p.Id
                     select post
                    ).First();

                // Execute the query, and change the column values
                // you want to change.ch
                Query.Title = p.Title;
                Query.Description = p.Description;
                Query.CategoryId = p.CategoryId;
                // Insert any additional changes to column values.

                // Query.Tags = p.Tags;

                // Submit the changes to the database.
                try
                {
                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        #endregion

        #region Physical Post

        public PhysicalPost CreatePhysicalPost(PhysicalPost physicalPost)
        {
            using (var db = new SolvrContext())
            {
                db.Posts.InsertOnSubmit(physicalPost);
                db.SubmitChanges();
            }
            return GetPhysicalPost(physicalPost.Id);
        }

        public void UpdatePhysicalPost(PhysicalPost p)
        {
            using (var db = new SolvrContext())
            {
                // Query the database for the row to be updated.
                var Query =
                    (from post
                    in db.Posts.OfType<PhysicalPost>()
                     where post.Id == p.Id
                     select post
                    ).First();

                // Execute the query, and change the column values
                // you want to change.ch
                Query.Title = p.Title;
                Query.Description = p.Description;
                Query.CategoryId = p.CategoryId;
                Query.AltDescription = p.AltDescription;
                Query.Zipcode = p.Zipcode;
                Query.Address = p.Address;
                Query.IsLocked = p.IsLocked;
                // Insert any additional changes to column values.

                // Query.Tags = p.Tags;

                // Submit the changes to the database.
                try
                {
                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public PhysicalPost GetPhysicalPost()
        {
            using (var db = new SolvrContext())
            {
                return db.Posts.OfType<PhysicalPost>().Last();
            }
        }

        public PhysicalPost GetPhysicalPost(int id)
        {
            //TODO Is model builder needed?
            return new ModelBuilder().BuildPost<PhysicalPost>(id);
        }

        #endregion

        #region General Comment

        public Comment CreateComment(Comment comment)
        {
            using (var db = new SolvrContext())
            {
                db.Comments.InsertOnSubmit(comment);
                db.SubmitChanges();
            }
            return GetComment(comment.Id);
        }

        public Comment GetComment(int id)
        {
            return new ModelBuilder().BuildComment<Comment>(id);
        }

        public T GetComment<T>(int ID)
        {
            return new ModelBuilder().BuildComment<T>(ID);
        }

        public IEnumerable<Comment> GetComments(int postId)
        {
            return new ModelBuilder().BuildCommentList(postId);
        }

        #endregion

        #region SolvrComment

        public SolvrComment CreateSolvrComment(SolvrComment sc)
        {
            using (var db = new SolvrContext())
            {
                db.Comments.InsertOnSubmit(sc);
                db.SubmitChanges();
                return GetSolvrComment(sc.Id);
            }
        }

        public SolvrComment GetSolvrComment(int id)
        {
            return new ModelBuilder().BuildComment<SolvrComment>(id);
        }

        public void UpdateSolvrComment(SolvrComment sc)
        {
            using (var db = new SolvrContext())
            {
                // Query the database for the row to be updated.
                var Query =
                    (from comment
                     in db.Comments.OfType<SolvrComment>()
                     where comment.Id == sc.Id
                     select comment
                    ).First();
                Query.IsAccepted = sc.IsAccepted;
                Query.TimeAccepted = sc.TimeAccepted;

                //TODO runs an error when updating the lock.
                //Query.Text = sc.Text;

                // Submit the changes to the database.
                try
                {
                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public List<Report> GetAllReports()
        {
            using (var db = new SolvrContext())
            {
                return db.Reports.ToList<Report>();
            }
        }
        #endregion


        public IEnumerable<Post> GetPostsByBumpTime(int loadCount = 0)
        {
            List<Post> postList = null;
            using (var DB = new SolvrContext())
            {
                postList = new List<Post>();
                var postQuery = (from post in DB.Posts orderby post.BumpTime descending select post).Skip(loadCount).Take(24);
                foreach (var post in postQuery)
                {
                    post.User = GetUser(post.UserId);
                    post.Category = GetCategory(post.CategoryId);
                    postList.Add(post);
                }
            }
            return postList;
        }
        

        public void CreateUser(User user)
        {
            using (var DB = new SolvrContext())
            {
                DB.Users.InsertOnSubmit(user);
                DB.SubmitChanges();
            }
        }
    }
}
