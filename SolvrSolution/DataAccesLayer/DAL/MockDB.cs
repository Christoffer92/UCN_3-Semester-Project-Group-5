using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    public class MockDB : ISolvrDB
    {
        public MockDB()
        {
            FillTestData();
        }

        public static void CloseDB()
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

        private Category CreateCategory(Category category)
        {
            return MockDBContainer.Instance.AddCategory(category);
        }

        public PhysicalPost CreatePhysicalPost(PhysicalPost pPost)
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

        public Report GetReport(int id)
        {
            throw new NotImplementedException();
        }

        public List<Report> GetAllReports()
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
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

        public Report CreateReport(Report report)
        {
            return MockDBContainer.Instance.AddReport(report);
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

        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }
    }

    


}
