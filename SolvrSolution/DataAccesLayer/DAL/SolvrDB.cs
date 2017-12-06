using DataAccesLayer.ModelBuilds;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolvrLibrary;

namespace SolvrLibrary
{
    public class SolvrDB : DataContext, ISolvrDB
    {
        //General Connection String. Kan ikke være Const pga. Enviroment.MachineName.
        private static string ConnectionString = @"Data Source=" + Environment.MachineName + @"\SQLEXPRESS;" 
        +"Initial Catalog=SolvrDb;" 
        +"Integrated Security=True;" 
        +"Connect Timeout=30;" 
        +"Encrypt=False;" 
        +"TrustServerCertificate=True;" 
        +"ApplicationIntent=ReadWrite;" 
        +"MultiSubnetFailover=False";

        //Here are the tables for the project. These tables are in the database.
        public Table<Post> Posts;// { get; private set; }
        public Table<User> Users;// { get; private set; }
        public Table<Comment> Comments;// { get; private set; }
        public Table<Category> Categories;// { get; set; }
        public Table<Report> Reports;// { get; private set; }
        public Table<Vote> Votes;// { get; private set; }

        /// <summary>
        /// Used to create a connection to the database through a connection string.
        /// Base is an inheritance that creates a new instance of the datacontext class (In here SolvrDB)
        /// </summary>
        /// <param name="connection"></param>
        public SolvrDB() : base(ConnectionString) { }

        //Queries after this:
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
            Posts.InsertOnSubmit(post);
            SubmitChanges();
            return new ModelBuilder().BuildPost<Post>(post.Id);
        }

        public PhysicalPost CreatePhysicalPost(PhysicalPost physicalPost)
        {
            Posts.InsertOnSubmit(physicalPost);
            SubmitChanges();
            return GetPhysicalPost(physicalPost.Id);
        }

        public Comment CreateComment(Comment comment)
        {
            Comments.InsertOnSubmit(comment);
            SubmitChanges();
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
            return Posts.OfType<Post>().Last();
        }

        public PhysicalPost GetPhysicalPost()
        {
            return Posts.OfType<PhysicalPost>().Last();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return Categories.ToList<Category>();
        }

        public User GetUser()
        {
            //TODO Improve
            int lastID = Users.Count();
            return new ModelBuilder().BuildUser(lastID);
        }

        public User GetUser(int id)
        {
            return new ModelBuilder().BuildUser(id);
        }

        public IEnumerable<Comment> GetComments(int postId)
        {
            return new ModelBuilder().BuildCommentList(postId);
        }

        public IEnumerable<Post> GetPostsByBumpTime(int loadCount = 0)
        {
            List<Post> postList = null;
            using (var DB = new SolvrDB())
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
        public User GetUser(string Email)
        {
            using (var DB = new SolvrDB())
            {
                var Query = (from user in DB.Users where user.Email == Email select user).First();
                return new ModelBuilder().BuildUser(Query.Id);
            }

        }

        public void CreateUser(User user)
        {
                Users.InsertOnSubmit(user);
                SubmitChanges();
        }
    }


}
