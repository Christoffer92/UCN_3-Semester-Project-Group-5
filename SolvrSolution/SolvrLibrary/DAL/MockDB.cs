using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    public class MockDB /*: ISolvrDB*/
    {
        public void CloseDB()
        {
            MockDBContainer.Instance = null;
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
            post.ZipCode = _zipcode;
            post.Address = _address;

            MockDBContainer.Instance.AddPhysicalPost(post);
        }

        public PhysicalPost GetLastPhysicalPost()
        {
            return MockDBContainer.Instance.GetLastPhysicalPost();
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

        public Post GetLastPost()
        {
            return MockDBContainer.Instance.GetLastPost();
        }

        public Category GetCategory(int id)
        {
            return MockDBContainer.Instance.GetCategory(id);
        }

        public Category GetCategory(string name)
        {
            return MockDBContainer.Instance.GetCategory(name);
        }

        public Post GetPost(int id)
        {
            return MockDBContainer.Instance.GetPost(id);
        }

        public Post GetPost()
        {
            return MockDBContainer.Instance.GetPost();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return MockDBContainer.Instance.GetAllCategories();
        }

        public void CreatePost(Post post)
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

        public PhysicalPost GetLastPhysicalPost()
        {
            return PhysicalPosts.Last();
        }

        public Post GetLastPost()
        {
            return Posts.Last();
        }

        public List<Category> GetAllCategories()
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
        
        public Category GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(string name)
        {
            throw new NotImplementedException();
        }

        public Post GetPost(int id)
        {
            throw new NotImplementedException();
        }

        public Post GetPost()
        {
            throw new NotImplementedException();
        }

        #endregion
    }


}
