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
            //Creates MockDB Container
        }

        public void CloseDB()
        {
            MockDBContainer.Instance = null;
        }

        public void CreatePhysicalPost(User expectedUser, string expectedTitle, string expectedDescription, Category expectedCategory, List<string> expectedTagsList, string expectedAltDescription, string expectedZipcode, string expectedAddress)
        {
            throw new NotImplementedException();
        }

        public PhysicalPost GetLastPhysicalPost()
        {
            throw new NotImplementedException();
        }

        public void CreatePost(User expectedUser, string expectedPostTitle, string expectedPostDescription, Category expectedCategory, List<string> expectedTagsList)
        {
            throw new NotImplementedException();
        }

        public Post GetLastPost()
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
            Posts = new List<Post>();
            Users = new List<User>();
            Comments = new List<Comment>();
            Categories = new List<Category>();
            Reports = new List<Report>();
            SolvrComments = new List<SolvrComment>();
            Votes = new List<Vote>();
            PhysicalPosts = new List<PhysicalPost>();
        }



    }


}
