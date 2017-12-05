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
        public Category GetCategory(int id)
        {
            return new ModelBuilder().BuildCategory(id);
        }

        public Category GetCategory(string name)
        {
            throw new NotImplementedException();
        }

        public Post CreatePost(Post post)
        {
            using (var db = new SolvrContext())
            {
                db.Posts.InsertOnSubmit(post);
                db.SubmitChanges();
            }

            return new ModelBuilder().BuildPost<Post>(post.Id);
        }

        public PhysicalPost CreatePhysicalPost(PhysicalPost physicalPost)
        {
            using (var db = new SolvrContext())
            {
                db.Posts.InsertOnSubmit(physicalPost);
                db.SubmitChanges();
            }
            return GetPhysicalPost(physicalPost.Id);
        }

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

        public Post GetPost(int id)
        {
            return new ModelBuilder().BuildPost<Post>(id);
        }

        public PhysicalPost GetPhysicalPost(int id)
        {
            return new ModelBuilder().BuildPost<PhysicalPost>(id);
        }

        public Post GetPost()
        {
            using (var db = new SolvrContext())
            {
                return db.Posts.OfType<Post>().Last();
            }
        }

        public PhysicalPost GetPhysicalPost()
        {
            using (var db = new SolvrContext())
            {
                return db.Posts.OfType<PhysicalPost>().Last();
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
            using (var db = new SolvrContext())
            {
                return db.Categories.ToList<Category>();
            }
        }

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

        public IEnumerable<Comment> GetComments(int postId)
        {
            return new ModelBuilder().BuildCommentList(postId);
        }

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
    }
}
