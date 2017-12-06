using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    public class MockDB : ISolvrDB
    {
        public void CloseDB()
        {
            MockDBContainer.Instance = null;
        }
        public void FillTestData()
        {
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

            Post post2 = new Post();
            post2.User = null;
            post2.Category = cat2;
            post2.Title = "Hyncatia Mortis";
            post2.Description = "Hycantia is dying in winter, helpie pls.";
            post2.Comments = new List<Comment>();

            PhysicalPost ppost1 = new PhysicalPost();
            ppost1.User = null;
            ppost1.Category = cat2;
            ppost1.Title = "GardenKArl";
            ppost1.Description = "Need help for old bones to cut grass";
            ppost1.Comments = new List<Comment>();
            ppost1.AltDescription = "TESTEPGNEAGSEG";
            ppost1.Address = "Hycanitvej 2";
            ppost1.Zipcode = "7100";

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

        public PhysicalPost GetLastPhysicalPost()
        {
            return MockDBContainer.Instance.GetLastPhysicalPost();
        }

        public Post CreatePost(User expectedUser, string expectedPostTitle, string expectedPostDescription, Category expectedCategory, List<string> expectedTagsList)
        {
            Post p = new Post();
            p.User = expectedUser;
            p.Title = expectedPostTitle;
            p.Description = expectedPostDescription;
            p.Category = expectedCategory;
            p.Tags = expectedTagsList;

            return MockDBContainer.Instance.AddPost(p);
        }

        public void CreateCategory(Category cat)
        {
            MockDBContainer.Instance.AddCategory(cat);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return MockDBContainer.Instance.GetAllCategories();
        }

        public Post CreatePost(Post post)
        {
            return MockDBContainer.Instance.AddPost(post);
        }

        public Category GetCategory(int id)
        {
            return MockDBContainer.Instance.GetCategory(id);
        }

        public Category GetCategory(string name)
        {
            return MockDBContainer.Instance.GetCategory(name);
        }

        public PhysicalPost CreatePhysicalPost(PhysicalPost pPost)
        {
           return MockDBContainer.Instance.AddPhysicalPost(pPost);
        }

        public Post GetPost(int id)
        {
            return MockDBContainer.Instance.GetPost(id);
        }

        public Post GetPost()
        {
            return MockDBContainer.Instance.GetPost();
        }

        public User GetUser()
        {
            throw new NotImplementedException();
        }

        public User GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetComments(int iD)
        {
            throw new NotImplementedException();
        }

        public Comment CreateComment(Comment c)
        {
            throw new NotImplementedException();
        }

        public PhysicalPost GetPhysicalPost(int id)
        {
            throw new NotImplementedException();
        }

        public SolvrComment CreateSolvrComment(SolvrComment sc)
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(Post p)
        {
            throw new NotImplementedException();
        }

        public void UpdateSolvrComment(SolvrComment sc)
        {
            throw new NotImplementedException();
        }

        public T GetComment<T>(int ID)
        {
            throw new NotImplementedException();
        }

        public void UpdatePhysicalPost(PhysicalPost post)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Post> GetPostsByBumpTime(int loadCount)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string Email)
        {
            throw new NotImplementedException();
        }
    }

    class MockDBContainer
    {
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
        

        #region Create methods
        //internal Post CreatePost(Post post)
        //{
        //    int counterId = 0;

        //    foreach (Post item in Posts)
        //    {
        //        if (item.Id > counterId)
        //        {
        //            counterId = item.Id;
        //        }
        //    }

        //    post.Id = counterId + 1;

        //    Posts.Add(post);
        //    return post;
        //}

        //internal void CreatePhysicalPost(PhysicalPost pPost)
        //{
        //    int counterId = 0;

        //    foreach (PhysicalPost item in PhysicalPosts)
        //    {
        //        if (item.Id > counterId)
        //        {
        //            counterId = item.Id;
        //        }
        //    }

        //    pPost.Id = counterId + 1;

        //    PhysicalPosts.Add(pPost);
        //}



        #endregion

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

        internal Post AddPost(Post _post)
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
            return _post;
        }

        internal PhysicalPost AddPhysicalPost(PhysicalPost _post)
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
            return _post;
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

        internal PhysicalPost GetLastPhysicalPost()
        {
            return PhysicalPosts.Last();
        }

        internal List<Category> GetAllCategories()
        {
            //List<Category> CatList = new List<Category>();

            //foreach (Category cat in Categories)
            //{
            //    CatList.Add(cat);
            //}

            List<Category> CatList = new List<Category>();

            Category cat1 = new Category();
            Category cat2 = new Category();

            cat1.Name = "Computer";
            cat1.Id = 2;
            cat2.Name = "Garden";
            cat2.Id = 3;

            CatList.Add(cat1);
            CatList.Add(cat2);

            return CatList;
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

        internal User getUser(int id)
        {
            throw new NotImplementedException();
        }

        internal Post GetPost()
        {
            return Posts.Last();
        }

        #endregion
    }


}
