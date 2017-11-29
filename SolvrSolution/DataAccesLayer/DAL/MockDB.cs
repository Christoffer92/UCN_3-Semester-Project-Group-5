using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    public class MockDB : ISolvrDB
    {
        static bool IsTestDataInserted = false;
        public MockDB()

        {
            if (!IsTestDataInserted)
            {
                FillTestData();
                IsTestDataInserted = true;
            }         
         
        }
        public void CloseDB()
        {
            IsTestDataInserted = false;
            MockDBContainer.Instance = null;
        }

        public void FillTestData()
        {
            User user1 = new User()
            {
                Name = "Jens",
                Id = 1,
                Email = "hej@email.dk",
                Password = "sdads",
                Username = "user123"
            };
            CreateUser(user1);

            Category cat1 = new Category();
            cat1.Name = "Computer";
            CreateCategory(cat1);

            Category cat2 = new Category();
            cat2.Name = "Garden";
            CreateCategory(cat2);

            Post post1 = new Post();
            post1.User = null;
            post1.Category = cat1;
            post1.Title = "Lorum borum";
            post1.Description = "Lorum ispum lambbda Bamba.";
            post1.Comments = new List<Comment>();
            CreatePost(post1);

            Post post2 = new Post();
            post2.User = null;
            post2.Category = cat2;
            post2.Title = "Hyncatia Mortis";
            post2.Description = "Hycantia is dying in winter, helpie pls.";
            post2.Comments = new List<Comment>();
            CreatePost(post2);

            PhysicalPost ppost1 = new PhysicalPost();
            ppost1.User = null;
            ppost1.Category = cat2;
            ppost1.Title = "GardenKArl";
            ppost1.Description = "Need help for old bones to cut grass";
            ppost1.Comments = new List<Comment>();
            ppost1.AltDescription = "TESTEPGNEAGSEG";
            ppost1.Address = "Hycanitvej 2";
            ppost1.Zipcode = "7100";
            CreatePhysicalPost(ppost1);

        }



        #region create methods

        private void CreateUser(User user)
        {
            MockDBContainer.Instance.AddUser(user);
        }
        public void CreatePost(Post post)
        {
            MockDBContainer.Instance.AddPost(post);
        }

        public void CreatePost(User expectedUser, string expectedPostTitle, string expectedPostDescription, Category expectedCategory, List<string> expectedTagsList)
        {
            Post p = new Post();
            p.User = expectedUser;
            p.Title = expectedPostTitle;
            p.Description = expectedPostDescription;
            p.Category = expectedCategory;
            p.Tags = expectedTagsList;

            MockDBContainer.Instance.AddPost(p);
        }

        public void CreatePhysicalPost(PhysicalPost pPost)
        {
            MockDBContainer.Instance.AddPhysicalPost(pPost);
        }

        public void CreatePhysicalPost(User _user, string _title, string _description, Category _category, List<string> _tagsList, string _altDescription, string _zipcode, string _address)
        {
            PhysicalPost post = new PhysicalPost(/*Fill this constructor when needed*/);

            post.User = _user;
            post.Title = _title;
            post.Description = _description;
            post.Category = _category;
            post.Tags = _tagsList;
            post.AltDescription = _altDescription;
            post.Zipcode = _zipcode;
            post.Address = _address;

            MockDBContainer.Instance.AddPhysicalPost(post);
        }

        public void CreateCategory(Category cat)
        {
            MockDBContainer.Instance.AddCategory(cat);
        }

        #endregion


        #region Get methods

        public Post GetPost()
        {
            return MockDBContainer.Instance.GetPost();
        }

        public Post GetPost(int id)
        {
            return MockDBContainer.Instance.GetPost(id);
        }

        public PhysicalPost GetPhysicalPost()
        {
            return MockDBContainer.Instance.GetPhysicalPost();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return MockDBContainer.Instance.GetAllCategories();
        }

        public Category GetCategory(string name)
        {
            return MockDBContainer.Instance.GetCategory(name);
        }

        public Category GetCategory(int id)
        {
            return MockDBContainer.Instance.GetCategory(id);
        }

        public User GetUser(int id)
        {
            return MockDBContainer.Instance.GetUser(id);
        }

        #endregion

    }

    //-----------------------------------------------------------------------------------------------------------
    class MockDBContainer
    {

        //Singleton Creation
        private static MockDBContainer _Instance;

        public static MockDBContainer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MockDBContainer();
                }

                return _Instance;
            }

            set
            {
                _Instance = value;
            }
        }

        private List<Post> Posts;
        private List<User> Users;
        private List<Comment> Comments;
        private List<Category> Categories;
        private List<Report> Reports;
        private List<SolvrComment> SolvrComments;
        private List<Vote> Votes;
        private List<PhysicalPost> PhysicalPosts;

        public MockDBContainer()
        {

            Users = new List<User>();
            Posts = new List<Post>();
            PhysicalPosts = new List<PhysicalPost>();
            Categories = new List<Category>();
            Reports = new List<Report>();
            Comments = new List<Comment>();
            SolvrComments = new List<SolvrComment>();
            Votes = new List<Vote>();

        }

        #region Add methods

        internal void AddUser(User _user)
        {
            if (Users.Count == 0)
            {
                _user.Id = 1;
            }
            else
            {
                _user.Id = Users.Last().Id + 1;
            }

            Users.Add(_user);
        }

        internal void AddPost(Post _post)
        {
            if (Posts.Count == 0)
            {
                _post.Id = 1;
            }
            else
            {
                _post.Id = Posts.Last().Id + 1;
            }

            Posts.Add(_post);
        }

        internal void AddPhysicalPost(PhysicalPost _post)
        {
            if (PhysicalPosts.Count == 0)
            {
                _post.Id = 1;
            }
            else
            {
                _post.Id = PhysicalPosts.Last().Id + 1;
            }

            PhysicalPosts.Add(_post);
        }

        internal void AddCategory(Category _category)
        {
            if (Categories.Count == 0)
            {
                _category.Id = 1;
            }
            else
            {
                _category.Id = Categories.Last().Id + 1;
            }

            Categories.Add(_category);
        }

        internal void AddReport(Report _report)
        {
            if (Reports.Count == 0)
            {
                _report.Id = 1;
            }
            else
            {
                _report.Id = Reports.Last().Id + 1;
            }

            Reports.Add(_report);
        }

        internal void AddComment(Comment _comment)
        {
            if (Comments.Count == 0)
            {
                _comment.Id = 1;
            }
            else
            {
                _comment.Id = Comments.Last().Id + 1;
            }

            Comments.Add(_comment);
        }

        internal void AddSolvrComment(SolvrComment _comment)
        {
            if (SolvrComments.Count == 0)
            {
                _comment.Id = 1;
            }
            else
            {
                _comment.Id = SolvrComments.Last().Id + 1;
            }

            SolvrComments.Add(_comment);
        }

        internal void AddVote(Vote _vote)
        {
            if (Votes.Count == 0)
            {
                _vote.Id = 1;
            }
            else
            {
                _vote.Id = Votes.Last().Id + 1;
            }

            Votes.Add(_vote);
        }

        #endregion

        #region Get methods

        internal Post GetPost()
        {
            return Posts.Last();
        }

        internal Post GetPost(int id)
        {
            Post p = null;

            foreach (Post item in Posts)
            {
                if (item.Id == id)
                {
                    p = item;
                }
            }
            return p;
        }

        internal PhysicalPost GetPhysicalPost()
        {
            return PhysicalPosts.Last();
        }

        internal List<Category> GetAllCategories()
        {
            List<Category> catlist = new List<Category>();

            foreach (Category cat in Categories)
            {
                catlist.Add(cat);
            }

            return catlist;
        }

        internal Category GetCategory(int id)
        {
            Category cat = null;

            foreach (Category item in Categories)
            {
                if (item.Id == id)
                {
                    cat = item;
                }
            }
            return cat;
        }

        internal Category GetCategory(string name)
        {
            Category cat = null;

            foreach (Category item in Categories)
            {
                if (item.Name == name)
                {
                    cat = item;
                }
            }
            return cat;
        }

        internal User GetUser(int id)
        {
            User user = null;

            foreach (User item in Users)
            {
                if (item.Id == id)
                {
                    user = item;
                }
            }
            return user;
        }

        #endregion
    }


}