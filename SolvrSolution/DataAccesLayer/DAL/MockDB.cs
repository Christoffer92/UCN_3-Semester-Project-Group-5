using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolvrLibrary;

namespace DataAccesLayer.DAL
{
    public class MockDB : ISolvrDB
    {
        public static void CloseDB()
        {
            MockDBContainer.Instance = null;
        }

        public PhysicalPost CreatePhysicalPost(PhysicalPost pPost)
        {
            return MockDBContainer.Instance.AddPhysicalPost(pPost);
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
